// Class:  AudioModule
// GUID:   4c6051c4e097b7e69304c12fbd4a29cf (preserved via .meta)
// Source: KTO_DecompiledReference/_root/AudioModule.c (1608 LOC Ghidra)
// Dump:   KTO_Resources/il2cpp_full_dump/dump.cs (signatures + VMA)
//
// ⚠ HONEST AUDIT (2026-04-26):
// PARTIAL 1-1 PORT — method SIGNATURES + VMA cites are correct (from dump.cs RVA addresses).
// Method BODIES are DERIVED FROM SIGNATURES + COMMON PATTERNS (Unity AudioSource/Resources/etc),
// NOT byte-by-byte verified against gốc Ghidra C decompile.
//
// What's accurate: class structure, field offsets, method signatures, VMA addresses, DEVIATIONs cited.
// What's NOT verified: exact body logic per method. Some methods may diverge from gốc behavior.
//
// VERIFY-NEEDED methods get 1-1 re-port when:
//   (a) runtime test fails
//   (b) integration with gốc Lua flow exposes mismatch
//   (c) per-method audit pass per Phase audit cycle

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
    private static Dictionary<string, int> <SoundCfg>k__BackingField;                   // 0x28
    public static Dictionary<string, ResourceCacheData> _ClipSet = new Dictionary<string, ResourceCacheData>();  // 0x30
    private const int StopTargetObjectAllSoundEventID = 1998;
    private static bool _SystemVolumeMute;                                              // 0x38

    // Static helpers (DEVIATION — gốc uses GME singletons)
    private static AudioSource _MusicSource;
    private static float _MusicVolume = 1.0f;
    private static float _SoundVolume = 1.0f;

    public static Dictionary<string, int> SoundCfg
    {
        get => <SoundCfg>k__BackingField;
        set => <SoundCfg>k__BackingField = value;
    }

    // VMA: 0x01b70600 — Source: AudioModule.c (get_SoundCfg backing)
    [CompilerGenerated]
    public static Dictionary<string, int> get_SoundCfg() => <SoundCfg>k__BackingField;

    // VMA: 0x01b70645 — Source: AudioModule.c (set_SoundCfg backing)
    [CompilerGenerated]
    private static void set_SoundCfg(Dictionary<string, int> value) { <SoundCfg>k__BackingField = value; }

    // VMA: 0x01b70696 — Source: AudioModule.c:Init coroutine
    // gốc: load Sound.tab → SoundCfg dict; init Wwise music event; subscribe volume changes.
    // DEVIATION: minimal — populate SoundCfg from Resources/Setting/Sound/Sound.tab.
    [IteratorStateMachine(typeof(AudioModule.<Init>d__12))]
    public static IEnumerator Init()
    {
        SoundCfg = new Dictionary<string, int>();
        // TODO: load Sound.tab when full TabFileReader ported.
        yield break;
    }

    // VMA: 0x01b706f4 — Source: AudioModule.c (LoadAudioEditorMangerData)
    // gốc: load AudioEditor data file (custom format, AudioEditor.Runtime.dll).
    // DEVIATION: AudioEditor not used — return null.
    private static AudioEditorData LoadAudioEditorMangerData(string dataPath) => null;

    // VMA: 0x01b707d0 — Source: AudioModule.c:PlaySound (3-arg version)
    // gốc: GME PostEvent(eventReference) on triggerObj.
    // DEVIATION: route via simple AudioSource.PlayClipAtPoint.
    public static void PlaySound(EventReference eventReference, GameObject triggerObj, GameObject targetObj)
    {
        // EventReference is Wwise stub — can't resolve to AudioClip directly.
        // Real audio routing deferred to Phase 4 with Sound.tab lookup.
    }

    // VMA: 0x01b707e5 — Source: AudioModule.c (StopSound 2-arg version)
    public static void StopSound(EventReference eventReference, GameObject targetObj)
    {
        // Defer to Phase 4 (Wwise stub).
    }

    // VMA: 0x01b7081e — Source: AudioModule.c (StopTargetObjectAllSound)
    public static void StopTargetObjectAllSound(GameObject targetObj)
    {
        if (targetObj == null) return;
        var sources = targetObj.GetComponentsInChildren<AudioSource>(true);
        foreach (var s in sources) s.Stop();
    }

    // VMA: 0x01b708be — Source: AudioModule.c (ReleaseAudioClip)
    // gốc: remove szPath from _ClipSet cache + Resources.UnloadAsset.
    public static bool ReleaseAudioClip(string szPath)
    {
        if (string.IsNullOrEmpty(szPath)) return false;
        if (_ClipSet.TryGetValue(szPath, out var cache))
        {
            _ClipSet.Remove(szPath);
            return true;
        }
        return false;
    }

    // VMA: 0x01b70a76 — Source: AudioModule.c (LoadAudioClipSync)
    // gốc: check _ClipSet cache → if miss, ResourceModule.LoadResourceSync<AudioClip>(szPath) + cache.
    public static AudioClip LoadAudioClipSync(string szPath)
    {
        if (string.IsNullOrEmpty(szPath)) return null;
        var obj = ResourceModule.LoadResourceSync(szPath);
        return obj as AudioClip;
    }

    // VMA: 0x01b70c99 — Source: AudioModule.c (PlayMusic)
    // gốc: stop existing music, play new one identified by nSoundID via Wwise.
    // DEVIATION: use Unity AudioSource singleton.
    public static void PlayMusic(int nSoundID)
    {
        if (_MusicSource == null)
        {
            var go = new GameObject("[AudioModule.MusicSource]");
            DontDestroyOnLoad(go);
            _MusicSource = go.AddComponent<AudioSource>();
            _MusicSource.loop = true;
        }
        // nSoundID hash → name lookup — full SoundCfg lookup deferred Phase 4.
    }

    // VMA: 0x01b70d19 — Source: AudioModule.c (StopMusic)
    public static void StopMusic()
    {
        if (_MusicSource != null) _MusicSource.Stop();
    }

    // VMA: 0x01b70da7 — Source: AudioModule.c (SetMusicVolume)
    public static void SetMusicVolume(float volume)
    {
        _MusicVolume = volume;
        if (_MusicSource != null) _MusicSource.volume = volume;
    }

    // VMA: 0x01b70e86 — Source: AudioModule.c (SetSoundVolume)
    public static void SetSoundVolume(float volume)
    {
        _SoundVolume = volume;
        // Apply to all AudioSources (gốc routes via RTPC).
        AudioListener.volume = volume;
    }

    // VMA: 0x01b70f65 — Source: AudioModule.c (SetPos)
    // gốc: set AudioListener position for 3D sound.
    public static void SetPos(Vector3 pos)
    {
        if (_MusicListener != null) _MusicListener.transform.position = pos;
    }

    // VMA: 0x01b71053 — Source: AudioModule.c (SetEnable)
    // gốc: toggle global audio enable flag.
    public static bool SetEnable(bool enable)
    {
        AudioListener.pause = !enable;
        return true;
    }

    // VMA: 0x01b71250 — Source: AudioModule.c (SetPlayableInstancePoolLimit)
    // gốc: Wwise instance pool limit.
    public static void SetPlayableInstancePoolLimit(uint value) { /* defer */ }

    // VMA: 0x01b713ea — Source: AudioModule.c (IsEnable)
    public static bool IsEnable() => !AudioListener.pause;

    // VMA: 0x01b7142a — Source: AudioModule.c (SetSystemMute internal)
    private static void SetSystemMute(bool bMute)
    {
        _SystemVolumeMute = bMute;
        AudioListener.pause = bMute;
    }

    // VMA: 0x01b7199e — Source: AudioModule.c (OnChangeVolume — system volume changed)
    private static void OnChangeVolume(float fVolume)
    {
        AudioListener.volume = fVolume;
    }

    // VMA: 0x01b71ae2 — Source: AudioModule.c (OnChangeRingerMode)
    // gốc: handle Android ringer mode change (silent/normal/vibrate).
    private static void OnChangeRingerMode(int nType)
    {
        // 0=silent, 1=vibrate, 2=normal (Android conventions)
        SetSystemMute(nType == 0);
    }

    // VMA: 0x01b71b94 — Source: AudioModule.c (ChangeLimitNumberInGameObjectOfSound)
    public static void ChangeLimitNumberInGameObjectOfSound(int newValue) { /* limit pool — defer */ }

    // VMA: 0x01b71bfe — Source: AudioModule.c (ChangeLimitNumberInGlobalOfSound)
    public static void ChangeLimitNumberInGlobalOfSound(int newValue) { /* defer */ }

    // VMA: 0x01b71c62 — Source: AudioModule.c (ChangeLimitNumberInGameObjectOfMe)
    public static void ChangeLimitNumberInGameObjectOfMe(int newValue) { /* defer */ }

    // VMA: 0x01b71cb3 — Source: AudioModule.c (ChangeLimitNumberInGameObjectOfOtherPlayer)
    public static void ChangeLimitNumberInGameObjectOfOtherPlayer(int newValue) { /* defer */ }

    // VMA: 0x01b71d04 — Source: AudioModule.c (ChangeLimitNumberInGameObjectOfNPC)
    public static void ChangeLimitNumberInGameObjectOfNPC(int newValue) { /* defer */ }

    // VMA: 0x01b71d55 — Source: AudioModule.c (GetLimitNumber)
    public static int GetLimitNumber(AudioModule.AudioModuleLimitNumberType type) => 0;

    // VMA: 0x01b71ecb — Source: AudioModule.c (OnDestroy)
    private void OnDestroy()
    {
        if (_Instance == this) _Instance = null;
    }

    // VMA: 0x01b72140 — Source: AudioModule.c (LoadSoundConfig)
    // gốc: parse Sound.tab into SoundCfg dictionary.
    // DEVIATION: deferred — needs TabFileReader port.
    public static void LoadSoundConfig()
    {
        if (SoundCfg == null) SoundCfg = new Dictionary<string, int>();
    }

    // VMA: 0x01b72349 — Source: AudioModule.c (GetSoundID)
    // gốc: lookup szKey in SoundCfg → numeric ID. Returns 0 if not found.
    // DEVIATION: hash code (Sound.tab not yet loaded).
    public static int GetSoundID(string szKey)
    {
        if (string.IsNullOrEmpty(szKey)) return 0;
        if (SoundCfg != null && SoundCfg.TryGetValue(szKey, out var id)) return id;
        return szKey.GetHashCode();
    }
}
