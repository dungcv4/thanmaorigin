// File: Assets/_Project/Scripts/Resource/KKUpdater.cs
// Phase 2 of 2-phase loading — fetch PatchFileList.json from LocalCDN.
// Source: KTO_DecompiledReference/KKUpdater/{RemoteVersion, KUpdaterMgr}.c
//
// gốc URL: SerializeCdnUrl(BaseURL + version + bundleRel) → Tencent CDN.
// DEVIATION: BaseURL = http://localhost:8888/ (thanmaorigin LocalCDN).

using System;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

namespace ThanMaOrigin.Resource
{
    public static class KKUpdater
    {
        public const string BaseUrl = "http://localhost:8888/";

        /// <summary>
        /// Fetch PatchFileList.json from LocalCDN. Equivalent to
        /// KKUpdater.RemoteVersion.TryGetVersionInfo + UnmarshalFromUrl.
        /// </summary>
        public static IEnumerator GetRemotePatchFileList(Action<string?> onComplete)
        {
            var url = BaseUrl + "PatchFileList.json";
            using var req = UnityWebRequest.Get(url);
            yield return req.SendWebRequest();

            if (req.result == UnityWebRequest.Result.Success)
            {
                Debug.Log($"[KKUpdater] Remote manifest fetched: {req.downloadHandler.data.Length} bytes");
                onComplete?.Invoke(req.downloadHandler.text);
            }
            else
            {
                Debug.LogError($"[KKUpdater] Remote manifest fetch failed: {req.error}");
                onComplete?.Invoke(null);
            }
        }

        /// <summary>
        /// Compare local APK manifest version vs remote LocalCDN manifest.
        /// Returns true if remote is newer (need patch download).
        /// </summary>
        public static bool NeedPatch(string localManifestJson, string remoteManifestJson)
        {
            try
            {
                int local = ExtractUpdateVersion(localManifestJson);
                int remote = ExtractUpdateVersion(remoteManifestJson);
                Debug.Log($"[KKUpdater] Local v{local}, Remote v{remote}");
                return remote > local;
            }
            catch (Exception e)
            {
                Debug.LogError($"[KKUpdater] NeedPatch parse error: {e.Message}");
                return false;
            }
        }

        private static int ExtractUpdateVersion(string json)
        {
            // Simple regex match (avoid full JSON parse for one int).
            var m = System.Text.RegularExpressions.Regex.Match(json, @"""UpdateVersion""\s*:\s*(\d+)");
            return m.Success ? int.Parse(m.Groups[1].Value) : 0;
        }

        /// <summary>
        /// Read APK-baked manifest from StreamingAssets (Phase 1 of 2-phase).
        /// </summary>
        public static IEnumerator ReadLocalManifest(Action<string?> onComplete)
        {
            var path = Path.Combine(Application.streamingAssetsPath, "PatchFileList.json");
            // StreamingAssets on Android needs UnityWebRequest; on Editor/Standalone, File.ReadAllText works.
            if (Application.platform == RuntimePlatform.Android || path.StartsWith("jar:"))
            {
                using var req = UnityWebRequest.Get(path);
                yield return req.SendWebRequest();
                if (req.result == UnityWebRequest.Result.Success)
                    onComplete?.Invoke(req.downloadHandler.text);
                else
                    onComplete?.Invoke(null);
            }
            else
            {
                if (File.Exists(path))
                    onComplete?.Invoke(File.ReadAllText(path));
                else
                    onComplete?.Invoke(null);
            }
        }
    }
}
