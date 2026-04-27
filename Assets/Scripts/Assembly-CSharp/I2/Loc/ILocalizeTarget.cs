// 1-1 PORT 2026-04-27: I2.Loc.ILocalizeTarget ported from gốc IL2CPP.
// Source: KiemTheOrigin_DeepExtract/_shared/DecompiledSource/I2.Loc/ILocalizeTarget.cs
//
// Layout: abstract ScriptableObject base class for all locale targets
// (UnityUI_Text / UnityStandard_TextMesh / TextMeshPro_UGUI / Sprite / Mesh / etc).
// In serialized prefab YAML, the field is `{fileID: 0}` because no specific target
// instance is bundled — gốc resolves at runtime by walking LocalizationManager.Sources.
//
// thanmaorigin: we don't need the abstract methods to be invoked because
// Localize.OnLocalize() in our port directly writes to UI.Text component on the same
// GameObject (covering the LocalizeTarget_UnityUI_Text use case for the login UI).
// Keeping the abstract type for prefab field-typing only.
using UnityEngine;

namespace I2.Loc
{
    public abstract class ILocalizeTarget : ScriptableObject
    {
        public abstract bool IsValid(Localize cmp);
        public abstract void GetFinalTerms(Localize cmp, string Main, string Secondary, out string primaryTerm, out string secondaryTerm);
        public abstract void DoLocalize(Localize cmp, string mainTranslation, string secondaryTranslation);
        public abstract bool CanUseSecondaryTerm();
        public abstract bool AllowMainTermToBeRTL();
        public abstract bool AllowSecondTermToBeRTL();
        public abstract eTermType GetPrimaryTermType(Localize cmp);
        public abstract eTermType GetSecondaryTermType(Localize cmp);
    }
}
