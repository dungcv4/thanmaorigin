// Trigger KTO menu "Build 5 Critical Login Bundles" to rebuild res_p_137 (UILoginServer)
// + 4 other login bundles. Picks up the latest prefab edits (btnChange/Image arrow restore).
using UnityEditor;
using UnityEngine;

public static class TriggerCriticalLoginBundleRebuild
{
    public static void Execute()
    {
        Debug.Log("=== Trigger 'KTO/Build/Build 5 Critical Login Bundles' ===");
        bool ok = EditorApplication.ExecuteMenuItem("KTO/Build/Build 5 Critical Login Bundles");
        Debug.Log("  ExecuteMenuItem returned: " + ok);
    }
}
