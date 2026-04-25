// File: Assets/_Project/Scripts/Network/TMSKSocket.cs
// TCP client wrapper với wire format [2B len BE][2B op BE][payload].
// Source: KTO_DecompiledReference/_root/TMSKSocket.c (gốc TCP layer in libclient_scene.so).
//
// Connect to gốc gateway IPs (61.28.227.144:11001) — DEVIATION: redirect to localhost:11001 for thanmaorigin LocalServer.

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

        // Inbound packets queued for main-thread dispatch
        public readonly ConcurrentQueue<(int opcode, byte[] payload)> InboundQueue = new();

        public bool Connected => _client?.Connected ?? false;

        /// <summary>Connect synchronously (blocking ~1s timeout).</summary>
        public bool Connect(string host, int port)
        {
            try
            {
                _client = new TcpClient();
                _client.NoDelay = true;
                var task = _client.ConnectAsync(host, port);
                if (!task.Wait(2000))
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

        /// <summary>Send packet [2B totalLen BE][2B opcode BE][payload].</summary>
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
            catch (Exception e)
            {
                Debug.LogError($"[TMSKSocket] Send failed: {e.Message}");
            }
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
            catch (IOException) { /* socket closed */ }
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
