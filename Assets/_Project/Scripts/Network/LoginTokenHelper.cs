// File: Assets/_Project/Scripts/Network/LoginTokenHelper.cs
//
// Builds the encrypted login token + CMD_LOGIN_ON packet that GameServer
// expects. Mirrors server-side classes 1-1:
//   - RC4Helper.cs           → GameServer/Tmsk.Contract/Tools/RC4Helper.cs
//   - SHA1Helper.cs          → GameServer/Tmsk.Contract/Tools/SHA1Helper.cs
//   - UserLoginToken.cs      → GameServer/Protocol/UserLoginToken.cs
//   - TCPRandKey.cs          → GameServer/Logic/TCPRandKey.cs (re-seeded same way)
//
// gốc native (libclient_scene.so) builds this packet inside
// XWorldClient::DoHandshakeRequest @0x282e6c — function body XOR-encrypted,
// can't be 1-1 ported. Replaced with this faithful re-implementation.
//
// Server config (from GameServer/bin/Debug/net10.0/AppConfig.xml):
//   <Token count="10000" randseed="123456" sha1="12345" data="12345" .../>
// Server enum: VerSign = 20140624 (TCPCmdProtocolVer.VerSign)

using System;
using System.Security.Cryptography;
using System.Text;

namespace ThanMaOrigin.Network
{
    public static class LoginTokenHelper
    {
        // Match GameServer AppConfig.xml Token element. If server config changes,
        // these must change too. DEVIATION marker: hard-coded for dev mode.
        public const string KeySHA1 = "12345";
        public const string KeyData = "12345";
        public const int RandKeyCount = 10000;
        public const int RandKeySeed = 123456;
        public const int VerSign = 20140624;  // matches TCPCmdProtocolVer.VerSign

        private static int[] _randKeys;

        // Replicate TCPRandKey: same seed + count produces same key sequence.
        // Pick any value from the pool — server's FindKey() will accept it.
        public static int GetRandKey()
        {
            if (_randKeys == null)
            {
                var rng = new Random(RandKeySeed);
                _randKeys = new int[RandKeyCount];
                for (int i = 0; i < RandKeyCount; i++)
                    _randKeys[i] = rng.Next(0, int.MaxValue);
            }
            // Pick a stable index so dev sessions are reproducible.
            return _randKeys[0];
        }

        /// <summary>
        /// Build the userToken Base64 string the server expects in field[2].
        /// Mirrors UserLoginToken.GetEncryptString.
        /// </summary>
        public static string BuildToken(string userId, int randomPwd)
        {
            // 1. Build inner data: "U:{UserID}:{RandomPwd}:{NowTicks*10000}:T"
            //    NowRealTime() = unix seconds; TimeUtil multiplies by 10000.
            long nowSec = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            long nowTicks10000 = nowSec * 10000L;
            string inner = $"U:{userId}:{randomPwd}:{nowTicks10000}:T";
            byte[] dataToken = Encoding.UTF8.GetBytes(inner);

            // 2. HMAC-SHA1(dataToken, KeySHA1) → 20 bytes
            byte[] mac;
            using (var hmac = new HMACSHA1(Encoding.UTF8.GetBytes(KeySHA1)))
            {
                mac = hmac.ComputeHash(dataToken);
            }

            // 3. Concatenate: [20-byte mac] + [data]
            byte[] combined = new byte[mac.Length + dataToken.Length];
            Buffer.BlockCopy(mac, 0, combined, 0, mac.Length);
            Buffer.BlockCopy(dataToken, 0, combined, mac.Length, dataToken.Length);

            // 4. RC4-encrypt with KeyData
            RC4(combined, Encoding.UTF8.GetBytes(KeyData));

            // 5. Base64
            return Convert.ToBase64String(combined);
        }

        /// <summary>
        /// Build the CMD_LOGIN_ON payload.
        /// Server expects UTF8 string with `:` fields:
        ///   userID:userName:userToken:roleRandToken:verSign:userIsAdult
        /// (6 fields minimum; 12 or 13 with extra session+server params).
        /// We send 6-field form for first login (no role yet).
        /// </summary>
        public static byte[] BuildLoginOnPayload(string account)
        {
            int randPwd = GetRandKey();
            string token = BuildToken(account, randPwd);
            // Use account as both userID and userName for dev (server treats them
            // distinctly but no separate username system in our pipeline).
            // userIsAdult: 1 (adult, no anti-addiction restrictions)
            string body = string.Format(
                "{0}:{1}:{2}:{3}:{4}:{5}",
                account, account, token, randPwd, VerSign, 1);
            return Encoding.UTF8.GetBytes(body);
        }

        // RC4 in-place — mirror of server's RC4Helper.RC4(byte[], byte[]).
        private static void RC4(byte[] data, byte[] key)
        {
            byte[] s = new byte[256];
            byte[] k = new byte[256];
            for (int i = 0; i < 256; i++)
            {
                s[i] = (byte)i;
                k[i] = key[i % key.Length];
            }
            int j = 0;
            for (int i = 0; i < 256; i++)
            {
                j = (j + s[i] + k[i]) % 256;
                (s[i], s[j]) = (s[j], s[i]);
            }
            int ii = 0, jj = 0;
            for (int x = 0; x < data.Length; x++)
            {
                ii = (ii + 1) % 256;
                jj = (jj + s[ii]) % 256;
                (s[ii], s[jj]) = (s[jj], s[ii]);
                int t = (s[ii] + s[jj]) % 256;
                data[x] ^= s[t];
            }
        }
    }
}
