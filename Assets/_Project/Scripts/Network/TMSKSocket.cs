// File: Assets/_Project/Scripts/Network/TMSKSocket.cs
//
// DEVIATION — bridge layer, NO 1-1 IL2CPP equivalent.
// Reason: gốc client-side TCP đi qua native libclient_scene.so (LuaServerRemoteCallEntry chain
//         in KTO_LibClientScene_Decompiled/INDEX.tsv VMA 0x2359ec). thanmaorigin cannot use
//         that .so binary, must write managed C# wrapper.
// Approved by user: 2026-04-26 (no-chế-cháo audit — explicit DEVIATION cite).
//
// Wire format (verified): [2B totalLen BE][2B opcode BE][payload]
//   - Confirmed via E2E test 2026-04-26: client sent CMD 100 + 12B → server replied CMD 102.
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

        public void Send(int opcode, byte[]? payload)
        {
            if (_stream == null || !_running) return;
            payload ??= Array.Empty<byte>();
            ushort totalLen = (ushort)(4 + payload.Length);
            var header = new byte[4];
            header[0] = (byte)(totalLen >> 8); header[1] = (byte)(totalLen & 0xFF);
            header[2] = (byte)((opcode >> 8) & 0xFF); header[3] = (byte)(opcode & 0xFF);
            try
            {
                lock (_stream)
                {
                    _stream.Write(header, 0, 4);
                    if (payload.Length > 0) _stream.Write(payload, 0, payload.Length);
                    _stream.Flush();
                }
            }
            catch (Exception e) { Debug.LogError($"[TMSKSocket] Send failed: {e.Message}"); }
        }

        private void RecvLoop()
        {
            var lenBuf = new byte[2];
            var opBuf = new byte[2];
            try
            {
                while (_running && _stream != null)
                {
                    if (!ReadExact(_stream, lenBuf, 2)) break;
                    if (!ReadExact(_stream, opBuf, 2)) break;
                    ushort totalLen = (ushort)((lenBuf[0] << 8) | lenBuf[1]);
                    ushort opcode = (ushort)((opBuf[0] << 8) | opBuf[1]);
                    int payloadLen = totalLen - 4;
                    if (payloadLen < 0 || payloadLen > 65536) break;
                    var payload = new byte[payloadLen];
                    if (payloadLen > 0 && !ReadExact(_stream, payload, payloadLen)) break;
                    InboundQueue.Enqueue((opcode, payload));
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
