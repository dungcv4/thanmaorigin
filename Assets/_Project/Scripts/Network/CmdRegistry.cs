// File: Assets/_Project/Scripts/Network/CmdRegistry.cs
// Bridge: Lua-side network CMD registration ↔ C# TCP socket.
// Source ref: KTO_LibClientScene_Decompiled (LuaServerRemoteCallEntry/Index + RegisterCmdHandler chain).
//
// Gốc Lua: `RegisterCmdHandler(CMD_X, function(packet) ... end)` registers handler.
//          `SendCMD(CMD_X, data)` sends packet to server.
//          `RemoteServer.<MethodName>(args)` calls server-side method.
//
// thanmaorigin: bridge to TMSKSocket TCP layer.
//
// Phase 10 — RemoteServer dispatch (2026-04-26):
//   gốc Lua RemoteServer.X(args) → libclient_scene.so LuaServerRemoteCallEntry
//     packs into a unified packet [methodName][args] sent via single CMD opcode.
//   thanmaorigin replicates: bind Lua global SendRemoteServerCall + bootstrap
//     a Lua metatable that catches `RemoteServer.X` lookups.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using XLua;

namespace ThanMaOrigin.Network
{
    public static class CmdRegistry
    {
        // Server-side: alo/GameServer_NET8/GameServer/Server/TCPCmdHandler.cs
        // CMD_REMOTE_SERVER_CALL = 50500 → KT_TCPHandler_RemoteServer.Dispatch (272 method stubs).
        public const int CMD_REMOTE_SERVER_CALL = 50500;

        // CMD opcode → Lua handler function
        private static readonly Dictionary<int, LuaFunction> _handlers = new Dictionary<int, LuaFunction>();

        // CMD opcode → C# handler (for systems that don't go through Lua, e.g. PlayerSpawner)
        private static readonly Dictionary<int, Action<byte[]>> _csHandlers = new Dictionary<int, Action<byte[]>>();

        /// <summary>
        /// Register C# handler for a CMD opcode. Called from C# subsystems (PlayerSpawner, etc.).
        /// </summary>
        public static void RegisterCSharpHandler(int cmdId, Action<byte[]> handler)
        {
            if (handler == null) { _csHandlers.Remove(cmdId); return; }
            _csHandlers[cmdId] = handler;
        }

        // Pending outbound packets (sent via TMSKSocket — see Phase 4)
        public static event Action<int, byte[]> OnSendCmd;

