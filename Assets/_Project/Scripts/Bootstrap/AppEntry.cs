// thanmaorigin — App entry point
// Phase 1 stub. Phase 3+ will wire LuaEngine + NetworkManager + ResourceModule.
// Source ref (Phase 3 port): KiemTheOrigin_DeepExtract/_shared/Script_Client.lua
// + KTO_DecompiledReference/_root/Client.c (Client:OnStartup at 0x???)

using UnityEngine;

namespace ThanMaOrigin.Bootstrap
{
    public class AppEntry : MonoBehaviour
    {
        void Awake()
        {
            Debug.Log("[thanmaorigin] AppEntry.Awake — boot started");
            // TODO Phase 3: LuaEngine.InitializeLua();
            // TODO Phase 3: NetworkManager.Instance.Init();
            // TODO Phase 3: ResourceModule.Instance.Init();
            // TODO Phase 5: Ui.OpenWindow("UILogin");
        }

        void Start()
        {
            Debug.Log("[thanmaorigin] AppEntry.Start — Phase 1 boot complete");
        }
    }
}
