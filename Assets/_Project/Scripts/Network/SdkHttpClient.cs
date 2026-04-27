// File: Assets/_Project/Scripts/Network/SdkHttpClient.cs
//
// HTTP client for the Python SDK server (`alo/sdk_server/server.py`).
// Implements 2 endpoints used by login flow:
//   POST /loginsdk.aspx       (UserName, Password, LoginType) → access_token
//   POST /verifyaccount.aspx  (proto: access_token)            → platform_user_id, account_name, sign_token, l_time
//
// Reference: KiemTheOrigin_DeepExtract/01_Login/Scripts/LoginSceneUI.cs DoSdkLogin
// (legacy KiemTheUI implementation that already does this flow).
//
// Result is then fed into CMD_LOGIN_ON2 (id=20) packet sent to GameServer:3001.
// CMD_LOGIN_ON2 expects: "verSign:platform_user_id:account_name:l_time:isadult:sign_token"
//   sign_token = MD5(platform_user_id + account_name + l_time + isadult + WEB_KEY)
//   WEB_KEY = "9377(*)#mst9" (must match SDK server WEB_KEY).
//
// gốc UILoginChannelSDK calls Sdk:Login → native SDK opens platform OAuth
// (Tencent OAuth, Google, etc.). DEVIATION: thanmaorigin replaces native SDK
// with HTTP call to Python SDK server (faithful to KiemTheOrigin_DeepExtract).

