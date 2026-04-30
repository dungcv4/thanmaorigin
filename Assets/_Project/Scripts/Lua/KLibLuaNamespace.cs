// File: Assets/_Project/Scripts/Lua/KLibLuaNamespace.cs
// 1-1 PORT 2026-04-26 — KLib Lua namespace bindings.
//
// Source: KTO_LibClientScene_Decompiled/INDEX.tsv — KLibScriptNameSpace::Lua* methods.
// Lua call: KLib.LoadTabFileEx("Setting/Item/X.tab", 0) → returns Lua table.
//
// Symbol map (gốc → C# port):
//   _ZN19KLibScriptNameSpace16LuaLoadTabFileExER10XLuaScript @ 0x3c49a8 → LoadTabFileEx
//   _ZN19KLibScriptNameSpace14LuaLoadIniFileER10XLuaScript   @ 0x3c4c90 → LoadIniFile
//   _ZN19KLibScriptNameSpace14LuaGetDayCountER10XLuaScript   @ 0x3c4f38 → GetDayCount
//   _ZN19KLibScriptNameSpace13LuaGetUtf8LenER10XLuaScript    @ 0x3c4f70 → GetUtf8Len
//   _ZN19KLibScriptNameSpace12LuaGetStrLenER10XLuaScript     @ 0x3c4fe8 → GetStrLen
//   _ZN19KLibScriptNameSpace15LuaGetStringMd5ER10XLuaScript  @ 0x3c5228 → GetStringMd5
//   _ZN19KLibScriptNameSpace10LuaCutUtf8ER10XLuaScript       @ 0x3c5100 → CutUtf8

using System.IO;
using System.Collections.Generic;
using UnityEngine;
using XLua;

