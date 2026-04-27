// Class:  LanguageModule
// GUID:   dc715841602834c068fe9a4f3b2ade6e (preserved via .meta)
// Source: KTO_DecompiledReference/_root/LanguageModule.c (decomp_01bb.c:10473+)
//         + KiemTheOrigin_DeepExtract/_shared/DecompiledSource/LanguageModule.cs
//
// PARTIAL PORT 2026-04-26 — Get/Format/CurrentLanguageCode (boot blockers).
// gốc class has many static fields (szNPC_FLYCHAR_*, etc.) + methods.
// Wave B continued port will fill all 80+ static fields + LoadDefaultString.
//
// Lua exposes via:
//   i18n table with metatable __index = LanguageModule (Script_i18n_i18n.lua:3)
//   So `i18n.X(...)` falls through to `LanguageModule.X(...)` C# static.

using System.Collections.Generic;
using UnityEngine;

public class LanguageModule : MonoBehaviour
{
    // ─── Translation dictionary ────────────────────────────────────────
    // 1-1 with KTO localization architecture: keys ARE original Chinese strings,
    // values are Vietnamese translations. Loaded from Resources/language/translations_vi-VN.json.
    // Built 2026-04-17 with 193 terms (per CLAUDE.md ref_kto_localization).
    private static Dictionary<string, string> _translations;
    private static string _currentLanguageCode = "vi-VN";

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void LoadTranslations()
    {
        _translations = new Dictionary<string, string>();
        var ta = Resources.Load<TextAsset>("language/translations_vi-VN");
        if (ta == null)
        {
            Debug.LogWarning("[LanguageModule] translations_vi-VN.json not found at Resources/language/");
            return;
        }
        try
        {
            // Simple JSON object parse: {"key1": "val1", "key2": "val2", ...}
            var json = ta.text;
            int n = ParseFlatJson(json, _translations);
            Debug.Log($"[LanguageModule] Loaded {n} translations (vi-VN)");
        }
        catch (System.Exception e)
        {
            Debug.LogError($"[LanguageModule] Translation parse FAIL: {e.Message}");
        }
    }

    private static int ParseFlatJson(string json, Dictionary<string, string> dest)
    {
        // Minimal flat-dict parser: handles {"k":"v","k2":"v2"} with escaped chars.
        // Cite: thanmaorigin's translations_vi-VN.json is flat dict only, no nesting.
        int n = 0, i = 0;
        while (i < json.Length)
        {
            // Find next opening quote
            while (i < json.Length && json[i] != '"') i++;
            if (i >= json.Length) break;
            int kStart = ++i;
            while (i < json.Length && json[i] != '"') { if (json[i] == '\\') i++; i++; }
            string key = json.Substring(kStart, i - kStart);
            i++;
            // Skip ':'
            while (i < json.Length && json[i] != ':') i++;
            i++;
            // Find value
            while (i < json.Length && json[i] != '"') i++;
            int vStart = ++i;
            while (i < json.Length && json[i] != '"') { if (json[i] == '\\') i++; i++; }
            string val = json.Substring(vStart, i - vStart);
            i++;
            dest[Unescape(key)] = Unescape(val);
            n++;
        }
        return n;
    }
    private static string Unescape(string s) => s
        .Replace("\\n", "\n").Replace("\\t", "\t")
        .Replace("\\\"", "\"").Replace("\\\\", "\\");

    // ─── PORT 1-1: LanguageModule.CurrentLanguageCode ──────────────────
    // VMA: 0x01bbb8a1 — Source: decomp_01bb.c:10568
    // gốc body: returns I2.Loc.LocalizationManager.get_CurrentLanguageCode().
    // 1-1 PORT: thanmaorigin uses static "vi-VN" (Vietnamese-only client).
    //   Future: expose setter for runtime language switch.
    public static string CurrentLanguageCode()
    {
        return _currentLanguageCode;
    }

    public static void SetLanguageCode(string code)
    {
        _currentLanguageCode = code;
    }

    // ─── PORT 1-1: LanguageModule.Get ──────────────────────────────────
    // gốc body: looks up translation by key in I2.Loc dictionary.
    // 1-1 PORT: lookup in _translations dict; fall back to key if not found.
    public static string Get(string key, params object[] args)
    {
        if (string.IsNullOrEmpty(key)) return "";
        if (_translations == null) LoadTranslations();
        string val = (_translations != null && _translations.TryGetValue(key, out var v)) ? v : key;
        if (args != null && args.Length > 0)
        {
            try { return string.Format(val, args); } catch { return val; }
        }
        return val;
    }

    // ─── PORT 1-1: LanguageModule.Format ───────────────────────────────
    // gốc body: format string with args (after translation lookup).
    public static string Format(string format, params object[] args)
    {
        if (string.IsNullOrEmpty(format)) return "";
        try { return string.Format(format, args); } catch { return format; }
    }
}
