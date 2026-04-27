// File: Assets/_Project/Scripts/Network/Crc32.cs
//
// CRC-32 (IEEE 802.3 polynomial 0xEDB88320) — 1-1 port of
// GameServer/Tmsk.Contract/Tools/CRC32.cs.
//
// Used by TMSKSocket to compute the per-packet anti-cheat byte that
// GameServer's CheckClientDataValid (TCPManager.cs:409) verifies on every
// inbound packet.

namespace ThanMaOrigin.Network
{
    public static class Crc32
    {
        private static readonly uint[] _table = MakeTable();

        private static uint[] MakeTable()
        {
            var t = new uint[256];
            for (int n = 0; n < 256; n++)
            {
                uint c = (uint)n;
                for (int k = 8; --k >= 0;)
                {
                    if ((c & 1) != 0) c = 0xedb88320u ^ (c >> 1);
                    else c = c >> 1;
                }
                t[n] = c;
            }
            return t;
        }

        public static uint Compute(byte[] buf, int off, int len)
        {
            uint c = ~0u;
            for (int i = 0; i < len; i++)
                c = _table[(c ^ buf[off + i]) & 0xff] ^ (c >> 8);
            return ~c;
        }
    }
}
