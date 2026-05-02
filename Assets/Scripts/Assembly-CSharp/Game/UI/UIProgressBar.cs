// gốc: KTO_Resources/il2cpp_full_dump/dump.cs (TypeDefIndex 1602)
//      KTO_DecompiledReference/_root/UIProgressBar.c
//
// 10 methods + MAX_PROCESS const. All bodies empty in gốc IL2CPP
// (RVAs 0x1B29688..0x1B29BB1 — short stubs, real logic was in Lua via funcOnFinish).
// gốc namespace lowercase "Game.Ui" (preserved).
//
// PORT 2026-05-02: replace AR Cpp2IL dummy stub. Field layout matches dump.cs.

using UnityEngine;
using UnityEngine.UI;
using XLua;

namespace Game.Ui
{
    public class UIProgressBar : MonoBehaviour
    {
        private const int MAX_PROCESS = 10000;

        // Fields (matches dump.cs offsets 0x20..0x70)
        public float fSpeed;
        public int nCurrentPercent;
        public int nTargetPercent;
        private float fFillAmount;
        public Component foregroundImg;
        public Component labelPercent;
        public Component labelTitle;
        private bool bProcessing;
        private LuaTable tablePb;
        private LuaFunction funcOnFinish;
        private Text titleText;
        private Text percentText;
        private Image mask;

        // gốc methods — empty bodies (logic driven by Lua via tablePb / funcOnFinish)
        private void Awake() { }
        private void Update() { }
        private void SetProgress(float fFillAmount, bool bNeedCheckTextIsChange) { }
        public int SetTarget(int inTarget) { return 0; }
        public float SetSpeed(float inSpeed) { return 0f; }
        public void SetTitle(string szTitle) { }
        public int GetCurrentProcess() { return 0; }
        public int GetMaxProcess() { return MAX_PROCESS; }
        public void Init() { }
    }
}
