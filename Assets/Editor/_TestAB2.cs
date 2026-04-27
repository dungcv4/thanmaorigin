using UnityEditor;
using UnityEngine;

public static class _TestAB2
{
    public static void Execute()
    {
        Debug.Log("[TUANJIE_AB_TEST] BEGIN");
        var path = System.IO.Path.Combine(Application.streamingAssetsPath, "Bundles/Android/ui/views/res_p_134.ab");
        Debug.Log($"[TUANJIE_AB_TEST] Path: {path}");
        Debug.Log($"[TUANJIE_AB_TEST] Exists: {System.IO.File.Exists(path)}");

        var bundle = AssetBundle.LoadFromFile(path);
        Debug.Log($"[TUANJIE_AB_TEST] Bundle: {(bundle == null ? "NULL_INCOMPAT" : "LOADED:" + bundle.name)}");
        if (bundle != null)
        {
            var names = bundle.GetAllAssetNames();
            Debug.Log($"[TUANJIE_AB_TEST] Assets in bundle: {names.Length}");
            for (int i = 0; i < System.Math.Min(5, names.Length); i++)
                Debug.Log($"[TUANJIE_AB_TEST]   - {names[i]}");
            var prefab = bundle.LoadAsset<GameObject>("UILoginBG");
            Debug.Log($"[TUANJIE_AB_TEST] LoadAsset<GameObject>(UILoginBG): {(prefab == null ? "NULL" : prefab.name)}");
            bundle.Unload(false);
        }
        Debug.Log("[TUANJIE_AB_TEST] END");
    }
}