        /// <summary>
        /// Bind Lua globals + bootstrap RemoteServer metatable.
        /// Call once after LuaEngine init.
        /// </summary>
        public static void BindLua(LuaEnv env)
        {
            if (env == null) return;
            env.Global.Set<string, Action<int, object>>("SendCMD", SendCmd);
            env.Global.Set<string, Action<int, LuaFunction>>("RegisterCmdHandler", RegisterCmdHandler);
            env.Global.Set<string, Action<int>>("ClearCmdHandler", ClearCmdHandler);
            env.Global.Set<string, Action<string, object[]>>("SendRemoteServerCall", SendRemoteServerCall);

            // Bootstrap RemoteServer metatable so `RemoteServer.X(args)` dispatches via SendRemoteServerCall.
            // Cite: gốc libclient_scene.so LuaServerRemoteCallIndex (0x235bc8) creates a closure
            //   per method name on __index lookup; closure invocation calls LuaServerRemoteCallEntry.
            env.DoString(@"
                if not RemoteServer then
                    RemoteServer = setmetatable({}, {
                        __index = function(t, methodName)
                            local fn = function(...)
                                local args = {...}
                                SendRemoteServerCall(methodName, args)
                            end
                            rawset(t, methodName, fn)
                            return fn
                        end
                    })
                    print('[CmdRegistry] RemoteServer metatable bootstrapped')
                end
            ", "RemoteServer_Bootstrap");
        }

        /// <summary>
        /// Lua callable: send packet to server.
        /// </summary>
        public static void SendCmd(int cmdId, object data)
        {
            byte[] payload;
            if (data is byte[] b) payload = b;
            else if (data is string s) payload = System.Text.Encoding.UTF8.GetBytes(s);
            else payload = new byte[0];
            OnSendCmd?.Invoke(cmdId, payload);
        }

        /// <summary>
        /// Lua callable: register handler for inbound packet.
        /// </summary>
        public static void RegisterCmdHandler(int cmdId, LuaFunction handler)
        {
            if (handler == null) { ClearCmdHandler(cmdId); return; }
            // Replace existing
            if (_handlers.TryGetValue(cmdId, out var old)) old?.Dispose();
            _handlers[cmdId] = handler;
        }

        public static void ClearCmdHandler(int cmdId)
        {
            if (_handlers.TryGetValue(cmdId, out var fn))
            {
                fn?.Dispose();
                _handlers.Remove(cmdId);
            }
        }

        /// <summary>
        /// Lua callable: send a RemoteServer.X(args) call to server.
        /// Wire format: [4B Int32 LE methodNameLen][methodName UTF-8][args bytes].
        /// Server dispatches by methodName via KT_TCPHandler_RemoteServer.cs (272 cases).
        /// Cite: gốc libclient_scene.so LuaServerRemoteCallEntry (0x2359ec).
        /// </summary>
        public static void SendRemoteServerCall(string methodName, object[] args)
        {
            if (string.IsNullOrEmpty(methodName)) return;
            byte[] methodBytes = Encoding.UTF8.GetBytes(methodName);

            using var ms = new MemoryStream();
            using var bw = new BinaryWriter(ms);  // .NET BinaryWriter = LE on Unity platforms

            // Header: methodNameLen + methodName
            bw.Write(methodBytes.Length);          // Int32 LE
            bw.Write(methodBytes);                 // UTF-8 bytes

            // Args: serialize each (int/string/bool/byte[]/double matching gốc native binding)
            if (args != null)
            {
                foreach (var arg in args)
                {
                    SerializeArg(bw, arg);
                }
            }

            byte[] payload = ms.ToArray();
            OnSendCmd?.Invoke(CMD_REMOTE_SERVER_CALL, payload);
        }

        /// <summary>
        /// Serialize a Lua arg to bytes matching gốc native binding format.
        /// Cite: gốc LuaServerRemoteCallEntry packs Lua stack via lua_typeNNN dispatch.
        ///   - integer / number → Int32 LE (or Double LE for non-integer)
        ///   - string → [Int32 LE len][UTF-8 bytes]
        ///   - boolean → 1 byte (0 or 1)
        ///   - table → recursive (TODO Phase 11+)
        /// </summary>
        private static void SerializeArg(BinaryWriter bw, object arg)
        {
            switch (arg)
            {
                case null:
                    // gốc emits nothing for nil — preserve.
                    break;
                case int i: bw.Write(i); break;
                case long l: bw.Write(l); break;
                case uint u: bw.Write(u); break;
                case ulong ul: bw.Write(ul); break;
                case float f: bw.Write(f); break;
                case double d: bw.Write(d); break;
                case bool b: bw.Write((byte)(b ? 1 : 0)); break;
                case string s:
                    var sb = Encoding.UTF8.GetBytes(s);
                    bw.Write(sb.Length);
                    bw.Write(sb);
                    break;
                case byte[] data: bw.Write(data); break;
                case LuaTable tbl:
                    // TODO Phase 11+: recursive table serialization (gốc uses depth-first packed format).
                    // For now: emit empty marker (4-byte 0 length).
                    bw.Write(0);
                    Debug.LogWarning("[CmdRegistry.SerializeArg] LuaTable serialization not yet implemented (Phase 11+)");
                    break;
                default:
                    // Fallback: convert to string
                    var str = arg.ToString() ?? "";
                    var bytes = Encoding.UTF8.GetBytes(str);
                    bw.Write(bytes.Length);
                    bw.Write(bytes);
                    break;
            }
        }

        /// <summary>
        /// Called from TMSKSocket on packet receive. Dispatches to registered Lua handler.
        /// </summary>
        public static void OnPacketReceived(int cmdId, byte[] payload)
        {
            bool dispatched = false;
            // C# handler first (e.g. PlayerSpawner CMD 200)
            if (_csHandlers.TryGetValue(cmdId, out var csFn))
            {
                try { csFn(payload); dispatched = true; }
                catch (Exception e) { Debug.LogError($"[CmdRegistry] cs-handler {cmdId} error: {e.Message}"); }
            }
            // Lua handler (Lua-registered via RegisterCmdHandler)
            if (_handlers.TryGetValue(cmdId, out var fn) && fn != null)
            {
                try { fn.Call(payload); dispatched = true; }
                catch (Exception e) { Debug.LogError($"[CmdRegistry] lua-handler {cmdId} error: {e.Message}"); }
            }
            if (!dispatched)
            {
                Debug.LogWarning($"[CmdRegistry] No handler for CMD {cmdId} (payload {payload?.Length ?? 0} bytes)");
            }
        }

        public static void Reset()
        {
            foreach (var fn in _handlers.Values) fn?.Dispose();
            _handlers.Clear();
        }
    }
}
