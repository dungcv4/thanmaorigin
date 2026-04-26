// File: Assets/_Project/Scripts/Network/TMSKSocket.cs
//
// DEVIATION — bridge layer, NO 1-1 IL2CPP equivalent.
// Reason: gốc client-side TCP đi qua native libclient_scene.so (LuaServerRemoteCallEntry chain
//         in KTO_LibClientScene_Decompiled/INDEX.tsv VMA 0x2359ec). thanmaorigin cannot use
//         that .so binary, must write managed C# wrapper.
// Approved by user: 2026-04-26 (no-chế-cháo audit — explicit DEVIATION cite).
//
// Wire format — MATCH gốc server (Phase 10.1 fix 2026-04-26):
//   [4B Int32 LE PacketDataSize][2B UInt16 LE PacketCmdID][payload]
//
// Cite: alo/GameServer_NET8/GameServer/Protocol/TCPInPacket.cs:60-62
//   _PacketDataSize = BitConverter.ToInt32(CmdHeaderBuffer, 0);   // 4 bytes LE
//   _PacketCmdID    = BitConverter.ToUInt16(CmdHeaderBuffer, 4);  // 2 bytes LE
//
// PHASE 10.1 — wire format adapter:
//   Previous: [2B BE totalLen][2B BE opcode][payload]   (DEVIATION, didn't match server)
//   Current:  [4B LE dataSize][2B LE cmdID][payload]    (matches gốc server expectations)
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

        // Send packet: [4B Int32 LE dataSize][2B UInt16 LE cmdId][payload]
        // Match gốc TCPInPacket.cs:60-62 expected wire format.
        public void Send(int opcode, byte[]? payload)
        {
            if (_stream == null || !_running) return;
            payload ??= Array.Empty<byte>();

            int dataSize = payload.Length;
            // BitConverter on LE platforms (which Unity runs) defaults to little-endian — matches gốc.
            var hdr = new byte[HEADER_SIZE];
            Buffer.BlockCopy(BitConverter.GetBytes(dataSize), 0, hdr, 0, 4);            // Int32 LE
            Buffer.BlockCopy(BitConverter.GetBytes((ushort)opcode), 0, hdr, 4, 2);       // UInt16 LE

            try
            {
                lock (_stream)
                {
                    _stream.Write(hdr, 0, HEADER_SIZE);
                    if (payload.Length > 0) _stream.Write(payload, 0, payload.Length);
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
