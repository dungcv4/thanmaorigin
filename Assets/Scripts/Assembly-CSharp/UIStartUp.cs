// Class: UIStartUp
// GUID:  2b741666d9ef59c2b2282670abae18e2 (preserved via .meta)
// Source: KTO_FullExtract — boot/loading-screen UI
//
// PARTIAL PORT 2026-04-25: API surface needed by UIModule. Real impl deferred.

using UnityEngine;

public class UIStartUp : MonoBehaviour
{
    public void SetProgress(float fProgress) { /* loading bar fill — defer */ }
    public void SetLoadingMainInfo(string msg) { /* loading bar text — defer */ }
    public void SetUpdateState(KKUpdater.UpdaterState state) { /* state visual — defer */ }
}
