// File: Assets/_Project/Scripts/Network/GatewaySocket.cs
//
// Raw-byte TCP socket for the Gateway protocol — DIFFERENT framing than TMSKSocket.
//
// Source ref:
//   - Wire format: gốc XSampleSocket (libclient_scene.so) sends raw bytes; outer
//     dispatch table at offset +0x4f0 (XGatewayClient::OuterProcessReceivePackage
//     @ VMA 0x2343f4) — opcode in body byte[0], no length prefix.
//   - Server side: alo/gateway_server/gateway_server.py (Python emulator).
//
// DEVIATION (2026-04-27 phase A1, user approved "có chế server được cái gateway ko cho máu"):
//   - gốc Gateway response parsers (OnHandshakeRespond @0x232cf4 etc.) are
//     XOR-ENCRYPTED in the binary (entropy 6.94+) — cannot 1-1 port. We define
//     our own response layout and parse it ourselves; the encrypted native
//     parser is never invoked because KGlobalLua.ConnectGateway is bound to
//     our NetworkManager, not the native XGatewayClient.
//   - Wire bytes for REQUEST follow gốc DoHandshakeRequest exactly (decoded asm).
//
// Differences vs TMSKSocket:
//   TMSKSocket:    [4B size LE][2B cmdId LE][payload]   (matches GameServer)
//   GatewaySocket: [byte opcode][raw payload]           (matches our gateway)
//
// We keep the two separate so both protocols stay clean — same physical wire
// only one connection at a time.

using System;
using System.Collections.Concurrent;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using UnityEngine;

namespace ThanMaOrigin.Network
{
    public class GatewaySocket
    {
        private TcpClient? _client;
        private NetworkStream? _stream;
        private Thread? _recvThread;
        private volatile bool _running;

        // Inbound queue: (opcode, payload). payload is raw bytes after the opcode byte.
        // GatewayHandshake reads from this on Unity main thread to dispatch.
        public readonly ConcurrentQueue<(byte opcode, byte[] payload)> InboundQueue = new();

        // Async-safe error channel (set by RecvLoop, read by main thread). Cleared on Connect.
        public string LastError = "";

        public bool Connected => _client?.Connected ?? false;

        public bool Connect(string host, int port, int timeoutMs = 3000)
        {
            LastError = "";
            try
            {
                _client = new TcpClient { NoDelay = true };
                if (!_client.ConnectAsync(host, port).Wait(timeoutMs))
                {
                    LastError = $"Connect timeout {host}:{port} after {timeoutMs}ms";
                    Debug.LogError($"[GatewaySocket] {LastError}");
                    Close();
                    return false;
                }
                _stream = _client.GetStream();
                _running = true;
                _recvThread = new Thread(RecvLoop) { IsBackground = true, Name = "GatewaySocketRecv" };
                _recvThread.Start();
                Debug.Log($"[GatewaySocket] Connected {host}:{port}");
                return true;
            }
            catch (Exception e)
            {
                LastError = $"Connect failed {host}:{port}: {e.Message}";
                Debug.LogError($"[GatewaySocket] {LastError}");
                Close();
                return false;
            }
        }

        /// <summary>
        /// Send raw bytes (caller is responsible for the entire wire packet incl. opcode).
        /// gốc XGatewayClient::Send @0x418b70 wraps XSampleSocket::Send — raw write, no header.
        /// </summary>
        public void SendRaw(byte[] packet)
        {
            if (_stream == null || !_running) { Debug.LogError("[GatewaySocket] SendRaw on closed socket"); return; }
            if (packet == null || packet.Length == 0) return;
            try
            {
                lock (_stream)
                {
                    _stream.Write(packet, 0, packet.Length);
                    _stream.Flush();
                }
            }
            catch (Exception e)
            {
                LastError = $"Send failed: {e.Message}";
                Debug.LogError($"[GatewaySocket] {LastError}");
            }
        }