using System;
using System.Collections;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ThanMaOrigin.Network
{
    public static class SdkHttpClient
    {
        // Default URL — points to local Python SDK server.
        // Override via SetServerUrl if needed.
        public static string ServerUrl = "http://127.0.0.1:8887";

        private static HttpClient _http = new HttpClient { Timeout = TimeSpan.FromSeconds(10) };

        public class LoginResult
        {
            public bool Success;
            public int ErrorCode;
            public string ErrorMsg = "";
            public string AccessToken = "";
            // Filled by VerifyAccount (after Login):
            public string PlatformUserId = "";
            public string AccountName = "";
            public string SignToken = "";
            public long LTime;
        }

        /// <summary>
        /// Run full SDK auth chain (login + verify) async. Returns LoginResult with all fields.
        /// Must be called from a coroutine via UnityEngine task awaiter (use TaskAwaiter).
        /// </summary>
        public static async Task<LoginResult> LoginAndVerifyAsync(string username, string password)
        {
            var result = new LoginResult();
            try
            {
                // 1. POST /loginsdk.aspx
                var form = new System.Collections.Generic.Dictionary<string, string>
                {
                    {"UserName", username},
                    {"Password", password},
                    {"LoginType", "0"},
                };
                var content = new FormUrlEncodedContent(form);
                Debug.Log($"[SdkHttpClient] POST {ServerUrl}/loginsdk.aspx user={username}");
                var resp = await _http.PostAsync($"{ServerUrl}/loginsdk.aspx", content);
                byte[] data = await resp.Content.ReadAsByteArrayAsync();

                ParseLoginResponse(data, out int code, out string msg, out string token);
                Debug.Log($"[SdkHttpClient] Login response: code={code} msg='{msg}' token='{token}'");
                result.ErrorCode = code;
                result.ErrorMsg = msg;
                result.AccessToken = token;
                if (code != 0 || string.IsNullOrEmpty(token))
                {
                    return result;
                }

                // 2. POST /verifyaccount.aspx (proto body: field 1 = access_token)
                byte[] verifyBody = BuildVerifyRequest(token);
                var verifyContent = new ByteArrayContent(verifyBody);
                verifyContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");
                Debug.Log($"[SdkHttpClient] POST {ServerUrl}/verifyaccount.aspx token={token}");
                var verifyResp = await _http.PostAsync($"{ServerUrl}/verifyaccount.aspx", verifyContent);
                byte[] verifyData = await verifyResp.Content.ReadAsByteArrayAsync();

                ParseVerifyResponse(verifyData, out string platformUid, out string accountName, out string cm, out string signToken, out long lTime);
                Debug.Log($"[SdkHttpClient] Verify response: platform_uid='{platformUid}' name='{accountName}' cm='{cm}' sign_token='{signToken}' l_time={lTime}");
                result.PlatformUserId = platformUid;
                result.AccountName = accountName;
                result.SignToken = signToken;
                result.LTime = lTime;
                result.Success = !string.IsNullOrEmpty(platformUid) && platformUid != "-1" && platformUid != "-10";
                if (!result.Success)
                {
                    result.ErrorCode = -100;
                    result.ErrorMsg = $"verify rejected (platform_uid={platformUid})";
                }
                return result;
            }
            catch (Exception e)
            {
                Debug.LogError($"[SdkHttpClient] LoginAndVerify exception: {e.Message}");
                result.ErrorCode = -200;
                result.ErrorMsg = e.Message;
                return result;
            }
        }

        // ── Protobuf helpers (matches sdk_server/server.py serialize_* / parse_*) ──

        private static byte[] BuildVerifyRequest(string accessToken)
        {
            // VerifyAccount request: field 1 = access_token (string, wire type 2)
            using var ms = new System.IO.MemoryStream();
            WriteString(ms, 1, accessToken);
            return ms.ToArray();
        }

        // serialize_login_rep: field 1=int(error_code), field 2=string(error_msg), field 3=string(access_token)
        public static void ParseLoginResponse(byte[] data, out int errorCode, out string errorMsg, out string accessToken)
        {
            errorCode = 0; errorMsg = ""; accessToken = "";
            if (data == null || data.Length == 0) return;
            int offset = 0;
            while (offset < data.Length)
            {
                long tag = ReadVarint(data, ref offset);
                int fieldNumber = (int)(tag >> 3);
                int wireType = (int)(tag & 7);
                if (wireType == 0)
                {
                    long val = ReadVarint(data, ref offset);
                    if (fieldNumber == 1) errorCode = (int)val;
                }
                else if (wireType == 2)
                {
                    int len = (int)ReadVarint(data, ref offset);
                    string s = Encoding.UTF8.GetString(data, offset, len);
                    offset += len;
                    if (fieldNumber == 2) errorMsg = s;
                    else if (fieldNumber == 3) accessToken = s;
                }
                else { break; } // unsupported wire type
            }
        }

        // serialize_verify_account (sdk_server/server.py:295):
        //   field 1=string(platform_user_id), 2=string(account_name),
        //   field 3=int64(l_time), 4=string(cm), 5=string(token=sign_token)
        public static void ParseVerifyResponse(byte[] data, out string platformUid, out string accountName,
                                               out string cm, out string signToken, out long lTime)
        {
            platformUid = ""; accountName = ""; cm = ""; signToken = ""; lTime = 0;
            if (data == null || data.Length == 0) return;
            int offset = 0;
            while (offset < data.Length)
            {
                long tag = ReadVarint(data, ref offset);
                int fieldNumber = (int)(tag >> 3);
                int wireType = (int)(tag & 7);
                if (wireType == 0)
                {
                    long val = ReadVarint(data, ref offset);
                    if (fieldNumber == 3) lTime = val;
                }
                else if (wireType == 2)
                {
                    int len = (int)ReadVarint(data, ref offset);
                    string s = Encoding.UTF8.GetString(data, offset, len);
                    offset += len;
                    if (fieldNumber == 1) platformUid = s;
                    else if (fieldNumber == 2) accountName = s;
                    else if (fieldNumber == 4) cm = s;
                    else if (fieldNumber == 5) signToken = s;
                }
                else { break; }
            }
        }

        private static void WriteString(System.IO.MemoryStream ms, int fieldNumber, string s)
        {
            byte[] sBytes = Encoding.UTF8.GetBytes(s ?? "");
            WriteVarint(ms, ((uint)fieldNumber << 3) | 2);
            WriteVarint(ms, (uint)sBytes.Length);
            ms.Write(sBytes, 0, sBytes.Length);
        }

        private static void WriteVarint(System.IO.MemoryStream ms, ulong value)
        {
            while (value >= 0x80) { ms.WriteByte((byte)((value & 0x7F) | 0x80)); value >>= 7; }
            ms.WriteByte((byte)value);
        }

        private static long ReadVarint(byte[] data, ref int offset)
        {
            long val = 0; int shift = 0;
            while (offset < data.Length)
            {
                byte b = data[offset++];
                val |= (long)(b & 0x7F) << shift;
                if ((b & 0x80) == 0) break;
                shift += 7;
                if (shift > 63) break;
            }
            return val;
        }
    }
}
