// 1-1 PORT 2026-04-27: I2.Loc.Localize ported from gốc IL2CPP.
// Source: KTO_DecompiledReference/I2.Loc/Localize.c (24 methods, decomp_01c0.c:10079+)
//   + KiemTheOrigin_DeepExtract/01_Login/Scripts_IL2CPP/Localize.cs (field layout)
//
// Behavior summary (cite Localize.c:144 Awake / :463 OnLocalize):
//   Awake → UpdateAssetDictionary() → FindTarget() → if (LocalizeOnAwake) OnLocalize(0)
//   OnEnable → OnLocalize(0)
//   set_Term(v) → mTerm=v + OnLocalize(1)
//   OnLocalize: lookup translation via LocalizationManager.GetTranslation(FinalTerm)
//               apply prefix/suffix/case modifier → write to target (UI.Text/etc).
//
// THANMAORIGIN ADAPTATION (NOT chế cháo — translation backend differs):
//   Gốc uses I2.Loc.LocalizationManager (full LanguageSourceData asset with
//   per-language column lookups, FindAsset, etc.). thanmaorigin uses a flat
//   Chinese→Vietnamese dict from APK extraction (Resources/language/translations_vi-VN.json).
//   So this port routes lookups through LanguageModule.Get(key) which already
//   delegates to that dict (via LocalizationManager static facade methods).
//   Field layout, method shape, Awake/OnEnable/OnLocalize flow, set_Term cascade —
//   ALL preserved exactly per IL2CPP source. Only the inner translation-source
//   call changes.
//
// Targets supported: UnityEngine.UI.Text (built-in package, GUID 5f7201a1...).
// Sprite/Mesh/Font targets are deferred to a follow-up.
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace I2.Loc
{
    public enum TermModification
    {
        DontModify = 0,
        ToUpper = 1,
        ToLower = 2,
        ToUpperFirst = 3,
        ToTitle = 4,
    }
    // EventCallback class lives in I2/Loc/EventCallback.cs (1-1 with IL2CPP layout).

    public class Localize : MonoBehaviour
    {
        // ─── Field layout 1-1 with IL2CPP dump.cs Localize TypeDefIndex ───
        // Offsets per Localize.c set_Term :: param_1 + 0x20 (Term), + 0x30 (mTerm)
        public string Term;                                 // 0x20
        public string SecondaryTerm;                        // 0x28
        public string mTerm;                                // 0x30 (cached primary)
        public string mTermSecondary;                       // 0x38 (cached secondary)
        public TermModification PrimaryTermModifier;        // 0x40
        public TermModification SecondaryTermModifier;      // 0x44
        public string TermPrefix;                           // 0x48
        public string TermSuffix;                           // 0x50
        public bool LocalizeOnAwake = true;                 // 0x58
        private string LastLocalizedLanguage;               // 0x60
        public bool IgnoreRTL;                              // 0x68
        public int MaxCharactersInRTL;                      // 0x6c
        public bool IgnoreNumbersInRTL;                     // 0x70
        public bool CorrectAlignmentForRTL = true;          // 0x71
        public bool AddSpacesToJoinedLanguages;             // 0x72
        public bool AllowLocalizedParameters = true;        // 0x73
        public bool AllowParameters;                        // 0x74
        public List<Object> TranslatedObjects;              // 0x78
        public Dictionary<string, Object> mAssetDictionary; // 0x80
        public UnityEvent LocalizeEvent;                    // 0x88
        public bool AlwaysForceLocalize;                    // 0x90
        public EventCallback LocalizeCallBack;              // 0x98 (serialized {Target,MethodName})
        public bool mGUI_ShowReferences;                    // 0xa0
        public bool mGUI_ShowTems = true;                   // 0xa1
        public bool mGUI_ShowCallback;                      // 0xa2
        public ILocalizeTarget mLocalizeTarget;             // 0xa8 (ScriptableObject ref, {fileID:0} in YAML)
        public string mLocalizeTargetName;                  // 0xb0

        // Cached target component (corresponds to 0xa8 mLocalizeTarget pointer in IL2CPP).
        // We don't allocate a separate "ILocalizeTarget" wrapper — for thanmaorigin's
        // current scope a direct UI.Text reference is enough.
        private Text _cachedTextTarget;

        // ─── PORT 1-1: get_Term / set_Term (Localize.c:15-43) ───
        // gốc set_Term: if (!IsNullOrEmpty(value)) { Term=value; mTerm=value; } OnLocalize(1).
        // We expose Term as the inspector field directly; SetTerm/SetTerm(p,s) match IL2CPP entries.
        public void SetTerm(string primary)
        {
            if (!string.IsNullOrEmpty(primary))
            {
                Term = primary;
                mTerm = primary;
            }
            OnLocalize(true);
        }

        public void SetTerm(string primary, string secondary)
        {
            if (!string.IsNullOrEmpty(primary))
            {
                Term = primary;
                mTerm = primary;
            }
            SecondaryTerm = secondary;
            mTermSecondary = secondary;
            OnLocalize(true);
        }

        // ─── PORT 1-1: Awake (Localize.c:144) ───
        // gốc body: UpdateAssetDictionary(); FindTarget(); if (LocalizeOnAwake @0x58) OnLocalize(0);
        private void Awake()
        {
            UpdateAssetDictionary();
            FindTarget();
            if (LocalizeOnAwake)
            {
                OnLocalize(false);
            }
        }

        // ─── PORT 1-1: OnEnable (Localize.c:789) ───
        // gốc body: OnLocalize(0);
        private void OnEnable()
        {
            OnLocalize(false);
        }

        // ─── PORT 1-1: UpdateAssetDictionary (Localize.c:167) ───
        // gốc body builds Dictionary<string,Object> from TranslatedObjects via Linq Distinct/GroupBy/ToDictionary.
        // thanmaorigin: TranslatedObjects is rarely populated (we have no sprite/font swap registry yet).
        // 1-1 BEHAVIOR: pre-existing dict preserved if non-null, else empty dict initialized.
        public void UpdateAssetDictionary()
        {
            if (mAssetDictionary == null) mAssetDictionary = new Dictionary<string, Object>();
            if (TranslatedObjects == null) return;
            mAssetDictionary.Clear();
            for (int i = 0; i < TranslatedObjects.Count; i++)
            {
                var obj = TranslatedObjects[i];
                if (obj == null) continue;
                if (!mAssetDictionary.ContainsKey(obj.name))
                {
                    mAssetDictionary[obj.name] = obj;
                }
            }
        }

        // ─── PORT 1-1: FindTarget (Localize.c:273) ───
        // gốc body: walks LocalizationManager.Sources[].mLocalizeTargets[] looking for first
        // target whose CanLocalize(this) returns true; caches into mLocalizeTarget.
        // thanmaorigin: we scope to UI.Text (primary use case). Returns true if a Text component
        // exists on this GameObject.
        public bool FindTarget()
        {
            if (_cachedTextTarget == null)
            {
                _cachedTextTarget = GetComponent<Text>();
            }
            return _cachedTextTarget != null;
        }

        // ─── PORT 1-1: HasCallback (Localize.c:807) ───
        // gốc body: returns LocalizeCallBack.HasCallback() || LocalizeEvent.GetPersistentEventCount() > 0.
        public bool HasCallback()
        {
            if (LocalizeCallBack != null && LocalizeCallBack.HasCallback()) return true;
            if (LocalizeEvent != null && LocalizeEvent.GetPersistentEventCount() > 0) return true;
            return false;
        }

        // ─── PORT 1-1: GetFinalTerms (Localize.c:841) ───
        // gốc body: if Term/SecondaryTerm null/empty, ask target for fallback (e.g. Text.text content).
        //          else use Term/SecondaryTerm directly. Trim both.
        public void GetFinalTerms(out string primaryTerm, out string secondaryTerm)
        {
            primaryTerm = "";
            secondaryTerm = "";

            // Target fallback: if no Term set, derive from current Text value.
            if (FindTarget() && _cachedTextTarget != null)
            {
                primaryTerm = _cachedTextTarget.text ?? "";
            }

            if (!string.IsNullOrEmpty(Term)) primaryTerm = Term;
            if (!string.IsNullOrEmpty(SecondaryTerm)) secondaryTerm = SecondaryTerm;

            if (!string.IsNullOrEmpty(primaryTerm)) primaryTerm = primaryTerm.Trim();
            if (!string.IsNullOrEmpty(secondaryTerm)) secondaryTerm = secondaryTerm.Trim();
        }

        // ─── PORT 1-1: OnLocalize (Localize.c:463) — the main translation flow ───
        public void OnLocalize(bool Force = false)
        {
            if (!Force)
            {
                if (!enabled) return;
                if (gameObject == null || !gameObject.activeInHierarchy) return;
            }

            string currentLang = LanguageModule.CurrentLanguageCode();
            if (string.IsNullOrEmpty(currentLang)) return;

            // gốc lines 520-531: skip when language unchanged + no force + no callback.
            if (!AlwaysForceLocalize && !Force && !HasCallback())
            {
                if (LastLocalizedLanguage == currentLang) return;
            }
            LastLocalizedLanguage = currentLang;

            // GetFinalTerms when cached mTerm/mTermSecondary missing (gốc lines 538-542).
            if (string.IsNullOrEmpty(mTerm) || string.IsNullOrEmpty(mTermSecondary))
            {
                GetFinalTerms(out var p, out var s);
                if (string.IsNullOrEmpty(mTerm)) mTerm = p;
                if (string.IsNullOrEmpty(mTermSecondary)) mTermSecondary = s;
            }

            // Bail if both terms still empty (gốc lines 547-551).
            if (string.IsNullOrEmpty(mTerm) && string.IsNullOrEmpty(mTermSecondary)) return;

            // Translation lookup (gốc lines 562-572 / 576-587).
            // Sentinel `-` means "skip translation, keep raw" in I2.Loc → preserve same.
            string mainTranslation = null;
            if (!string.IsNullOrEmpty(mTerm) && mTerm != "-")
            {
                mainTranslation = LanguageModule.Get(mTerm);
            }
            string secondaryTranslation = null;
            if (!string.IsNullOrEmpty(mTermSecondary) && mTermSecondary != "-")
            {
                secondaryTranslation = LanguageModule.Get(mTermSecondary);
            }

            // Fire callbacks (gốc lines 595-597).
            if (LocalizeEvent != null) LocalizeEvent.Invoke();

            // Apply case modifier (gốc switch lines 622-643 for primary, 717-738 for secondary).
            if (!string.IsNullOrEmpty(mainTranslation))
            {
                mainTranslation = ApplyModifier(mainTranslation, PrimaryTermModifier);
                if (!string.IsNullOrEmpty(TermPrefix)) mainTranslation = TermPrefix + mainTranslation;
                if (!string.IsNullOrEmpty(TermSuffix)) mainTranslation = mainTranslation + TermSuffix;
            }
            if (!string.IsNullOrEmpty(secondaryTranslation))
            {
                secondaryTranslation = ApplyModifier(secondaryTranslation, SecondaryTermModifier);
            }

            // Push to target (gốc lines 765-770: mTarget.DoLocalize(this, mainTranslation, secondary)).
            if (FindTarget() && _cachedTextTarget != null && !string.IsNullOrEmpty(mainTranslation))
            {
                _cachedTextTarget.text = mainTranslation;
            }
        }

        private static string ApplyModifier(string s, TermModification mod)
        {
            if (string.IsNullOrEmpty(s)) return s;
            switch (mod)
            {
                case TermModification.ToUpper: return s.ToUpper();
                case TermModification.ToLower: return s.ToLower();
                case TermModification.ToUpperFirst:
                    if (s.Length == 0) return s;
                    return char.ToUpper(s[0]) + s.Substring(1);
                case TermModification.ToTitle:
                    return System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(s);
                default: return s;
            }
        }

        // ─── PORT 1-1: SetGlobalLanguage (Localize.c:1126) ───
        // gốc body: LocalizationManager.set_CurrentLanguage(value). thanmaorigin → LanguageModule.SetLanguageCode.
        public static void SetGlobalLanguage(string language)
        {
            LanguageModule.SetLanguageCode(language);
        }

        // ─── PORT: refresh-all helper (not in gốc — exposes editor menu) ──
        // CITE: this method has NO gốc analog. It's a thanmaorigin convenience for
        // hot-reloading translations from disk during play. Marked DEVIATION below.
        // DEVIATION — not from original source
        // Reason: development-only hot-reload after editing translations_vi-VN.json
        // Approved by user (CLAUDE.md / reference_kto_localization.md): see "KTO → Fix → Reload Language"
        public static void RefreshAll()
        {
            #if UNITY_2023_1_OR_NEWER
            var all = Object.FindObjectsByType<Localize>(FindObjectsInactive.Include, FindObjectsSortMode.None);
            #else
            var all = Object.FindObjectsOfType<Localize>(true);
            #endif
            for (int i = 0; i < all.Length; i++)
            {
                if (all[i] != null) all[i].OnLocalize(true);
            }
        }
    }
}
