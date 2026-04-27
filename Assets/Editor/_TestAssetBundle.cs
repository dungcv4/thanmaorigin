using UnityEditor;
using UnityEngine;

public static class _TestAssetBundle
{
    public static void Execute()
    {
        var path = System.IO.Path.Combine(Application.streamingAssetsPath, "Bundles/Android/ui/views/res_p_134.ab");
        Debug.Log($"[TestAB] Path: {path}");
        Debug.Log($"[TestAB] Exists: {System.IO.File.Exists(path)}");

        var bundle = AssetBundle.LoadFromFile(path);
        Debug.Log($"[TestAB] Bundle: {(bundle == null ? "NULL — incompatible" : bundle.name)}");
        if (bundle != null)
        {
            var names = bundle.GetAllAssetNames();
            Debug.Log($"[TestAB] Assets in bundle: {names.Length}");
            foreach (var n in names) Debug.Log($"  - {n}");
            var prefab = bundle.LoadAsset<GameObject>("UILoginBG");
            Debug.Log($"[TestAB] LoadAsset<GameObject>(UILoginBG): {(prefab == null ? "NULL" : prefab.name)}");
            bundle.Unload(false);
        }
    }
}
