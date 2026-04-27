// Dump SerializedField list for UnityEngine.UI.Text in Tuanjie.
// Helps identify if Tuanjie's Text class has different fields than what
// AssetRipper-extracted YAML uses.
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using System.Reflection;

public static class _DumpTextFields
{
    public static void Execute()
    {
        Debug.Log("[TXT_FIELDS] BEGIN");
        var t = typeof(UnityEngine.UI.Text);
        DumpFields(t, 0);
        Debug.Log("[TXT_FIELDS] === Image fields ===");
        DumpFields(typeof(UnityEngine.UI.Image), 0);
        Debug.Log("[TXT_FIELDS] END");
    }

    static void DumpFields(System.Type t, int depth)
    {
        if (t == null || t == typeof(object) || t == typeof(MonoBehaviour) || t == typeof(Component)) return;
        Debug.Log($"[TXT_FIELDS] {new string(' ', depth*2)}=== {t.FullName} ===");
        var fields = t.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.DeclaredOnly);
        foreach (var f in fields)
        {
            var ser = f.GetCustomAttribute<SerializeField>() != null || f.IsPublic;
            if (!ser) continue;
            Debug.Log($"[TXT_FIELDS] {new string(' ', depth*2)}  {f.Name} : {f.FieldType.Name}");
        }
        DumpFields(t.BaseType, depth + 1);
    }
}
