// File: Assets/_Project/Scripts/Bootstrap/AppEntry.cs
//
// DEVIATION — bridge layer, NO 1-1 IL2CPP equivalent.
// Reason: gốc boot triggered by native code (libclient_scene.so / il2cpp.so initializer),
//         not by a C# MonoBehaviour. thanmaorigin needs an entry point to wire bridges +
//         load the gốc Lua boot script.
// Approved by user: 2026-04-26 (no-chế-cháo audit).
//
// Real boot logic lives in gốc `Script_Client.lua:34-63` (Client:OnStartup).
// AppEntry's ONLY job:
//   1. Init bridge layer (LuaEngine + NetworkManager — both DEVIATION ports)
//   2. Init Resources/Lua/ subsystem so require() works
//   3. DoString gốc boot: `require 'commonui.Script_Client'; Client:OnStartup()`
//   4. Hand off control to gốc Lua flow.
//
// Source ref: KiemTheOrigin_DeepExtract/39_CommonUI/Lua/Script_Client.lua
//   Client:OnStartup() does:
//     - LocalData:PathInit()
//     - Sdk:SetReferenceResolution(1280, 900)
//     - Client.QualityModule.SetLimitMissileCount(true)
//     - Client.CppModule.SetLogicUpdate(-1)
//     - Hotfix:DoPatch()
//     - Ui:InitGame()              ← registers OnMapLoaded subscriber
//     - LuaProfiler:BootStart()
//     - Login:OpenLoginScene()     ← opens gốc UILogin window
//     - EventNotify:RegistNotify(emNOTIFY_GAME_INIT_FINISH, ...)

using System.Collections;
using UnityEngine;
using ThanMaOrigin.Lua;
using ThanMaOrigin.Network;

namespace ThanMaOrigin.Bootstrap
{
    public class AppEntry : MonoBehaviour
    {
        IEnumerator Start()
        {
            Debug.Log("[thanmaorigin] === BOOT START ===");

            // 1. Bridge: XLua VM (DEVIATION — gốc native libclient_scene.so)
            EnsureChild<LuaEngine>("[LuaEngine]");
            yield return null;

            // 2. Bridge: TCP socket wrapper (DEVIATION) — instantiate but DO NOT auto-connect.
            // FIX 2026-04-27: gốc Lua flow connects only in Login:ConnectGateWay (Login.lua:374
            // calls global `ConnectGateway(szGatewayIP, nGatewayPort, szAccount, szAuthInfo)`).
            // Auto-connect on boot was chế cháo causing "Connect failed 127.0.0.1:11001" log spam.
            EnsureChild<NetworkManager>("[NetworkManager]");

            // 3. PlayerSyncHandler — registers CMD 200/204/206/210/220 handlers.
            // Must spawn BEFORE login completes so first emit-block (sent server-side
            // immediately after CMD_PLAY_GAME ack) doesn't race ahead of registration.
            // PORT 2026-05-02 (replaces missing PlayerDataSyncHandler).
            EnsureChild<PlayerSyncHandler>("[PlayerSyncHandler]");

            // 4. Hand off to gốc Lua boot.
            //    DoString triggers Script_Client.lua:Client:OnStartup() which drives
            //    everything else (UI init, login scene, event registration).
            //
            // DEVIATION (cited per "no creativity" rule):
            //   gốc native libclient_scene.so binds `Client` table + `luanet.*` namespace
            //   via luanet_gettag/luanet_tonetobject/etc. (vma 0x289c20-0x289f40 per
            //   KTO_LibClientScene_Decompiled/INDEX.tsv). Higher-level
            //   `luanet.import_type(name)` is the NLua API for resolving .NET types by name.
            //   thanmaorigin uses XLua (NOT NLua), where the equivalent access is `CS[name]`.
            //   Bridge below provides the exact 1-1 mapping — no namespace heuristics added.
            //   All gốc C# types referenced by Script_Client.lua are top-level (no namespace),
            //   so `CS[name]` is sufficient.
            //   Approved: 2026-04-26 (no chế cháo audit).
            Debug.Log("[thanmaorigin] Loading gốc Lua boot (Script_Client) ...");
            try
            {
                var env = LuaEngine.Instance.Env;
                env.DoString(@"
                    -- Bootstrap globals (gốc native sets these before Script_Client runs)
                    Client = Client or {}
                    luanet = luanet or {}
                    if not luanet.import_type then
                        -- 1-1 bridge to XLua's CS table
                        luanet.import_type = function(typeName) return CS[typeName] end
                    end

                    local ok, err = pcall(function()
                        if not (Client and Client.OnStartup) then
                            require('commonui.Script_Client')
                        end
                        if Client and Client.OnStartup then
                            Client:OnStartup()
                        else
                            print('[AppEntry] Client.OnStartup not found after require')
                        end
                    end)
                    if not ok then print('[AppEntry] boot error: ' .. tostring(err)) end
                ");
            }
            catch (System.Exception e)
            {
                Debug.LogError($"[thanmaorigin] Lua boot failed: {e.Message}");
            }

            Debug.Log("[thanmaorigin] === BOOT HANDED OFF TO GỐC LUA ===");
        }

        private static T EnsureChild<T>(string name) where T : Component
        {
            var existing = FindObjectOfType<T>();
            if (existing != null) return existing;
            var go = new GameObject(name);
            DontDestroyOnLoad(go);
            return go.AddComponent<T>();
        }
    }
}