namespace ThanMaOrigin.Lua
{
    public static class KLibLuaNamespace
    {
        /// <summary>
        /// gốc KLibScriptNameSpace::LuaLoadTabFileEx — reads tab-separated file from
        /// Setting/ folder, parses header row + data rows, returns Lua table { row1, row2, ... }
        /// where each row is { colName=value, ... }.
        ///
        /// Path convention: gốc reads from `Setting/` package. thanmaorigin: read from
        /// Application.dataPath/_Project/Resources/Setting/{filename} or with .tab.txt suffix.
        /// </summary>
        public static LuaTable LoadTabFileEx(LuaEnv env, string filename, int bOutsidePackage)
        {
            // Try paths: Setting/X.tab → Setting/X.tab.txt actual file
            string root = Path.Combine(Application.dataPath, "_Project/Resources");
            string[] candidates = new string[]
            {
                Path.Combine(root, filename),                // exact
                Path.Combine(root, filename + ".txt"),       // Setting/X.tab.txt
                Path.Combine(root, "Setting/" + filename),   // legacy: prepend Setting/
                Path.Combine(root, "Setting/" + filename + ".txt"),
            };
            string path = null;
            foreach (var c in candidates) { if (File.Exists(c)) { path = c; break; } }
            if (path == null)
            {
                Debug.LogWarning($"[KLib.LoadTabFileEx] not found: {filename}");
                return null;
            }
            Debug.Log($"[KLib.LoadTabFileEx] {filename} → reading {path}");
            string text = File.ReadAllText(path);
            string[] lines = text.Split('\n');
            if (lines.Length < 2 || string.IsNullOrWhiteSpace(text))
            {
                return env.NewTable();
            }

            // First non-empty line is header
            string[] header = null;
            int dataStart = 0;
            for (int i = 0; i < lines.Length; i++)
            {
                string ln = lines[i].TrimEnd('\r');
                if (string.IsNullOrEmpty(ln)) continue;
                header = ln.Split('\t');
                dataStart = i + 1;
                break;
            }
            if (header == null) return env.NewTable();

            // FIX 2026-04-27: gốc Lua `Lib:EasyLoadTabFile` (lib.lua.txt:1227) expects:
            //   tbFile[1] = HEADER row {col_name_1, col_name_2, ...} indexed 1..N (column NAMES)
            //   tbFile[2..] = DATA rows {col_val_1, col_val_2, ...} indexed 1..N (values, ints stay int)
            // Then EasyLoadTabFile iterates header to build named tbData per row.
            // Source: gốc lib.lua.txt:1241-1268 (loop tbFile, build tbTemp[nRow-1] = tbData).
            //
            // Previous C# implementation returned ALREADY-NAMED rows which broke the contract.
            //
            // Build Lua table:
            //   result[1] = {[1]=szBtnName, [2]=nLevel, [3]=nIsLvControl, [4]=nIsShowInFuBen}
            //   result[2] = {[1]="btnMarketStall", [2]=25, [3]=1, [4]=1}
            //   result[3] = {[1]="btnAuction", [2]=13, [3]=1, [4]=1}
            //   ...
            var result = env.NewTable();

            // Row 1: header (column names indexed by 1..N).
            var headerRow = env.NewTable();
            for (int c = 0; c < header.Length; c++)
            {
                headerRow.Set(c + 1, header[c]);
            }
            result.Set(1, headerRow);

            // Rows 2..N: data with values indexed by 1..N. Empty cells → "" (Lua sees as truthy string).
            int rowIdx = 1; // next row idx
            for (int i = dataStart; i < lines.Length; i++)
            {
                string ln = lines[i].TrimEnd('\r');
                if (string.IsNullOrEmpty(ln)) continue;
                string[] cols = ln.Split('\t');
                // Skip rows where first col is empty (matches gốc: row keyed by col 1).
                if (cols.Length == 0 || string.IsNullOrWhiteSpace(cols[0])) continue;
                rowIdx++;
                var row = env.NewTable();
                for (int c = 0; c < header.Length; c++)
                {
                    string colVal = c < cols.Length ? cols[c] : "";
                    // gốc Lib:EasyLoadTabFile applies tbFnParse[nCol] = tonumber when col name
                    // starts with "n" (numeric). It calls our raw value with tonumber. We MUST
                    // pass STRING here (gốc Lua does `tonumber(szVal)` where szVal is string)
                    // so don't pre-convert — leave as string for gốc's tonumber.
                    row.Set(c + 1, colVal);
                }
                result.Set(rowIdx, row);
            }
            return result;
        }

        /// <summary>
        /// gốc LuaLoadIniFile — reads INI files into a Lua table keyed by section.
        ///
        /// Shape expected by gốc Lua:
        ///   [Mix]
        ///   FullAnger=1000
        /// becomes:
        ///   tb.Mix.FullAnger == "1000"
        ///
        /// Values stay strings because call sites explicitly use tonumber/split helpers.
        /// </summary>
        public static LuaTable LoadIniFile(LuaEnv env, string filename)
        {
            string root = Path.Combine(Application.dataPath, "_Project/Resources");
            string[] candidates = new string[]
            {
                Path.Combine(root, filename),
                Path.Combine(root, filename + ".txt"),
                Path.Combine(root, "Setting/" + filename),
                Path.Combine(root, "Setting/" + filename + ".txt"),
            };
            string path = null;
            foreach (var c in candidates)
            {
                if (File.Exists(c))
                {
                    path = c;
                    break;
                }
            }
            if (path == null)
            {
                Debug.LogWarning($"[KLib.LoadIniFile] not found: {filename}");
                return null;
            }

            Debug.Log($"[KLib.LoadIniFile] {filename} -> reading {path}");
            var result = env.NewTable();
            LuaTable currentSection = null;
            string currentSectionName = null;

            foreach (var rawLine in File.ReadAllLines(path))
            {
                string line = rawLine.Trim();
                if (string.IsNullOrEmpty(line)) continue;
                if (line.StartsWith(";") || line.StartsWith("#")) continue;

                if (line.StartsWith("[") && line.EndsWith("]") && line.Length > 2)
                {
                    currentSectionName = line.Substring(1, line.Length - 2).Trim();
                    currentSection = env.NewTable();
                    result.Set<string, LuaTable>(currentSectionName, currentSection);
                    continue;
                }

                int eq = line.IndexOf('=');
                if (eq < 0) continue;
                if (currentSection == null)
                {
                    currentSectionName = "Default";
                    currentSection = env.NewTable();
                    result.Set<string, LuaTable>(currentSectionName, currentSection);
                }

                string key = line.Substring(0, eq).Trim();
                string value = line.Substring(eq + 1).Trim();
                if (string.IsNullOrEmpty(key)) continue;
                currentSection.Set<string, string>(key, value);
            }

            return result;
        }