        // Recv loop: read 1-byte opcode, then variable-length payload using opcode-specific reader.
        // Each opcode has its own reader (see ReadResponseBody) since gateway responses are
        // self-describing per opcode — there is no generic length header in this protocol.
        private void RecvLoop()
        {
            try
            {
                while (_running && _stream != null)
                {
                    int op = _stream.ReadByte();
                    if (op < 0) { _running = false; break; }
                    byte opcode = (byte)op;

                    byte[] payload = ReadResponseBody(opcode);
                    if (payload == null)
                    {
                        // Unknown opcode or read error — log + close to avoid silent stream corruption.
                        LastError = $"Unknown response opcode 0x{opcode:X2} or read error — closing";
                        Debug.LogError($"[GatewaySocket] {LastError}");
                        break;
                    }
                    InboundQueue.Enqueue((opcode, payload));
                }
            }
            catch (IOException e) { LastError = $"Recv IO: {e.Message}"; }
            catch (ObjectDisposedException) { /* expected on Close */ }
            catch (Exception e)
            {
                LastError = $"Recv error: {e.Message}";
                Debug.LogError($"[GatewaySocket] {LastError}");
            }
            _running = false;
        }

        // Per-opcode response body reader — sizes are determined by the opcode's payload layout
        // (defined in gateway_server/protocol.py). Returns null on unknown opcode.
        private byte[]? ReadResponseBody(byte opcode)
        {
            switch (opcode)
            {
                case GatewayProtocol.RSP_HANDSHAKE:
                    // body: int32 ret_code + int32 n_show_agreement = 8 bytes
                    return ReadExact(8);

                case GatewayProtocol.RSP_GET_SERVER_LIST:
                    // body: uint16 count + N entries (each entry variable-len)
                    return ReadServerListBody();

                case GatewayProtocol.RSP_LOGIN_SERVER:
                    // body: uint16 addr_len + addr + int32 port
                    return ReadLoginServerBody();

                case GatewayProtocol.RSP_ERROR:
                    // body: int32 error_code + uint16 msg_len + msg
                    return ReadErrorBody();

                default:
                    return null;
            }
        }

        private byte[]? ReadExact(int count)
        {
            if (count <= 0) return Array.Empty<byte>();
            var buf = new byte[count];
            int got = 0;
            while (got < count)
            {
                int n = _stream!.Read(buf, got, count - got);
                if (n <= 0) return null;
                got += n;
            }
            return buf;
        }

        private byte[]? ReadServerListBody()
        {
            var head = ReadExact(2);
            if (head == null) return null;
            int count = BitConverter.ToUInt16(head, 0);

            using var ms = new MemoryStream();
            ms.Write(head, 0, head.Length);

            for (int i = 0; i < count; i++)
            {
                // server_id int32 + name (uint16+bytes) + addr (uint16+bytes) + port int32 + status uint8
                var f1 = ReadExact(4); if (f1 == null) return null;
                ms.Write(f1, 0, 4);

                var nl = ReadExact(2); if (nl == null) return null;
                int nameLen = BitConverter.ToUInt16(nl, 0);
                ms.Write(nl, 0, 2);
                var nameBytes = ReadExact(nameLen); if (nameBytes == null) return null;
                ms.Write(nameBytes, 0, nameLen);

                var al = ReadExact(2); if (al == null) return null;
                int addrLen = BitConverter.ToUInt16(al, 0);
                ms.Write(al, 0, 2);
                var addrBytes = ReadExact(addrLen); if (addrBytes == null) return null;
                ms.Write(addrBytes, 0, addrLen);

                var portStatus = ReadExact(5); if (portStatus == null) return null;  // int32 port + uint8 status
                ms.Write(portStatus, 0, 5);
            }
            return ms.ToArray();
        }

        private byte[]? ReadLoginServerBody()
        {
            var nl = ReadExact(2); if (nl == null) return null;
            int addrLen = BitConverter.ToUInt16(nl, 0);
            var addrBytes = ReadExact(addrLen); if (addrBytes == null) return null;
            var port = ReadExact(4); if (port == null) return null;

            using var ms = new MemoryStream();
            ms.Write(nl, 0, 2);
            ms.Write(addrBytes, 0, addrLen);
            ms.Write(port, 0, 4);
            return ms.ToArray();
        }

        private byte[]? ReadErrorBody()
        {
            var ec = ReadExact(4); if (ec == null) return null;
            var ml = ReadExact(2); if (ml == null) return null;
            int msgLen = BitConverter.ToUInt16(ml, 0);
            var msg = ReadExact(msgLen); if (msg == null) return null;

            using var ms = new MemoryStream();
            ms.Write(ec, 0, 4);
            ms.Write(ml, 0, 2);
            ms.Write(msg, 0, msgLen);
            return ms.ToArray();
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
