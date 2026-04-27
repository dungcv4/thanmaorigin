# Server Architecture — ThanMaOrigin Login & Game Pipeline

**Last updated**: 2026-04-27 (Day 9.16)
**Status**: Login chain working end-to-end. Reaches UICreateRole.

---

## Overview — 4 servers, 1 client

```
┌────────────────────┐
│  Unity Client      │
│  (XLua + C#)       │
└────────┬───────────┘
         │
         ├───────HTTP (port 8887)──────────────► sdk_server.py (Python)
         │                                       └─ MySQL or local_state.json
         │
         ├───────TCP raw (port 3000)───────────► gateway_server.py (Python)
         │                                       └─ Stateless emulator
         │
         └───────TCP framed (port 3001)────────► GameServer.dll (.NET 8)
                                                 │
                                                 └──TCP─► GameDBServer.dll (.NET 8, port 23001)
                                                             │
                                                             └─► MySQL (AWS RDS)
```

---

## 1. SDK Server — `alo/sdk_server/server.py`

**Role**: Web auth + account database. Replaces legacy ASP.NET WebForms `KIEMTHESDK`.

**Tech**: Python 3 + `http.server` + `pymysql`. Port **8887** (default).

**Storage**:
- Production: MySQL (`block299.cvwyksq4k1z4.us-east-1.rds.amazonaws.com:3306/kiemthe_sdk`)
- Dev fallback: `sdk_server/local_state.json` (set `SDK_FORCE_LOCAL_STATE=1`)

**Endpoints used by login**:
| Endpoint | Verb | Form Fields | Reply (protobuf) |
|---|---|---|---|
| `/loginsdk.aspx` | POST | `UserName`, `Password`, `LoginType` | `error_code`, `error_msg`, `access_token` |
| `/verifyaccount.aspx` | POST | proto: field 1 = `access_token` | `platform_user_id`, `account_name`, `l_time` (int64), `cm`, `sign_token` |
| `/getserverlist.aspx` | GET/POST | `strUID`, `AccessToken` | `ServerList` proto array |
| `/registersdk.aspx` | POST | `UserName`, `Password`, `Email`, `PhoneNumber` | `error_code`, `error_msg` |

**`sign_token` formula** (used by GameServer for auth):
```
sign_token = MD5(platform_user_id + account_name + l_time + "1" + WEB_KEY)
WEB_KEY = "9377(*)#mst9"
platform_user_id = "{ID}_{LoginName}"  e.g. "3_testuser"
```

**Run**:
```bash
cd /Users/vsf-user-l/Documents/Test/alo
SDK_FORCE_LOCAL_STATE=1 python3 sdk_server/server.py --no-init-db
```

**Test accounts** (in `local_state.json`):
- `testuser` / `12345678` (ID=3)
- `sdksmoke01` / `Password01` (ID=1)

---

## 2. Gateway Server — `alo/gateway_server/`

**Role**: Stand-in for Tencent's Gateway tier (we don't have the original). Handles:
1. Initial handshake with client
2. Server-list query (which game zones to connect to)
3. Login-server query (where the world server is)

**Tech**: Python 3 + asyncio. Port **3000**.

**Wire format** (raw bytes, NO TMSK framing):
```
Per-message: [byte opcode][payload]
Where payload size depends on opcode (no length prefix).
```

**Opcodes**:
| ID | Name | Direction | Body |
|---|---|---|---|
| `0x01` | REQ_HANDSHAKE | C→S | int32 var_x + char[0x50] account + uint8 osType + char[N] account_tail |
| `0x80` | RSP_HANDSHAKE | S→C | int32 retCode + int32 nShowAgreement |
| `0x02` | REQ_GET_SERVER_LIST | C→S | (empty) |
| `0x81` | RSP_GET_SERVER_LIST | S→C | uint16 count + N × ServerEntry |
| `0x03` | REQ_LOGIN_SERVER | C→S | int32 server_id |
| `0x82` | RSP_LOGIN_SERVER | S→C | uint16 addr_len + addr + int32 port |
| `0xFF` | RSP_ERROR | S→C | int32 error_code + uint16 msg_len + msg |

