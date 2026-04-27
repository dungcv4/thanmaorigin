// File: Assets/_Project/Scripts/Network/GatewayProtocol.cs
//
// Constants + packet builders for KTO Gateway protocol.
// Mirror of /Users/vsf-user-l/Documents/Test/alo/gateway_server/protocol.py.
//
// REQUEST format references:
//   - Handshake: 1-1 with XGatewayClient::DoHandshakeRequest @0x233dc0 (clean asm).
//     Layout decoded from /tmp/handshake_dump/00233dc0_*.asm.
//
// RESPONSE format: DEVIATION 2026-04-27 — gốc parsers @0x232cf4/0x232d9c/0x232f0c
//   are XOR-encrypted (entropy 6.94+) so the gốc on-wire layout is unknown.
//   We define our own layout and parse it on client (this file) + server
//   (gateway_server/protocol.py). Both sides must change together.

using System;
using System.IO;
using System.Text;

namespace ThanMaOrigin.Network
{
    public static class GatewayProtocol
    {
        // ── Opcodes (mirror protocol.py) ────────────────────────────────────
        public const byte REQ_HANDSHAKE       = 0x01;  // matches gốc DoHandshakeRequest body byte[0]
        public const byte REQ_GET_SERVER_LIST = 0x02;
        public const byte REQ_LOGIN_SERVER    = 0x03;

        public const byte RSP_HANDSHAKE       = 0x80;
        public const byte RSP_GET_SERVER_LIST = 0x81;
        public const byte RSP_LOGIN_SERVER    = 0x82;
        public const byte RSP_ERROR           = 0xFF;

        // ── Constants from gốc DoHandshakeRequest ───────────────────────────
        public const int HANDSHAKE_ACCOUNT_FIELD_OFFSET = 0x05;
        public const int HANDSHAKE_ACCOUNT_FIELD_SIZE   = 0x50;  // 80 bytes
        public const int HANDSHAKE_OS_TYPE_OFFSET       = 0x55;
        public const int HANDSHAKE_TAIL_ACCOUNT_OFFSET  = 0x56;

        // ── Request builder: handshake (1-1 with gốc DoHandshakeRequest) ────
        // Source: /tmp/handshake_dump/00233dc0_XGatewayClient_DoHandshakeRequest.asm
        //   buf[0]      = 1                              (gốc 0x233ed8 strb w8, [x0])
        //   buf[1..4]   = int32 LE varX                  (gốc 0x233ed4 stur w25, [x0, #1])
        //   buf[5..0x55] = char[0x50] account zero-pad   (gốc 0x233f04 strncpy)
        //   buf[0x55]   = uint8 deviceOsType             (gốc 0x233f38 strb w22, [x23, #0x55])
        //   buf[0x56...] = char[N] account NUL-term      (gốc 0x233f14 memcpy)
        //   total       = strlen(account)+1+0x56         (gốc 0x233ec0 add x21, x24, #0x56)
        public static byte[] BuildHandshakeRequest(string account, int varX = 0, byte deviceOsType = 2)
        {
            account ??= "";
            byte[] acctBytes = Encoding.UTF8.GetBytes(account);
            // Clamp account length to UInt16 like gốc 0x233ebc and x24, x21, #0xffff
            int acctLen = Math.Min(acctBytes.Length, 0xFFFF);

            int totalSize = HANDSHAKE_TAIL_ACCOUNT_OFFSET + acctLen + 1; // + NUL
            var buf = new byte[totalSize];

            buf[0] = REQ_HANDSHAKE;

            // varX int32 LE at offset 1
            buf[1] = (byte)(varX & 0xFF);
            buf[2] = (byte)((varX >> 8) & 0xFF);
            buf[3] = (byte)((varX >> 16) & 0xFF);
            buf[4] = (byte)((varX >> 24) & 0xFF);

            // account zero-padded at [5..0x55) — gốc strncpy(buf+5, account, 0x50)
            // gốc: if (acct_len+1 > 0x50) buf[5] = 0; else strncpy
            if (acctLen + 1 > HANDSHAKE_ACCOUNT_FIELD_SIZE)
            {
                buf[HANDSHAKE_ACCOUNT_FIELD_OFFSET] = 0;
            }
            else
            {
                int copyLen = Math.Min(acctLen, HANDSHAKE_ACCOUNT_FIELD_SIZE - 1);
                Buffer.BlockCopy(acctBytes, 0, buf, HANDSHAKE_ACCOUNT_FIELD_OFFSET, copyLen);
                // remaining bytes already zero-init
            }

            buf[HANDSHAKE_OS_TYPE_OFFSET] = deviceOsType;

            // tail account memcpy at [0x56..0x56+acctLen) + NUL
            if (acctLen > 0)
                Buffer.BlockCopy(acctBytes, 0, buf, HANDSHAKE_TAIL_ACCOUNT_OFFSET, acctLen);
            buf[HANDSHAKE_TAIL_ACCOUNT_OFFSET + acctLen] = 0; // NUL

            return buf;
        }

