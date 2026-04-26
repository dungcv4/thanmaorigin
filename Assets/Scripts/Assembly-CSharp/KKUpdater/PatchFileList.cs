// Class:  KKUpdater.PatchFileList
// GUID:   eb91765f0585637c2d12448c2a13ccef (preserved via .meta)
// Source: KTO_DecompiledReference/KKUpdater/PatchFileList.c (6 methods, 185 LOC)
//         + KTO_DecompiledReference/KKUpdater.PatchFileList/{
//             _UnmarshalFromLocal_d__8.c (158 LOC),
//             _UnmarshalFromUrl_d__9.c (180 LOC) }
// Dump:   KTO_Resources/il2cpp_full_dump/dump.cs (TypeDefIndex 1375)
//
// FULL 1-1 PORT 2026-04-25 — every method body verified against Ghidra C decompile.
//
// CLASS-LEVEL DEVIATION:
// - LitJson.JsonMapper is provided by our local facade (see JsonMapper.cs)
//   which delegates to Newtonsoft.Json. Behavior matches gốc for the JSON
//   shapes that PatchFileList serializes (Dictionary<string, PatchFile>).
// - Iterator state machines <UnmarshalFromLocal>d__8 and <UnmarshalFromUrl>d__9
//   compressed into idiomatic C# yield blocks (semantics preserved).

using System.Collections;
using System.Collections.Generic;
using System.IO;
using LitJson;
using UnityEngine;
using UnityEngine.Networking;

namespace KKUpdater
{
    public class PatchFileList
    {
        // Fields (offsets từ dump.cs)
        public string MainVersion;                                          // 0x10
        public int UpdateVersion;                                            // 0x18
        public Dictionary<string, PatchFile> FileList;                       // 0x20
        public Dictionary<string, OptionalPatchFile> OptionalPatchFileList;  // 0x28
        public bool isDone;                                                  // 0x30

        // VMA: 0x01bc7927 — Source: KTO_DecompiledReference/KKUpdater/PatchFileList.c:15 (isLegal)
        // gốc body:
        //   System_String__op_Equality(MainVersion, validVersion, 0);
        //   return; (gốc result is discarded — appears to be a bug; we preserve return-bool pattern).
        // ⚠ DEVIATION: gốc body returns the comparison result implicitly (in_RAX from op_Equality),
        //              we make it explicit to match the C# signature `public bool isLegal(string)`.
        public bool isLegal(string validVersion)
        {
            return MainVersion == validVersion;
        }

        // VMA: 0x01bc7932 — Source: KTO_DecompiledReference/KKUpdater/PatchFileList.c:33 (Marshal2File)
        // gốc body:
        //   string json = LitJson.JsonMapper.ToJson(this);
        //   FileInfo fi = new FileInfo(szPath);
        //   if (fi.Exists) fi.Delete();
        //   StreamWriter sw = fi.CreateText();
        //   sw.Write(json);
        //   fi.Exists; (gốc evaluates Exists property again — discarded)
        //   sw.Close();
        //   sw.Dispose();
        public void Marshal2File(string szPath)
        {
            string json = JsonMapper.ToJson(this);
            var fi = new FileInfo(szPath);
            if (fi.Exists) fi.Delete();
            using (var sw = fi.CreateText())
            {
                sw.Write(json);
                _ = fi.Exists; // gốc preserved: property accessed but result discarded
                sw.Close();
            }
        }

        // VMA: 0x01bc7a3e — Source: KTO_DecompiledReference/KKUpdater/PatchFileList.c:80 (Unmarshal)
        // gốc body:
        //   PatchFileList tmp = LitJson.JsonMapper.ToObject<PatchFileList>(szContent);
        //   this.MainVersion = tmp.MainVersion;          // 0x10
        //   this.FileList    = tmp.FileList;              // 0x20
        //   this.UpdateVersion = tmp.UpdateVersion;       // 0x18
        //   this.OptionalPatchFileList = tmp.OptionalPatchFileList; // 0x28
        //   this.isDone = true;                            // 0x30
        private void Unmarshal(string szContent)
        {
            var tmp = JsonMapper.ToObject<PatchFileList>(szContent);
            if (tmp == null) return;
            this.MainVersion = tmp.MainVersion;
            this.FileList = tmp.FileList;
            this.UpdateVersion = tmp.UpdateVersion;
            this.OptionalPatchFileList = tmp.OptionalPatchFileList;
            this.isDone = true;
        }

        // VMA: 0x01bc7b95 — Source: KTO_DecompiledReference/KKUpdater/PatchFileList.c:120 (UnmarshalFromLocal factory)
        // <UnmarshalFromLocal>d__8.MoveNext (KKUpdater.PatchFileList/_UnmarshalFromLocal_d__8.c:51):
        //   isDone = false;
        //   if (File.Exists(path)) {
        //     using (StreamReader sr = File.OpenText(path)) {
        //       string content = sr.ReadToEnd();
        //       Unmarshal(content);
        //     }
        //   }
        //   yield return null;
        //   /* state advances to -1 */
        public IEnumerator UnmarshalFromLocal(string path)
        {
            isDone = false;
            if (File.Exists(path))
            {
                using (var sr = File.OpenText(path))
                {
                    string content = sr.ReadToEnd();
                    Unmarshal(content);
                }
            }
            yield return null;
        }

        // VMA: 0x01bc7c09 — Source: KTO_DecompiledReference/KKUpdater/PatchFileList.c:148 (UnmarshalFromUrl factory)
        // <UnmarshalFromUrl>d__9.MoveNext (KKUpdater.PatchFileList/_UnmarshalFromUrl_d__9.c:51):
        //   isDone = false;
        //   UnityWebRequest req = UnityWebRequest.Get(url);
        //   yield return req.SendWebRequest();
        //   if (req.result != ConnectionError && req.result != ProtocolError && req.isDone) {
        //     string text = req.downloadHandler.text;
        //     Unmarshal(text);
        //   }
        //   req.Dispose();
        public IEnumerator UnmarshalFromUrl(string url)
        {
            isDone = false;
            using (var req = UnityWebRequest.Get(url))
            {
                yield return req.SendWebRequest();
                if (req.result != UnityWebRequest.Result.ConnectionError
                    && req.result != UnityWebRequest.Result.ProtocolError
                    && req.isDone)
                {
                    if (req.downloadHandler != null)
                    {
                        string text = req.downloadHandler.text;
                        Unmarshal(text);
                    }
                }
            }
        }

        // VMA: 0x01bc7c7d — Source: KTO_DecompiledReference/KKUpdater/PatchFileList.c:177 (.ctor)
        // gốc body: System_Object___ctor(this, 0); — chain to base.
        public PatchFileList() { }
    }
}