**Reference**: REQUEST format 1-1 with gốc `XGatewayClient::DoHandshakeRequest @0x233dc0`. RESPONSE format custom (gốc parsers `OnHandshakeRespond` etc. are XOR-encrypted in `libclient_scene.so` — entropy 6.94+, can't decode).

**Config**: `gateway_server/config.json` — server list maps to GameServer `127.0.0.1:3001`.

**Run**:
```bash
cd /Users/vsf-user-l/Documents/Test/alo
python3 gateway_server/gateway_server.py
```

---

## 3. GameServer — `alo/GameServer_NET8/GameServer/`

**Role**: Main game logic server. Receives all CMD_* packets from client.

**Tech**: .NET 8 console app. Port **3001**.

**Wire format** (TMSK protocol):

**Inbound** (client → server):
```
[4B Int32 LE size_field][2B UInt16 LE cmdId][1B crc][4B Int32 LE checkTicks][payload]
  size_field = 1 + 4 + payload.Length + 2  (includes anti-cheat prefix + cmdId)
  crc        = (CRC32(body[1..end]) % 255) ^ (cmdId % 255)
  checkTicks = monotonic counter (anti-replay)
```
Verified by `TCPManager.CheckClientDataValid()` — rejects on CRC mismatch or non-monotonic ticks.

**Outbound** (server → client):
```
[4B Int32 LE size_field][2B UInt16 LE cmdId][raw payload]
  size_field = payload.Length + 2  (includes cmdId, NO anti-cheat prefix)
```
**ASYMMETRIC** — outbound has no CRC/ticks. Cite `TCPOutPacket.Final()`.

**CMD opcodes used in login chain**:
| ID | Name | Body (UTF-8 colon-separated) |
|---|---|---|
| `20` | CMD_LOGIN_ON2 | `verSign:platform_uid:account_name:l_time:isadult:sign_token` |
| `100` | CMD_LOGIN_ON | `userID:userName:userToken:roleRandToken:verSign:userIsAdult` |
| `101` | CMD_ROLE_LIST | `userID:zoneID` |

**Login sequence (3 steps after TCP connect)**:
```
1. Client → CMD_LOGIN_ON2 (web SDK auth)
   Server validates: MD5(parts + WEB_KEY) == sign_token
   Server replies: "userID:userName:userToken:isadult"  (4 fields)

2. Client → CMD_LOGIN_ON (session register)
   Reuses userToken from step 1.
   Server validates RC4+SHA1 token via UserLoginToken.SetEncryptString.
   Server calls OnlineUserSession.AddSession.
   Server replies: "RandKey:WaitSecs"

3. Client → CMD_ROLE_LIST (fetch roles)
   Server forwards to GameDBServer (port 23001) via Global.TransferRequestToDBServer.
   Server replies: role data (or "0:" if empty).
```

**Config**:
- `GameServer/bin/Debug/net10.0/AppConfig.xml` — port, MySQL, KeySHA1, KeyData, WebKey
- `GameServer/bin/Debug/net10.0/GMList.xml` — GM whitelist
  - Dev: `<GM RoleID="*" IP="*" />` enables IP-wide GM bypass (whitelist + token-time-expiry)

**Build & run**:
```bash
cd /Users/vsf-user-l/Documents/Test/alo/GameServer_NET8/GameServer && dotnet build
cd bin/Debug/net10.0 && dotnet GameServer.dll
```

**Boot ~30s** (loads ~140 maps).

---

## 4. GameDBServer — `alo/GameServer_NET8/GameDBServer/`

**Role**: Database access layer. GameServer forwards all DB queries here.

**Tech**: .NET 8 console app. Port **23001**.

**Backend**: MySQL on AWS RDS (`block299.cvwyksq4k1z4.us-east-1.rds.amazonaws.com:3306`).

**Used by**:
- CMD_ROLE_LIST: fetch roles for an account
- CMD_CREATE_ROLE: persist new character
- All in-game DB writes (item drops, exp, gold, etc.)

**Run**: same dotnet pattern. Started before GameServer.

---

## Client Architecture (`alo/thanmaorigin/Assets/_Project/Scripts/`)

### Network layer
| File | Role |
|---|---|
| `Network/SdkHttpClient.cs` | HTTP client for sdk_server (login + verify) — uses `System.Net.Http.HttpClient` |
| `Network/GatewaySocket.cs` | Raw-byte TCP for gateway port 3000 |
| `Network/GatewayProtocol.cs` | Opcode constants + packet builders/parsers |
| `Network/GatewayHandshake.cs` | Gateway state machine: connect → handshake → server-list → login-server |
| `Network/TMSKSocket.cs` | TMSK-framed TCP for GameServer port 3001 (CRC + ticks anti-cheat on send) |
| `Network/Crc32.cs` | CRC-32 IEEE polynomial 0xEDB88320, 1-1 with server `CRC32.cs` |
| `Network/LoginTokenHelper.cs` | UserLoginToken builder (RC4+SHA1) — used for CMD_LOGIN_ON token format. NOTE: SDK auth path now uses `SdkHttpClient.SignToken`, not this. |
| `Network/CmdRegistry.cs` | CMD opcode dispatcher (Lua + C# handlers) |
| `Network/NetworkManager.cs` | MonoBehaviour singleton orchestrating all 3 sockets + Lua bridge |

### Lua bridge layer
| File | Role |
|---|---|
| `Lua/LuaEngine.cs` | XLua singleton hosting Lua VM + binds Lua globals (`ConnectGateway`, `ConnectServer`, `GetServerList`, `GetRoleList`, `MathRandom`, `GetZoneTimeSecDiff`, etc.) |
| `Lua/LuaEventBridge.cs` | Fire `EventNotify.OnNotify(eventId, args)` from C# |
| `Lua/UnityObjAlive.cs` | Helper: triggers Unity's `Object == null` overload to detect destroyed objects from Lua |
| `Lua/Native/KGlobalLua.cs` | Native bindings for Lua globals (`ConnectGateway`, etc.) |

---

## Full Login Flow (current state, Day 9.16)

```
┌──────────────────────────────────────────────────────────────────────────────┐
│  1. UI: User types account in UILoginChannelInner.imgAccount.inputAccount    │
│     (Password input not yet wired — DEV uses hard-coded "12345678")          │
└──────────────────────────────────────────────────────────────────────────────┘
                                    │ click btnEnterGame
                                    ▼
┌──────────────────────────────────────────────────────────────────────────────┐
│  2. Lua: Login:InitAndConnectGateWay(account, "")                            │
│     → ConnectGateway(ip=127.0.0.1, port=3000, account, "")                   │
└──────────────────────────────────────────────────────────────────────────────┘
                                    │
                                    ▼
┌──────────────────────────────────────────────────────────────────────────────┐
│  3. C# NetworkManager.ConnectGateway → GatewayHandshake.SendRequest          │
│     → GatewaySocket.Connect(127.0.0.1:3000)                                   │
│     → SendRaw(REQ_HANDSHAKE packet)                                          │
└──────────────────────────────────────────────────────────────────────────────┘
                                    │
                                    ▼
┌──────────────────────────────────────────────────────────────────────────────┐
│  4. Python gateway_server: parse handshake → reply RSP_HANDSHAKE(ret=0)      │
└──────────────────────────────────────────────────────────────────────────────┘
                                    │
                                    ▼
┌──────────────────────────────────────────────────────────────────────────────┐
│  5. C# GatewayHandshake.DispatchResponse:                                    │
│     - Fire emNOTIFY_GATEWAY_HANDED(0,0)                                      │
│     - Direct call: Ui.tbClass.UILoginChannelInner:GatewayHandSuccess(0,0)    │
│     → Lua opens UILoginServer                                                │
└──────────────────────────────────────────────────────────────────────────────┘
                                    │
                                    ▼
┌──────────────────────────────────────────────────────────────────────────────┐
│  6. Lua UILoginServer.OnOpen → RequestServerList()                           │
│     → REQ_GET_SERVER_LIST → reply with ["Thiên Mã - Phong" → 127.0.0.1:3001] │
│     → Lua __UpdateSerInfo populates UI panel                                 │
└──────────────────────────────────────────────────────────────────────────────┘
                                    │ click btnLoginServer "Vào giang hồ"
                                    ▼
┌──────────────────────────────────────────────────────────────────────────────┐
│  7. Lua: ConnectServer(serverId=1) → REQ_LOGIN_SERVER                        │
│     → reply RSP_LOGIN_SERVER(addr=127.0.0.1, port=3001)                      │
│     → Login:LoginServerRsp → ConnectWorldServer(127.0.0.1, 3001)             │
└──────────────────────────────────────────────────────────────────────────────┘
                                    │
                                    ▼
┌──────────────────────────────────────────────────────────────────────────────┐
│  8. C# NetworkManager.ConnectWorldServer:                                    │
│     - TMSKSocket.Connect(127.0.0.1:3001)                                      │
│     - StartCoroutine(DoSdkLoginCoroutine)                                    │
└──────────────────────────────────────────────────────────────────────────────┘
                                    │
                                    ▼
┌──────────────────────────────────────────────────────────────────────────────┐
│  9. C# DoSdkLoginCoroutine → SdkHttpClient.LoginAndVerifyAsync               │
│     a) POST /loginsdk.aspx → access_token                                    │
│     b) POST /verifyaccount.aspx → platform_uid="3_testuser", sign_token      │
│     c) Build CMD_LOGIN_ON2 body → TMSKSocket.Send(20, body)                  │
└──────────────────────────────────────────────────────────────────────────────┘
                                    │
                                    ▼
┌──────────────────────────────────────────────────────────────────────────────┐
│ 10. GameServer ProcessUserLogin2Cmd:                                          │
│     - Validate sign_token == MD5(parts + WEB_KEY)                            │
│     - Generate new userToken via UserLoginToken.GetEncryptString             │
│     - Reply: "userID:userName:userToken:isadult"                             │
└──────────────────────────────────────────────────────────────────────────────┘
                                    │
                                    ▼
┌──────────────────────────────────────────────────────────────────────────────┐
│ 11. C# OnLoginOn2Reply → CMD_LOGIN_ON (id=100) with returned userToken       │
└──────────────────────────────────────────────────────────────────────────────┘
                                    │
                                    ▼
┌──────────────────────────────────────────────────────────────────────────────┐
│ 12. GameServer ProcessUserLoginCmd:                                           │
│     - Validate userToken via UserLoginToken.SetEncryptString                 │
│     - OnlineUserSession.AddSession(socket, userID)                           │
│     - GameDb.RegisterUserIDToDBServer (forward to DB)                        │
│     - Reply: "RandKey:WaitSecs"                                              │
└──────────────────────────────────────────────────────────────────────────────┘
                                    │
                                    ▼
┌──────────────────────────────────────────────────────────────────────────────┐
│ 13. C# OnLoginOnReply → CMD_ROLE_LIST (id=101) "userID:zoneID"               │
└──────────────────────────────────────────────────────────────────────────────┘
                                    │
                                    ▼
┌──────────────────────────────────────────────────────────────────────────────┐
│ 14. GameServer ProcessGetRoleListCmd → forward to GameDBServer:23001         │
│     → GameDBServer queries MySQL (or local) → returns role data              │
│     → reply: "0:" (empty list for new account) OR role array                  │
└──────────────────────────────────────────────────────────────────────────────┘
                                    │
                                    ▼
┌──────────────────────────────────────────────────────────────────────────────┐
│ 15. C# OnRoleListReply → Lua Login:OnSyncRoleListDone                        │
│     → Login:OnRoleListDoneAndMapLoaded                                       │
│     → If 0 roles: Ui:OpenWindow("UICreateRole")                              │
│     → Else: Ui:OpenWindow("UISelectRoleExist")                               │
└──────────────────────────────────────────────────────────────────────────────┘
```

---

## Quick start (full pipeline)

```bash
# 1. Start SDK server (port 8887)
cd /Users/vsf-user-l/Documents/Test/alo
SDK_FORCE_LOCAL_STATE=1 nohup python3 sdk_server/server.py --no-init-db > /tmp/sdk_server.log 2>&1 &

# 2. Start gateway server (port 3000)
nohup python3 gateway_server/gateway_server.py > /tmp/gateway.log 2>&1 &

# 3. Start GameDBServer (port 23001) — runs separately
cd GameServer_NET8/GameDBServer/bin/Debug/net10.0 && nohup dotnet GameDBServer.dll > /tmp/gamedb.log 2>&1 &

# 4. Start GameServer (port 3001) — boot ~30s
cd /Users/vsf-user-l/Documents/Test/alo/GameServer_NET8/GameServer/bin/Debug/net10.0 && nohup dotnet GameServer.dll > /tmp/gameserver.log 2>&1 &

# Wait until ready:
until nc -z 127.0.0.1 3001 2>/dev/null; do sleep 2; done

# 5. Open Unity, hit Play, click "Đăng nhập"
```

---

## Open follow-ups

1. **UICreateRole render error** — line 346 `tbElement` nil. Needs faction template + default avatar list helpers.
2. **Password input UI** — UILoginChannelInner only has `inputAccount`. Needs to add `inputPassword` field OR switch to UILoginChannelSDK with custom password dialog.
3. **Encrypted Gateway response parsers** — gốc `OnHandshakeRespond/OnLoginServerRespond/OnGetServerListRespond` are XOR-encrypted in `libclient_scene.so`. Custom protocol used instead.
4. **Native libclient_scene.so handshake** — we replaced the gốc XGatewayClient native call chain with C# `GatewayHandshake` + Python gateway. If we ever obtain the gateway server binary, we can drop our emulator.

---

## DEV-mode deviations from gốc (security hits)

| Setting | Gốc | Dev | File |
|---|---|---|---|
| GMList | only specific roleIDs | `<GM RoleID="*" IP="*" />` (all GM) | `GameServer/bin/Debug/net10.0/GMList.xml` |
| Password input | user types | hard-coded `"12345678"` | `NetworkManager.DoSdkLoginCoroutine` |
| SDK URL | https + cert | `http://127.0.0.1:8887` | `SdkHttpClient.ServerUrl` |
| Gateway response parsers | encrypted native | custom Python protocol | `gateway_server/protocol.py` |

Production checklist (when porting to prod):
- [ ] Restore `GMList.xml` to specific role IDs
- [ ] Wire real password input UI (UILoginChannelInner adds `inputPassword`)
- [ ] Move SDK to HTTPS + valid cert
- [ ] Remove gateway emulator (use real Tencent gateway binary if available)