        public static byte[] BuildGetServerListRequest()
        {
            return new byte[] { REQ_GET_SERVER_LIST };
        }

        public static byte[] BuildLoginServerRequest(int serverId)
        {
            var buf = new byte[5];
            buf[0] = REQ_LOGIN_SERVER;
            buf[1] = (byte)(serverId & 0xFF);
            buf[2] = (byte)((serverId >> 8) & 0xFF);
            buf[3] = (byte)((serverId >> 16) & 0xFF);
            buf[4] = (byte)((serverId >> 24) & 0xFF);
            return buf;
        }

        // ── Response parsers ────────────────────────────────────────────────
        public static (int retCode, int nShowAgreement) ParseHandshakeResponse(byte[] body)
        {
            if (body == null || body.Length < 8)
                throw new InvalidDataException($"handshake response too short: {body?.Length ?? 0} < 8");
            int retCode = BitConverter.ToInt32(body, 0);
            int nShowAgreement = BitConverter.ToInt32(body, 4);
            return (retCode, nShowAgreement);
        }

        public class GatewayServerEntry
        {
            public int ServerId;
            public string Name = "";
            public string Addr = "";
            public int Port;
            public byte Status;
        }

        public static GatewayServerEntry[] ParseServerListResponse(byte[] body)
        {
            if (body == null || body.Length < 2) throw new InvalidDataException("server list body too short");
            int count = BitConverter.ToUInt16(body, 0);
            var servers = new GatewayServerEntry[count];
            int p = 2;
            for (int i = 0; i < count; i++)
            {
                int sid = BitConverter.ToInt32(body, p); p += 4;
                int nl = BitConverter.ToUInt16(body, p); p += 2;
                string name = Encoding.UTF8.GetString(body, p, nl); p += nl;
                int al = BitConverter.ToUInt16(body, p); p += 2;
                string addr = Encoding.UTF8.GetString(body, p, al); p += al;
                int port = BitConverter.ToInt32(body, p); p += 4;
                byte status = body[p]; p += 1;
                servers[i] = new GatewayServerEntry
                {
                    ServerId = sid,
                    Name = name,
                    Addr = addr,
                    Port = port,
                    Status = status,
                };
            }
            return servers;
        }

        public static (string addr, int port) ParseLoginServerResponse(byte[] body)
        {
            int nl = BitConverter.ToUInt16(body, 0);
            string addr = Encoding.UTF8.GetString(body, 2, nl);
            int port = BitConverter.ToInt32(body, 2 + nl);
            return (addr, port);
        }

        public static (int errorCode, string message) ParseErrorResponse(byte[] body)
        {
            int errorCode = BitConverter.ToInt32(body, 0);
            int ml = BitConverter.ToUInt16(body, 4);
            string msg = Encoding.UTF8.GetString(body, 6, ml);
            return (errorCode, msg);
        }
    }
}
