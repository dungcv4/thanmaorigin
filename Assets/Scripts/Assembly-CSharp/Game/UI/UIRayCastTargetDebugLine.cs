// DEVIATION — not in gốc dump.cs (verified 2026-05-02 via grep)
// Reason: Editor-only debug helper for visualizing UI raycast targets.
//         Likely added by Tencent Editor tools (debug build of Tuanjie engine),
//         stripped from runtime IL2CPP — hence absent from dump.cs.
// Approved by user: PENDING — please confirm to KEEP (zero refs in any prefab/scene/.cs)
//                            or DELETE (cleaner, since not in gốc and unused).
// Original closest match: none in dump.cs, KTO_DecompiledReference, or DeepExtract.
// Original body would have done: draw raycast target outlines in Scene view (Editor-only).
//
// 2026-05-02 PORT: replaced AR Cpp2IL dummy stub with empty MonoBehaviour shell.
//                  Pending user decision before deleting outright.

using UnityEngine;

namespace Game.UI
{
    // ZERO refs across Assets/{prefab,scene,asset,cs}. Safe to delete after user confirms.
    public class UIRayCastTargetDebugLine : MonoBehaviour
    {
    }
}
