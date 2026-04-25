// File: Assets/_Project/Scripts/Network/CmdRegistry.cs
// Bridge: Lua-side network CMD registration ↔ C# TCP socket.
// Source ref: KTO_LibClientScene_Decompiled (LuaServerRemoteCallEntry/Index + RegisterCmdHandler chain).
//
// Gốc Lua: `RegisterCmdHandler(CMD_X, function(packet) ... end)` registers handler.
//          `SendCMD(CMD_X, data)` sends packet to server.
// thanmaorigin: bridge to TMSKSocket TCP layer.

using System;
using System.Collections.Generic;
using UnityEngine;
using XLua;

namespace ThanMaOrigin.Network
{
    public static class CmdRegistry
    {
        // CMD opcode → Lua handler function
        private static readonly Dictionary<int, LuaFunction> _handlers = new Dictionary<int, LuaFunction>();

        // Pending outbound packets (sent via TMSKSocket — see Phase 4)
        public static event Action<int, byte[]> OnSendCmd;

        /// <summary>
        /// Bind Lua globals: SendCMD, RegisterCmdHandler, ClearCmdHandler.
        /// Call once after LuaEngine init.
        /// </summary>
        public static void BindLua(LuaEnv env)
        {
            if (env == null) return;
            env.Global.Set<string, Action<int, object>>("SendCMD", SendCmd);
            env.Global.Set<string, Action<int, LuaFunction>>("RegisterCmdHandler", RegisterCmdHandler);
            env.Global.Set<string, Action<int>>("ClearCmdHandler", ClearCmdHandler);
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
        /// Called from TMSKSocket on packet receive. Dispatches to registered Lua handler.
        /// </summary>
        public static void OnPacketReceived(int cmdId, byte[] payload)
        {
            if (_handlers.TryGetValue(cmdId, out var fn) && fn != null)
            {
                try { fn.Call(payload); }
                catch (Exception e) { Debug.LogError($"[CmdRegistry] handler {cmdId} error: {e.Message}"); }
            }
            else
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
