// Class:  HttpModule
// GUID:   a5c57c3221a24034190fe96f8d74c995 (preserved via .meta)
// Source: KTO_DecompiledReference/_root/HttpModule.c (2 methods)
//
// 1-1 PORT 2026-04-27 (minimal): gốc Get(url, callback) does HTTP GET via
// CoroutineManager.StartCor(HttpGet(url, callback)) where HttpGet builds an
// IEnumerator state object. Lua call: Client.HttpModule.Get(szUrl, funcCallback).
// Used by Script_ClientBulletin_ClientBulletin.lua:174 for bulletin fetch.
//
// thanmaorigin uses UnityWebRequest as 1-1 equivalent of gốc IEnumerator pattern.
// DEVIATION: gốc CoroutineManager.StartCor not yet ported → use MonoBehaviour.StartCoroutine
// from a singleton runner. Both produce identical end-result: callback invoked with response.

using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using XLua;

public class HttpModule : MonoBehaviour
{
    private static HttpModule _Instance;

    private void Awake()
    {
        if (_Instance != null && _Instance != this) { Destroy(this); return; }
        _Instance = this;
    }

    private static HttpModule Ensure()
    {
        if (_Instance != null) return _Instance;
        var go = new GameObject("[HttpModule]");
        DontDestroyOnLoad(go);
        return go.AddComponent<HttpModule>();
    }

    // VMA: 0x01a72118 — Source: KTO_DecompiledReference/_root/HttpModule.c HttpModule__Get
    // gốc body: var iter = HttpModule.HttpGet(url, callback); CoroutineManager.StartCor(iter);
    // 1-1: build coroutine + run on persistent runner.
    public static void Get(string szUrl, LuaFunction funcCallback)
    {
        var runner = Ensure();
        runner.StartCoroutine(runner.HttpGetCoroutine(szUrl, funcCallback));
    }

    // VMA: 0x01a72170 — Source: HttpModule.c HttpModule__HttpGet
    // gốc body: returns IEnumerator state object (UnityWebRequest send + yield + invoke callback).
    private IEnumerator HttpGetCoroutine(string szUrl, LuaFunction funcCallback)
    {
        if (string.IsNullOrEmpty(szUrl))
        {
            // Empty URL: invoke callback with empty content, matches gốc UnityWebRequest fail path.
            funcCallback?.Call("", "no_url");
            yield break;
        }

        using (var req = UnityWebRequest.Get(szUrl))
        {
            req.timeout = 10;
            yield return req.SendWebRequest();

            string content = "";
            string error = null;
            if (req.result == UnityWebRequest.Result.Success)
            {
                content = req.downloadHandler != null ? req.downloadHandler.text : "";
            }
            else
            {
                error = req.error;
            }
            try
            {
                if (funcCallback != null) funcCallback.Call(content, error);
            }
            catch (Exception e)
            {
                Debug.LogWarning($"[HttpModule.Get] callback throw: {e.Message}");
            }
        }
    }
}
