// File: Assets/_Project/Scripts/Network/TMSKSocket.cs
//
// DEVIATION — bridge layer, NO 1-1 IL2CPP equivalent.
// Reason: gốc client-side TCP đi qua native libclient_scene.so (LuaServerRemoteCallEntry chain
//         in KTO_LibClientScene_Decompiled/INDEX.tsv VMA 0x2359ec). thanmaorigin cannot use
//         that .so binary, must write managed C# wrapper.
// Approved by user: 2026-04-26 (no-chế-cháo audit — explicit DEVIATION cite).
//
// Wire format — MATCH gốc server (Phase 10.1 fix 2026-04-26 + Day 9.15 anti-cheat fix):
//   [4B Int32 LE PacketDataSize][2B UInt16 LE PacketCmdID][1B crc][4B Int32 LE checkTicks][payload]
//
// Cite:
//   - Header: alo/GameServer_NET8/GameServer/Protocol/TCPInPacket.cs:60-62
//   - Anti-cheat byte+ticks: GameServer/Server/TCPManager.cs:409 CheckClientDataValid
//     byte[0] = (crc32(bytes[1..end]) % 255) ^ (cmdId % 255)
//     bytes[1..4] = clientCheckTicks (Int32 LE, monotonic — must be >= last received)
//   - PacketDataSize includes the 1+4 anti-cheat prefix.
//
// Day 9.15 (2026-04-27): added anti-cheat header. Without it, server logs
//   "Verify packet faild" and closes socket immediately on any CMD send.
//
// Naming "TMSKSocket" intentionally ad-hoc (not gốc class name). gốc has TcpServer.TCPClientHandle
// (server-side handle) but no client-side TCP wrapper exists in IL2CPP.

using System;
using System.Collections.Concurrent;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using UnityEngine;

namespace ThanMaOrigin.Network
{
    public class TMSKSocket
    {
        private TcpClient? _client;
        private NetworkStream? _stream;
        private Thread? _recvThread;
        private volatile bool _running;

        // Header is 6 bytes total: 4 for dataSize, 2 for cmdId
        private const int HEADER_SIZE = 6;
        // Sanity bound: refuse any single packet > 16 MB (matches gốc TCPCmdPacketSize.RECV_MAX_SIZE)
        private const int MAX_PACKET_DATA = 16 * 1024 * 1024;

        public readonly ConcurrentQueue<(int opcode, byte[] payload)> InboundQueue = new();

        public bool Connected => _client?.Connected ?? false;

        public bool Connect(string host, int port)
        {
            try
            {
                _client = new TcpClient { NoDelay = true };
                if (!_client.ConnectAsync(host, port).Wait(2000))
                {
                    Debug.LogError($"[TMSKSocket] Connect timeout {host}:{port}");
                    Close();
                    return false;
                }
                _stream = _client.GetStream();
                _running = true;
                _recvThread = new Thread(RecvLoop) { IsBackground = true, Name = "TMSKSocketRecv" };
                _recvThread.Start();
                Debug.Log($"[TMSKSocket] Connected {host}:{port}");
                return true;
            }
            catch (Exception e)
            {
                Debug.LogError($"[TMSKSocket] Connect failed {host}:{port}: {e.Message}");
                Close();
                return false;
            }
        }

        // Monotonic check counter — server requires `clientCheckTicks` to be
        // non-decreasing across packets (anti-cheat replay guard).
        private int _checkTicks = 1;

        // Send packet: [4B Int32 LE dataSize][2B UInt16 LE cmdId][1B crc][4B Int32 LE ticks][payload]
        //   dataSize = 1 + 4 + payload.Length  (includes anti-cheat prefix)
        //   crc = (CRC32(bytes[1..end]) % 255) ^ (cmdId % 255)
        //   ticks = monotonic counter
        // Match gốc TCPInPacket.cs:60-62 + TCPManager.cs:409 CheckClientDataValid.
        public void Send(int opcode, byte[]? payload)
        {
            if (_stream == null || !_running) return;
            payload ??= Array.Empty<byte>();

            // Build the body: [crc placeholder][ticks][payload]
            int bodySize = 1 + 4 + payload.Length;
            var body = new byte[bodySize];
            // Reserve byte[0] for crc (filled after computing).
            int ticks = System.Threading.Interlocked.Increment(ref _checkTicks);
            Buffer.BlockCopy(BitConverter.GetBytes(ticks), 0, body, 1, 4);
            if (payload.Length > 0)
                Buffer.BlockCopy(payload, 0, body, 5, payload.Length);

            // CRC over body[1..bodySize] (everything after the crc byte).
            uint crc32 = Crc32.Compute(body, 1, bodySize - 1);
            uint cc = crc32 % 255u;
            uint cc2 = (uint)opcode % 255u;
            body[0] = (byte)(cc ^ cc2);

            // Header: [4B sizeField LE][2B cmdId LE]
            //   sizeField INCLUDES the 2-byte cmdId per gốc TCPInPacket.cs:416 (subtracts 2).
            //   So sizeField = bodySize + 2 on the wire.
            int sizeField = bodySize + 2;
            var hdr = new byte[HEADER_SIZE];
            Buffer.BlockCopy(BitConverter.GetBytes(sizeField), 0, hdr, 0, 4);
            Buffer.BlockCopy(BitConverter.GetBytes((ushort)opcode), 0, hdr, 4, 2);

            try
            {
                lock (_stream)
                {
                    _stream.Write(hdr, 0, HEADER_SIZE);
                    _stream.Write(body, 0, bodySize);
                    _stream.Flush();
                }
            }
            catch (Exception e) { Debug.LogError($"[TMSKSocket] Send failed: {e.Message}"); }
        }

        // Recv loop: parse [4B Int32 LE dataSize][2B UInt16 LE cmdId][payload].
        private void RecvLoop()
        {
            var hdr = new byte[HEADER_SIZE];
            try
            {
                while (_running && _stream != null)
                {
                    if (!ReadExact(_stream, hdr, HEADER_SIZE)) break;
                    int dataSize = BitConverter.ToInt32(hdr, 0);    // LE
                    ushort cmdId = BitConverter.ToUInt16(hdr, 4);   // LE
                    if (dataSize < 0 || dataSize > MAX_PACKET_DATA)
                    {
                        Debug.LogError($"[TMSKSocket] Invalid packet size {dataSize} for cmd {cmdId} — closing");
                        break;
                    }
                    var payload = dataSize > 0 ? new byte[dataSize] : Array.Empty<byte>();
                    if (dataSize > 0 && !ReadExact(_stream, payload, dataSize)) break;
                    InboundQueue.Enqueue((cmdId, payload));
                }
            }
            catch (IOException) { }
            catch (Exception e) { Debug.LogError($"[TMSKSocket] RecvLoop: {e.Message}"); }
            _running = false;
        }

        private static bool ReadExact(Stream s, byte[] buf, int count)
        {
            int read = 0;
            while (read < count)
            {
                int n = s.Read(buf, read, count - read);
                if (n <= 0) return false;
                read += n;
            }
            return true;
        }

        public void Close()
        {
            _running = false;
            try { _stream?.Close(); } catch { }
            try { _client?.Close(); } catch { }
            _stream = null;
            _client = null;
        }
    }
}
