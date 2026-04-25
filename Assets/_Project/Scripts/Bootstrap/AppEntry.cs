// File: Assets/_Project/Scripts/Bootstrap/AppEntry.cs
// Boot orchestrator — replicates gốc Client:OnStartup chain (Script_Client.lua:34-63).

using System.Collections;
using UnityEngine;
using ThanMaOrigin.Lua;
using ThanMaOrigin.Network;
using ThanMaOrigin.Resource;

namespace ThanMaOrigin.Bootstrap
{
    public class AppEntry : MonoBehaviour
    {
        IEnumerator Start()
        {
            Debug.Log("[thanmaorigin] === BOOT START ===");

            // 1. Init LuaEngine (XLua VM + bridges)
            EnsureChild<LuaEngine>("[LuaEngine]");
            yield return null; // wait one frame for Awake

            // 2. Init NetworkManager (TCP socket wrapper)
            var net = EnsureChild<NetworkManager>("[NetworkManager]");

            Debug.Log("[thanmaorigin] Phase 1 boot — local APK manifest");
            string? localManifest = null;
            yield return KKUpdater.ReadLocalManifest(m => localManifest = m);
            Debug.Log($"[thanmaorigin]   local manifest: {(localManifest == null ? "MISSING" : $"{localManifest.Length} bytes")}");

            Debug.Log("[thanmaorigin] Phase 2 — remote manifest fetch (LocalCDN)");
            string? remoteManifest = null;
            yield return KKUpdater.GetRemotePatchFileList(m => remoteManifest = m);
            if (remoteManifest != null && localManifest != null)
            {
                bool needPatch = KKUpdater.NeedPatch(localManifest, remoteManifest);
                Debug.Log($"[thanmaorigin]   needPatch={needPatch}");
                // Phase 5+ wire actual bundle download here.
            }

            Debug.Log("[thanmaorigin] Connecting to GameServer...");
            bool connected = net.Connect();
            Debug.Log($"[thanmaorigin]   GameServer connected: {connected}");

            if (connected)
            {
                Debug.Log("[thanmaorigin] Sending CMD 100 Login...");
                CmdRegistry.SendCmd(100, System.Text.Encoding.UTF8.GetBytes("test_account"));
                // Server replies CMD 102 RoleList (empty stub) — handled by registered Lua handler.
            }

            Debug.Log("[thanmaorigin] === BOOT COMPLETE ===");
            // Phase 5.4+ open UILogin via Ui:OpenWindow when Lua scripts are loaded.
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
