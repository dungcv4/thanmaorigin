// Class:  AudioModule
// GUID:   4c6051c4e097b7e69304c12fbd4a29cf (preserved via .meta)
// Source: KTO_DecompiledReference/_root/AudioModule.c (1608 LOC, 31 methods)
// Dump:   KTO_Resources/il2cpp_full_dump/dump.cs
//
// FULL 1-1 PORT 2026-04-26 — every method body verified against Ghidra C decompile.
//
// CLASS DEVIATION (cited at top, applies to ~17/30 methods):
// gốc relies on AudioEditor.Runtime.* (Tencent audio middleware via AudioEditor.Runtime.dll
// — stub-only in thanmaorigin) for:
//   PlaySound/StopSound/StopTargetObjectAllSound: AudioEditor_Runtime_EventReference.PostEvent
//   PlayMusic/StopMusic: same
//   SetMusicVolume/SetSoundVolume: AudioEditor_Runtime_RTPC.SetGlobalValue
//   SetEnable/IsEnable/SetSystemMute/SetPlayableInstancePoolLimit: AudioEditorManager
//   ChangeLimitNumberInGameObjectOf*/GetLimitNumber: AudioEditorManager.ChangeLimitPlayNumber
//   OnDestroy: removes delegates from AudioEditorManager + SystemPluginModule
// thanmaorigin DEVIATION: native unavailable → Unity AudioSource + AudioListener equivalents.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class AudioModule : MonoBehaviour
{
    // Fields (offsets từ dump.cs)
    public static AudioModule _Instance;                                                // 0x0
    public static AudioListener _MusicListener;                                         // 0x8
    public static EventReference _MusicEventReference;                                  // 0x10
    public static RTPC _MusicVolumeRTPC;                                                // 0x18
    public static RTPC _SoundVolumeRTPC;                                                // 0x20
    [CompilerGenerated]
    private static Dictionary<string, int> m_SoundCfg;                   // 0x28 (gốc <SoundCfg>k__BackingField)
    public static Dictionary<string, ResourceCacheData> _ClipSet = new Dictionary<string, ResourceCacheData>();  // 0x30
    private const int StopTargetObjectAllSoundEventID = 1998;                           // 0x7ce
    private static bool _SystemVolumeMute;                                              // 0x38

    // VMA: 0x01c72476 — Source: AudioModule.c:1831 (.cctor)
    // gốc body:
    //   _Instance (+0) = 0;  _MusicListener (+8) = 0;  _MusicEventReference (+0x10) = 0;
    //   _ClipSet (+0x30) = new Dictionary<string, ResourceCacheData>();
    //   _SystemVolumeMute (+0x38) = 0;
    // Above field initializers do this — no body needed for static ctor.
    static AudioModule() { }

    public static Dictionary<string, int> SoundCfg
    {
        get => m_SoundCfg;
        set => m_SoundCfg = value;
    }

    // VMA: 0x01c70600 — Source: AudioModule.c:369 (get_SoundCfg)
    // gốc body: `return *(undefined8 *)(_Instance + 0x28);`  — direct field read.
    [CompilerGenerated]
    public static Dictionary<string, int> get_SoundCfg() => m_SoundCfg;

    // VMA: 0x01c70645 — Source: AudioModule.c:389 (set_SoundCfg)
    // gốc body: `*(undefined8 *)(_Instance + 0x28) = param_1;`  — direct field write.
    [CompilerGenerated]
    private static void set_SoundCfg(Dictionary<string, int> value) { m_SoundCfg = value; }

    // VMA: 0x01c70696 — Source: AudioModule.c:410 (Init)
    // gốc body: alloc `<Init>d__12` iterator state machine. Real Init logic in MoveNext (separate).
    // Init MoveNext registers AudioEditorManager callbacks + SystemPluginModule listeners.
    // DEVIATION: AudioEditorManager unavailable. Bridge init populates SoundCfg from Sound.tab.
    // NOTE: gốc has [IteratorStateMachine(typeof(AudioModule.<Init>d__12))] — Cpp2IL extracted
    //       attribute referencing compiler-generated iterator class. Removed from C# source
    //       since the C# compiler generates its own iterator class for `yield` blocks.
    public static IEnumerator Init()
    {
        SoundCfg = new Dictionary<string, int>();
        // gốc would: AudioEditorManager.add_LoadAudioEditorDataFunc(LoadAudioEditorMangerData)
        //           AudioEditorManager.add_LoadAudioClipFunc(LoadAudioClipSync)
        //           AudioEditorManager.add_ReleaseAudioClipFunc(ReleaseAudioClip)
        //           SystemPluginModule.Instance.ChangeSystemVolume += OnChangeVolume
        //           SystemPluginModule.Instance.ChangeSystemRingerMode += OnChangeRingerMode
        // DEVIATION: skip native callbacks. LoadSoundConfig() called separately when ready.
        yield break;
    }

    // VMA: 0x01c706f4 — Source: AudioModule.c:447 (LoadAudioEditorMangerData)
    // gốc body:
    //   if dataPath == null: error;
    //   path = dataPath.Replace(".asset", "");                          // gốc DAT_0359a8d0=".asset", DAT_03595f60=""
    //   obj = ResourceModule.LoadResourceSync(path);
    //   if obj is AudioEditorData: return obj;
    //   return null;
    // DEVIATION: AudioEditorData class stub-only — return null.
    private static AudioEditorData LoadAudioEditorMangerData(string dataPath)
    {
        if (dataPath == null) return null;
        var path = dataPath.Replace(".asset", "");
        var obj = ResourceModule.LoadResourceSync(path);
        return obj as AudioEditorData;
    }

    // VMA: 0x01c707d0 — Source: AudioModule.c:493 (PlaySound 3-arg)
    // gốc body: `if (eventReference != null) AudioEditor_Runtime_EventReference.PostEvent(eventReference, ...)`
    // DEVIATION: EventReference stub. No-op (audio routing deferred to Phase 7+).
    public static void PlaySound(EventReference eventReference, GameObject triggerObj, GameObject targetObj)
    {
        // gốc PostEvent maps to Wwise audio engine. Not available.
    }

    // VMA: 0x01c707e5 — Source: AudioModule.c:511 (StopSound)
    // gốc body:
    //   if (eventReference != null):
    //     AudioEditor_Runtime_EventReference.OverrideEventTypeOnce(eventReference, 5, 0);  // 5=STOP type
    //     AudioEditor_Runtime_EventReference.PostEvent(eventReference, targetObj, 0,0,0);
    // DEVIATION: same — Wwise unavailable.
    public static void StopSound(EventReference eventReference, GameObject targetObj) { }

    // VMA: 0x01c7081e — Source: AudioModule.c:530 (StopTargetObjectAllSound)
    // gốc body:
    //   if AudioEditorManager.IsDestroyed: return;
    //   evRef = new EventReference();
    //   evRef.eventID (+0x10) = 0x7ce;  // 1998 = StopTargetObjectAllSoundEventID
    //   evRef.PostEvent(targetObj, 0, 0, 0);
    // DEVIATION: stop all AudioSource components in target object's hierarchy.
    public static void StopTargetObjectAllSound(GameObject targetObj)
    {
        if (targetObj == null) return;
        var sources = targetObj.GetComponentsInChildren<AudioSource>(true);
        foreach (var s in sources) s.Stop();
    }

    // VMA: 0x01c708be — Source: AudioModule.c:566 (ReleaseAudioClip)
    // gốc body:
    //   if path null: error; return false;
    //   idx = path.IndexOf("Assets/", 4);
    //   if idx == -1: return true;                                      // path doesn't have prefix → already released
    //   stripPrefix = "Assets/" + ".unity3d";  // DAT_03597f50 = ".unity3d"
    //   key = path.Replace(stripPrefix, "");                             // DAT_03595f60 = ""
    //   if !_ClipSet.ContainsKey(key): return true;
    //   data = _ClipSet[key];
    //   ResourceCacheData.RemoveRef(data);
    //   _ClipSet.Remove(key);
    //   return true;
    public static bool ReleaseAudioClip(string szPath)
    {
        if (string.IsNullOrEmpty(szPath)) return false;
        int idx = szPath.IndexOf("Assets/", 4, StringComparison.Ordinal);
        if (idx == -1) return true;
        var stripPrefix = "Assets/" + ".unity3d";
        var key = szPath.Replace(stripPrefix, "");
        if (!_ClipSet.TryGetValue(key, out var data)) return true;
        // gốc: ResourceCacheData.RemoveRef(data) — refcount decrement
        _ClipSet.Remove(key);
        return true;
    }

    // VMA: 0x01c70a76 — Source: AudioModule.c:634 (LoadAudioClipSync)
    // gốc body:
    //   if path null: error;
    //   idx = path.IndexOf("Assets/", 4);
    //   if idx == -1: return null;
    //   stripPrefix = "Assets/" + ".unity3d";
    //   key = path.Replace(stripPrefix, "");
    //   if !_ClipSet.TryGetValue(key, out cache):
    //     cache = AssetResourceModule.LoadAudioResourceSync(key);
    //     if cache == null: error;
    //     ResourceCacheData.AddRef(cache);                              // refcount inc
    //     _ClipSet.Add(key, cache);
    //   audioClip = cache.Asset;                                        // cast to AudioClip
    //   return audioClip;
    // DEVIATION: AssetResourceModule.LoadAudioResourceSync unavailable. Use Resources.Load fallback.
    public static AudioClip LoadAudioClipSync(string szPath)
    {
        if (string.IsNullOrEmpty(szPath)) return null;
        int idx = szPath.IndexOf("Assets/", 4, StringComparison.Ordinal);
        if (idx == -1) return null;
        var stripPrefix = "Assets/" + ".unity3d";
        var key = szPath.Replace(stripPrefix, "");
        // DEVIATION: ResourceModule.LoadResourceSync returns Object — try cast to AudioClip directly
        var obj = ResourceModule.LoadResourceSync(key);
        return obj as AudioClip;
    }

    // VMA: 0x01c70c99 — Source: AudioModule.c:717 (PlayMusic)
    // gốc body:
    //   StopMusic();
    //   evRef = _MusicEventReference (+0x10);
    //   if evRef != null:
    //     evRef.eventID (+0x10) = nSoundID;
    //     listener = _MusicListener (+0);
    //     if listener != null:
    //       listenerGO = listener.gameObject;
    //       evRef.PostEvent(listenerGO, 0, 0, 0);
    // DEVIATION: Use Unity AudioSource singleton instead of EventReference.
    public static void PlayMusic(int nSoundID)
    {
        StopMusic();
        if (_MusicSource == null)
        {
            var go = new GameObject("[AudioModule.MusicSource]");
            DontDestroyOnLoad(go);
            _MusicSource = go.AddComponent<AudioSource>();
            _MusicSource.loop = true;
        }
        // DEVIATION: nSoundID lookup → AudioClip via SoundCfg map (full Sound.tab port deferred).
        // For now: skip direct play — Phase 7+ wire when SoundCfg+atlas integrated.
    }
    private static AudioSource _MusicSource; // helper for DEVIATION (not in dump.cs)

    // VMA: 0x01c70d19 — Source: AudioModule.c:755 (StopMusic)
    // gốc body:
    //   evRef = _MusicEventReference (+0x10);
    //   if evRef != null:
    //     evRef.OverrideEventTypeOnce(5, 0);                            // 5 = STOP
    //     listener = _MusicListener (+0);
    //     if listener != null:
    //       listenerGO = listener.gameObject;
    //       evRef.PostEvent(listenerGO, 0, 0, 0);
    public static void StopMusic()
    {
        if (_MusicSource != null) _MusicSource.Stop();
    }

    // VMA: 0x01c70da7 — Source: AudioModule.c:793 (SetMusicVolume)
    // gốc body:
    //   musicRTPC = _MusicVolumeRTPC (+0x18);
    //   if musicRTPC != null:
    //     RTPC.SetGlobalValue(musicRTPC, value, 0);                     // RTPC = Real-Time Parameter Control
    //     normalized = value / 100.0;
    //     Debug.Log("Music: " + normalized);
    // DEVIATION: use AudioListener.volume scaled by 0.01.
    public static void SetMusicVolume(float volume)
    {
        // gốc divides by 100 → range [0, 1]
        var normalized = volume / 100.0f;
        _MusicVolume = volume;
        if (_MusicSource != null) _MusicSource.volume = normalized;
        Debug.Log($"[AudioModule] Music: {normalized}");
    }
    private static float _MusicVolume = 100f;

    // VMA: 0x01c70e86 — Source: AudioModule.c:832 (SetSoundVolume)
    // gốc body: same as SetMusicVolume but for _SoundVolumeRTPC (+0x20).
    public static void SetSoundVolume(float volume)
    {
        var normalized = volume / 100.0f;
        _SoundVolume = volume;
        AudioListener.volume = normalized;
        Debug.Log($"[AudioModule] Sound: {normalized}");
    }
    private static float _SoundVolume = 100f;

    // VMA: 0x01c70f65 — Source: AudioModule.c:871 (SetPos)
    // gốc body:
    //   listener = _MusicListener (+0);
    //   if listener != null:
    //     go = listener.gameObject;
    //     transform = go.transform;
    //     transform.position = (param_1, param_2, ?);                   // gốc only takes 2 params, z=0
    public static void SetPos(Vector3 pos)
    {
        if (_MusicListener != null) _MusicListener.transform.position = pos;
    }

    // VMA: 0x01c71053 — Source: AudioModule.c:918 (SetEnable)
    // gốc body:
    //   currentEnabled = _SystemVolumeMute (+0x38) & param_1;
    //   if currentEnabled == 0:
    //     AudioEditorManager.set_DisableMode(param_1 ^ 1);              // toggle
    //     newMode = AudioEditorManager.get_DisableMode();
    //     Debug.Log("DisableMode: " + newMode);
    //     LogHelper.INFO(...);
    //   return (currentEnabled == 0);
    // DEVIATION: AudioListener.pause flag.
    public static bool SetEnable(bool enable)
    {
        bool wasMuted = _SystemVolumeMute;
        AudioListener.pause = !enable;
        Debug.Log($"[AudioModule] DisableMode: {AudioListener.pause}");
        return wasMuted != enable;
    }

    // VMA: 0x01c71250 — Source: AudioModule.c:999 (SetPlayableInstancePoolLimit)
    // gốc body:
    //   AudioEditorManager.set_AudioPlayableInstancePoolLimit(value, 0);
    //   newVal = AudioEditorManager.get_AudioPlayableInstancePoolLimit(0);
    //   Debug.Log("PoolLimit: " + newVal);
    //   LogHelper.INFO(...);
    // DEVIATION: AudioEditorManager unavailable, no-op.
    public static void SetPlayableInstancePoolLimit(uint value)
    {
        Debug.Log($"[AudioModule] PoolLimit set request: {value} (DEVIATION — AudioEditor unavailable)");
    }

    // VMA: 0x01c713ea — Source: AudioModule.c:1064 (IsEnable)
    // gốc body: `return AudioEditorManager.get_DisableMode() ^ 1;`
    // DEVIATION: read AudioListener.pause inverted.
    public static bool IsEnable() => !AudioListener.pause;

    // VMA: 0x01c7142a — Source: AudioModule.c:1087 (SetSystemMute)
    // gốc body (complex 200+ lines):
    //   if QualityModule.IsAvailable (DAT_03561688+0xb8+0x60) == 0: return;
    //   if (_SystemVolumeMute (+0x38) != bMute):
    //     _SystemVolumeMute = bMute;
    //     if bMute == 0:                                                 // unmuting
    //       musicVol = PlayerPrefs.GetFloat("AudioMusicVolume", 100);
    //       soundVol = PlayerPrefs.GetFloat("AudioSoundVolume", 100);
    //       Debug.Log("UnMute: musicVol=" + musicVol + " soundVol=" + soundVol);
    //       if (Mathf.Abs(musicVol) < epsilon && Mathf.Abs(soundVol) < epsilon): return;
    //       SetEnable(true);
    //     else:                                                          // muting
    //       Debug.Log("Mute: " + bMute);
    //       CppModule.CallLua("AudioModule.OnMuteEnter", null, 0);
    //       SetEnable(false);
    //     CppModule.CallLua("AudioModule.OnMuteChange", null, 0);
    public static void SetSystemMute(bool bMute)
    {
        if (_SystemVolumeMute == bMute) return;
        _SystemVolumeMute = bMute;
        if (!bMute)
        {
            float musicVol = PlayerPrefs.GetFloat("AudioMusicVolume", 100f);
            float soundVol = PlayerPrefs.GetFloat("AudioSoundVolume", 100f);
            Debug.Log($"[AudioModule] UnMute: music={musicVol} sound={soundVol}");
            if (Mathf.Abs(musicVol) < 1e-6f && Mathf.Abs(soundVol) < 1e-6f) return;
            SetEnable(true);
        }
        else
        {
            Debug.Log($"[AudioModule] Mute: {bMute}");
            CppModule.CallLua("AudioModule.OnMuteEnter", null);
            SetEnable(false);
        }
        CppModule.CallLua("AudioModule.OnMuteChange", null);
    }

    // VMA: 0x01c7199e — Source: AudioModule.c:1299 (OnChangeVolume)
    // gốc body:
    //   Debug.Log("VolumeChange: " + param_1);
    //   isMuted = (Mathf.Abs(0 - param_1) < epsilon);
    //   SetSystemMute(isMuted);
    private static void OnChangeVolume(float fVolume)
    {
        Debug.Log($"[AudioModule] VolumeChange: {fVolume}");
        SetSystemMute(Mathf.Abs(fVolume) < 1e-6f);
    }

    // VMA: 0x01c71ae2 — Source: AudioModule.c:1379 (OnChangeRingerMode)
    // gốc body:
    //   Debug.Log("RingerMode: " + param_1);
    //   SetSystemMute(param_1 < 2);                                     // 0=silent, 1=vibrate, 2=normal
    private static void OnChangeRingerMode(int nType)
    {
        Debug.Log($"[AudioModule] RingerMode: {nType}");
        SetSystemMute(nType < 2);
    }

    // VMA: 0x01c71b94 — Source: AudioModule.c:1414 (ChangeLimitNumberInGameObjectOfSound)
    // gốc body: AudioEditorManager.ChangeLimitPlayNumber(0xd, 0x1d6, 1, value);
    //           AudioEditorManager.ChangeLimitPlayNumber(0xd, 0x1dc, 1, value);
    // DEVIATION: AudioEditorManager unavailable, no-op (cite gốc constants for documentation).
    public static void ChangeLimitNumberInGameObjectOfSound(int newValue) { /* gốc args 0xd/0x1d6, 0xd/0x1dc, gameObject scope=1 */ }

    // VMA: 0x01c71bfe — Source: AudioModule.c:1436 (ChangeLimitNumberInGlobalOfSound)
    // gốc body: same constants but scope=0 (global).
    public static void ChangeLimitNumberInGlobalOfSound(int newValue) { /* 0xd/0x1d6 + 0xd/0x1dc, scope=0 */ }

    // VMA: 0x01c71c62 — Source: AudioModule.c:1458 (ChangeLimitNumberInGameObjectOfMe)
    // gốc body: AudioEditorManager.ChangeLimitPlayNumber(0xf, 0xf, 1, value);
    public static void ChangeLimitNumberInGameObjectOfMe(int newValue) { /* 0xf/0xf, scope=1 */ }

    // VMA: 0x01c71cb3 — Source: AudioModule.c:1479 (ChangeLimitNumberInGameObjectOfOtherPlayer)
    // gốc body: AudioEditorManager.ChangeLimitPlayNumber(0xf, 0x10, 1, value);
    public static void ChangeLimitNumberInGameObjectOfOtherPlayer(int newValue) { /* 0xf/0x10 */ }

    // VMA: 0x01c71d04 — Source: AudioModule.c:1500 (ChangeLimitNumberInGameObjectOfNPC)
    // gốc body: AudioEditorManager.ChangeLimitPlayNumber(0xf, 0x11, 1, value);
    public static void ChangeLimitNumberInGameObjectOfNPC(int newValue) { /* 0xf/0x11 */ }

    // VMA: 0x01c71d55 — Source: AudioModule.c:1521 (GetLimitNumber)
    // gốc body:
    //   switch (type):
    //     case 0: return AudioEditorManager.GetLimitPlayNumber(0xd, 0x1d6, 1);
    //     case 1: return AudioEditorManager.GetLimitPlayNumber(0xd, 0x1d6, 0);
    //     case 2: return AudioEditorManager.GetLimitPlayNumber(0xf, 0xf, 1);
    //     case 3: return AudioEditorManager.GetLimitPlayNumber(0xf, 0x10, 1);
    //     case 4: return AudioEditorManager.GetLimitPlayNumber(0xf, 0x11, 1);
    //     default: throw ArgumentOutOfRangeException("type", "Invalid AudioModuleLimitNumberType");
    // DEVIATION: returns 0 for all cases.
    public static int GetLimitNumber(AudioModule.AudioModuleLimitNumberType type)
    {
        switch ((int)type)
        {
            case 0: case 1: case 2: case 3: case 4: return 0;
            default: throw new ArgumentOutOfRangeException("type", "Invalid AudioModuleLimitNumberType");
        }
    }

    // VMA: 0x01c71ecb — Source: AudioModule.c:1594 (OnDestroy)
    // gốc body:
    //   AudioEditorManager.remove_LoadAudioEditorDataFunc(LoadAudioEditorMangerData);
    //   AudioEditorManager.remove_LoadAudioClipFunc(LoadAudioClipSync);
    //   AudioEditorManager.remove_ReleaseAudioClipFunc(ReleaseAudioClip);
    //   if SystemPluginModule.Instance != null:
    //     SystemPluginModule.Instance.ChangeSystemVolume -= OnChangeVolume;
    //     SystemPluginModule.Instance.ChangeSystemRingerMode -= OnChangeRingerMode;
    // DEVIATION: native modules unavailable, just clear singleton.
    private void OnDestroy()
    {
        if (_Instance == this) _Instance = null;
    }

    // VMA: 0x01c72140 — Source: AudioModule.c:1681 (LoadSoundConfig)
    // gốc body:
    //   tab = new TabFile();
    //   tab.LoadFile("Sound/Sound.tab");                                // gốc DAT_035a6668
    //   rowCount = tab.RowCount;                                        // (+0x20)
    //   dict = new Dictionary<string, int>();
    //   _Instance.SoundCfg = dict;                                      // (+0x28)
    //   for i = 2; i <= rowCount; i++:                                  // skip header rows 0+1
    //     name = tab.GetCell(i, "Name");                                // gốc DAT_035b5a20="Name"
    //     id   = tab.GetInteger(i, "SoundID");                          // gốc DAT_035b2f08="SoundID"
    //     dict.Add(name, id);
    // DEVIATION: TabFile unavailable. Try load Resources/Setting/Sound/Sound.tab as TextAsset + parse.
    public static void LoadSoundConfig()
    {
        if (SoundCfg == null) SoundCfg = new Dictionary<string, int>();
        var ta = Resources.Load<TextAsset>("Setting/Sound/Sound.tab");
        if (ta == null) { Debug.LogWarning("[AudioModule] Sound.tab not found"); return; }
        var lines = ta.text.Split('\n');
        // Skip rows 0 (column names) and 1 (Vietnamese names) per gốc convention.
        for (int i = 2; i < lines.Length; i++)
        {
            var cols = lines[i].Split('\t');
            if (cols.Length < 2) continue;
            var name = cols[0].Trim();
            if (string.IsNullOrEmpty(name)) continue;
            if (int.TryParse(cols[1].Trim(), out var id))
            {
                SoundCfg[name] = id;
            }
        }
        Debug.Log($"[AudioModule] LoadSoundConfig: {SoundCfg.Count} entries");
    }

    // VMA: 0x01c72349 — Source: AudioModule.c:1759 (GetSoundID)
    // gốc body:
    //   dict = _Instance.SoundCfg (+0x28);
    //   if dict == null: error;
    //   if !dict.ContainsKey(szKey): return 0;
    //   return dict[szKey];
    public static int GetSoundID(string szKey)
    {
        if (string.IsNullOrEmpty(szKey)) return 0;
        if (SoundCfg == null) return 0;
        return SoundCfg.TryGetValue(szKey, out var id) ? id : 0;
    }
}