        /// <summary>gốc LuaGetStrLen — string length (bytes).</summary>
        public static int GetStrLen(string s) => s == null ? 0 : System.Text.Encoding.UTF8.GetByteCount(s);

        /// <summary>gốc LuaGetUtf8Len — UTF-8 codepoint count (visible char count).</summary>
        public static int GetUtf8Len(string s)
        {
            if (string.IsNullOrEmpty(s)) return 0;
            // Count UTF-16 surrogate pairs as 1 codepoint, others as 1.
            int count = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (char.IsHighSurrogate(s[i]) && i + 1 < s.Length && char.IsLowSurrogate(s[i + 1])) i++;
                count++;
            }
            return count;
        }

        /// <summary>gốc LuaCutUtf8 — substring by UTF-8 codepoints.</summary>
        public static string CutUtf8(string s, int startCodepoint, int countCodepoint)
        {
            if (string.IsNullOrEmpty(s)) return s;
            int start = -1, end = -1, cp = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (cp == startCodepoint) start = i;
                if (cp == startCodepoint + countCodepoint) { end = i; break; }
                if (char.IsHighSurrogate(s[i]) && i + 1 < s.Length && char.IsLowSurrogate(s[i + 1])) i++;
                cp++;
            }
            if (start == -1) return "";
            if (end == -1) end = s.Length;
            return s.Substring(start, end - start);
        }

        /// <summary>gốc LuaGetStringMd5 — MD5 hex digest.</summary>
        public static string GetStringMd5(string s)
        {
            if (s == null) s = "";
            using (var md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] bytes = md5.ComputeHash(System.Text.Encoding.UTF8.GetBytes(s));
                var sb = new System.Text.StringBuilder(32);
                foreach (var b in bytes) sb.Append(b.ToString("x2"));
                return sb.ToString();
            }
        }

        /// <summary>
        /// gốc LuaGetDayCount — total day count since Unix epoch (or game epoch).
        /// gốc uses Unix time / 86400. Server timezone applied.
        /// </summary>
        public static int GetDayCount()
        {
            return (int)(System.DateTimeOffset.UtcNow.ToUnixTimeSeconds() / 86400);
        }

        /// <summary>gốc LuaGetValByStr — walk Lua global table by dotted name.</summary>
        public static object GetValByStr(LuaEnv env, string dottedName)
        {
            if (env == null || string.IsNullOrEmpty(dottedName)) return null;
            // Use raw Lua DoString to evaluate
            try
            {
                var ret = env.DoString($"return {dottedName}", "GetValByStr");
                return (ret != null && ret.Length > 0) ? ret[0] : null;
            }
            catch { return null; }
        }

        /// <summary>gốc LuaToLowerSameChar — locale-stable lowercase.</summary>
        public static string ToLowerSameChar(string s) => s == null ? null : s.ToLowerInvariant();

        /// <summary>gốc LuaGetTime — Unix timestamp seconds.</summary>
        public static long GetTime() => System.DateTimeOffset.UtcNow.ToUnixTimeSeconds();

        /// <summary>gốc LuaGetTickCount — engine tick count (ms since startup).</summary>
        public static long GetTickCount() => (long)(UnityEngine.Time.realtimeSinceStartupAsDouble * 1000);

        /// <summary>gốc LuaGetFrame — Unity frame count.</summary>
        public static long GetFrame() => UnityEngine.Time.frameCount;

        /// <summary>
        /// Bind KLib Lua global namespace. Call from LuaEngine.Awake after BindRequire.
        /// </summary>
        public static void BindLua(LuaEnv env)
        {
            if (env == null) return;
            // Use Env.Global.Set (XLua API) which writes DIRECTLY to globals — bypasses
            // Script_preload.lua's strict-mode `__newindex` metamethod that blocks
            // non-whitelisted globals. gốc native binding has the same effect (registers
            // before any Lua runs, so strict mode hasn't been set yet — but strict mode
            // explicitly allows pre-existing keys via tbGlobalTable copy).
            //
            // Bind KLib as a Lua table with function methods.
            try
            {
                // Set fields on the KLib table via Env.Global.Set so each is visible from Lua.
                // First set methods individually in a Lua table created inline via DoString
                // (XLua's NewTable + Set has issues exposing nested function values to Lua scripts).
                env.DoString("KLib = KLib or {}", "PreCreateKLib");

                // Then attach C# delegates as methods. Each delegate is stored on the KLib table.
                env.Global.Get<LuaTable>("KLib").Set<string, System.Func<string, int, LuaTable>>(
                    "LoadTabFileEx", (name, b) => KLibBridge.LoadTabFileEx(name, b));
                env.Global.Get<LuaTable>("KLib").Set<string, System.Func<string, LuaTable>>(
                    "LoadIniFile", KLibBridge.LoadIniFile);
                env.Global.Get<LuaTable>("KLib").Set<string, System.Func<string, int>>(
                    "GetStrLen", GetStrLen);
                env.Global.Get<LuaTable>("KLib").Set<string, System.Func<string, int>>(
                    "GetUtf8Len", GetUtf8Len);
                env.Global.Get<LuaTable>("KLib").Set<string, System.Func<string, int, int, string>>(
                    "CutUtf8", CutUtf8);
                env.Global.Get<LuaTable>("KLib").Set<string, System.Func<string, string>>(
                    "GetStringMd5", GetStringMd5);
                env.Global.Get<LuaTable>("KLib").Set<string, System.Func<int>>(
                    "GetDayCount", GetDayCount);
                env.Global.Get<LuaTable>("KLib").Set<string, System.Func<string, object>>(
                    "GetValByStr", KLibBridge.GetValByStr);
                env.Global.Get<LuaTable>("KLib").Set<string, System.Func<string, string>>(
                    "ToLowerSameChar", ToLowerSameChar);

                // Also bind as Lua GLOBALS without KLib. prefix per libclient_scene.so
                // LuaGlobalScriptNameSpace::Lua* methods that are top-level functions.
                //
                // GLOBAL `LoadTabFileEx(szFile, szType, szIndex, tbField, bOutsidePackage, nBeginRow)`:
                // Different signature than KLib.LoadTabFileEx — FULL parse + type-cast + index.
                // Cite: gốc native LuaGlobalScriptNameSpace15LuaLoadTabFileExER10XLuaScript.
                // Used by Faction:Init (lib.lua:1217 → this).
                env.Global.Set<string, System.Func<string, string, string, LuaTable, object, object, LuaTable>>(
                    "LoadTabFileEx",
                    (szFile, szType, szIndex, tbField, bOutsidePkg, nBeginRow) =>
                        KLibBridge.LoadTabFileExFull(szFile, szType, szIndex, tbField,
                            bOutsidePkg is int bi ? bi : 0,
                            nBeginRow is int br ? br : 2));
                env.Global.Set<string, System.Func<string, LuaTable>>("LoadIniFile", KLibBridge.LoadIniFile);
                env.Global.Set<string, System.Func<string, int>>("GetStrLen", GetStrLen);
                env.Global.Set<string, System.Func<string, int>>("GetUtf8Len", GetUtf8Len);
                env.Global.Set<string, System.Func<string, int, int, string>>("CutUtf8", CutUtf8);
                env.Global.Set<string, System.Func<string, string>>("GetStringMd5", GetStringMd5);
                env.Global.Set<string, System.Func<int>>("GetDayCount", GetDayCount);
                env.Global.Set<string, System.Func<string, object>>("GetValByStr", KLibBridge.GetValByStr);
                env.Global.Set<string, System.Func<string, string>>("ToLowerSameChar", ToLowerSameChar);
                env.Global.Set<string, System.Func<long>>("GetTime", GetTime);
                env.Global.Set<string, System.Func<long>>("GetTickCount", GetTickCount);
                env.Global.Set<string, System.Func<long>>("GetFrame", GetFrame);
                env.Global.Set<string, System.Func<string, bool>>("IsEmptyStr", IsEmptyStr);

                // gốc LuaGetGroupKey @ libclient_scene.so — string concat with '_' separator.
                // Used for table key generation: GetGroupKey('A','B','C') → 'A_B_C'
                // Variadic — accepts up to 6 args (covers all gốc call sites observed).
                env.Global.Set<string, System.Func<object, object, object, object, object, object, string>>(
                    "GetGroupKey", GetGroupKey);

                Debug.Log("[KLib] Lua namespace bound (KLib table + 14 globals)");
            }
            catch (System.Exception e)
            {
                Debug.LogError($"[KLib] BindLua FAIL: {e.Message}");
            }
        }

        public static bool IsEmptyStr(string s) => string.IsNullOrEmpty(s);

        /// <summary>gốc LuaGetGroupKey — concat args with '_'.</summary>
        public static string GetGroupKey(object a, object b, object c, object d, object e, object f)
        {
            var sb = new System.Text.StringBuilder();
            void Add(object x) { if (x == null) return; if (sb.Length > 0) sb.Append('_'); sb.Append(x.ToString()); }
            Add(a); Add(b); Add(c); Add(d); Add(e); Add(f);
            return sb.ToString();
        }
    }

    /// <summary>
    /// Bridge for methods that need access to the LuaEnv instance (LoadTabFileEx returns LuaTable).
    /// Static facade so Lua can call CS.ThanMaOrigin.Lua.KLibBridge.X(...) without env arg.
    /// </summary>
    public static class KLibBridge
    {
        public static LuaTable LoadTabFileEx(string name, int bOutsidePackage)
        {
            var env = LuaEngine.Instance?.Env;
            return env == null ? null : KLibLuaNamespace.LoadTabFileEx(env, name, bOutsidePackage);
        }

        /// <summary>
        /// Full LoadTabFileEx — gốc native LuaGlobalScriptNameSpace15LuaLoadTabFileExER10XLuaScript.
        /// Reads tab file, parses each row into named-key table per szType + tbField, then
        /// keys the result by szIndex column.
        /// szType: per-column type chars (d=int, s=string).
        /// szIndex: name of column to use as primary key in result.
        /// tbField: array of field names to include (whitelist). Pass nil/empty for all.
        /// nBeginRow: 1-based row index where data starts (header is row 1, data row 1 = row 2 in file).
        /// </summary>
        public static LuaTable LoadTabFileExFull(string szFile, string szType, string szIndex,
                                                  LuaTable tbField, int bOutsidePackage, int nBeginRow)
        {
            var env = LuaEngine.Instance?.Env;
            if (env == null) return null;

            // Reuse base reader that returns {[1]=header, [2..]=rawRows}.
            var raw = KLibLuaNamespace.LoadTabFileEx(env, szFile, bOutsidePackage);
            if (raw == null) return null;

            // Extract header row (col index → col name).
            var header = raw.Get<int, LuaTable>(1);
            if (header == null) return env.NewTable();
            var colNames = new System.Collections.Generic.List<string>();
            int colCount = 0;
            // Lua tables are 1-based; iterate until nil.
            for (int c = 1; ; c++)
            {
                string s = header.Get<int, string>(c);
                if (s == null) break;
                colNames.Add(s);
                colCount = c;
            }

            // Optional whitelist: tbField is array {fieldName1, fieldName2, ...}.
            // In the original native helper, szType follows tbField order when tbField is
            // supplied, not the absolute column index in the source .tab. Several callsites
            // pass sparse tbField lists against wide source tables (for example Skill.tab).
            var fieldType = new System.Collections.Generic.Dictionary<string, char>();
            System.Collections.Generic.HashSet<string> whitelist = null;
            if (tbField != null)
            {
                whitelist = new System.Collections.Generic.HashSet<string>();
                for (int i = 1; ; i++)
                {
                    string fname = tbField.Get<int, string>(i);
                    if (fname == null) break;
                    whitelist.Add(fname);
                    fieldType[fname] = !string.IsNullOrEmpty(szType) && i <= szType.Length ? szType[i - 1] : 's';
                }
                if (whitelist.Count == 0) whitelist = null; // empty list = include all
            }

            // Build result keyed by szIndex column value, OR by sequential row index when
            // szIndex is nil (gốc behavior — see Lib:LoadTabFileEx callsites with szIndex=nil:
            //   Login.lua:170-172  → Setting/RandomName/*.tab indexed 1..N (no key column)
            //   KinSkill.lua:40    → upgrade table also nil-indexed
            //   Wedding.lua:106    → ditto)
            // gốc Lua native LuaLoadTabFileExER10XLuaScript falls back to "next integer" key
            // when szIndex argument is missing/nil; result becomes a 1-based sequential array.
            var result = env.NewTable();
            int seqIndex = 0;
            bool hasIndex = !string.IsNullOrEmpty(szIndex);
            for (int row = 2; ; row++)
            {
                var rawRow = raw.Get<int, LuaTable>(row);
                if (rawRow == null) break;
                var rowData = env.NewTable();
                string keyValue = null;
                for (int c = 1; c <= colCount; c++)
                {
                    string colName = colNames[c - 1];
                    string raw_v = rawRow.Get<int, string>(c) ?? "";
                    char tch = fieldType.TryGetValue(colName, out var mappedType)
                        ? mappedType
                        : (!string.IsNullOrEmpty(szType) && c <= szType.Length ? szType[c - 1] : 's');
                    if (hasIndex && colName == szIndex)
                    {
                        keyValue = tch == 'd' && long.TryParse(raw_v, out long keyNum)
                            ? keyNum.ToString()
                            : raw_v;
                    }
                    if (whitelist != null && !whitelist.Contains(colName)) continue;
                    if (tch == 'd')
                    {
                        long iv = 0;
                        long.TryParse(raw_v, out iv);
                        rowData.Set<string, long>(colName, iv);
                    }
                    else
                    {
                        rowData.Set<string, string>(colName, raw_v);
                    }
                }
                if (!hasIndex)
                {
                    // No key column — use sequential 1-based index (gốc fallback).
                    seqIndex++;
                    result.Set<long, LuaTable>(seqIndex, rowData);
                    continue;
                }
                if (keyValue == null)
                {
                    // szIndex column was specified but row's value is missing — skip row.
                    continue;
                }
                // Try numeric index for integer keys (typical for nId)
                if (long.TryParse(keyValue, out long numKey))
                    result.Set<long, LuaTable>(numKey, rowData);
                else
                    result.Set<string, LuaTable>(keyValue, rowData);
            }
            return result;
        }
        public static LuaTable LoadIniFile(string name)
        {
            var env = LuaEngine.Instance?.Env;
            return env == null ? null : KLibLuaNamespace.LoadIniFile(env, name);
        }
        public static object GetValByStr(string dottedName)
        {
            var env = LuaEngine.Instance?.Env;
            return env == null ? null : KLibLuaNamespace.GetValByStr(env, dottedName);
        }
    }
}
