// AUTO-GENERATED skeleton from gốc IL2CPP dump.
// Class:   AudioModule
// GUID:    4c6051c4e097b7e69304c12fbd4a29cf
// Source:  /Users/vsf-user-l/Documents/Test/alo/KTO_Resources/il2cpp_full_dump/dump.cs (dump.cs class block)
// Ghidra:  /Users/vsf-user-l/Documents/Test/alo/KTO_DecompiledReference/_root/AudioModule.c
// VMA cites embedded in method comments below.
//
// PORTING WORKFLOW:
//   1. Each method has VMA cite (RVA: 0x...).
//   2. Body currently throws NotImplementedException.
//   3. Look up VMA in Ghidra file → port body 1-1.
//   4. After port: remove `throw new ...` + add `// VMA: 0x...` cite at method start.
//
// RULES (CLAUDE.md):
//   - 100% từ gốc, KHÔNG chế cháo.
//   - Mọi method PHẢI có comment // Source: <file>:<line> hoặc // VMA: 0x...
//   - Nếu DEVIATION (Cpp2IL stub trống / server-side / Unity API gone): ASK USER trước.

using System;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class AudioModule : MonoBehaviour
{

	// Fields
	public static AudioModule _Instance; // 0x0
	public static AudioListener _MusicListener; // 0x8
	public static EventReference _MusicEventReference; // 0x10
	public static RTPC _MusicVolumeRTPC; // 0x18
	public static RTPC _SoundVolumeRTPC; // 0x20
	[CompilerGenerated]
	private static Dictionary<string, int> <SoundCfg>k__BackingField; // 0x28
	public static Dictionary<string, ResourceCacheData> _ClipSet; // 0x30
	private const int StopTargetObjectAllSoundEventID = 1998;
	private static bool _SystemVolumeMute; // 0x38

	// Properties
	public static Dictionary<string, int> SoundCfg { get; set; }

	// Methods

	[CompilerGenerated]
	// RVA: 0x1B70600 Offset: 0x1B6C600 VA: 0x1B70600
	public static Dictionary<string, int> get_SoundCfg() { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	[CompilerGenerated]
	// RVA: 0x1B70645 Offset: 0x1B6C645 VA: 0x1B70645
	private static void set_SoundCfg(Dictionary<string, int> value) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	[IteratorStateMachine(typeof(AudioModule.<Init>d__12))]
	// RVA: 0x1B70696 Offset: 0x1B6C696 VA: 0x1B70696
	public static IEnumerator Init() { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B706F4 Offset: 0x1B6C6F4 VA: 0x1B706F4
	private static AudioEditorData LoadAudioEditorMangerData(string dataPath) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B707D0 Offset: 0x1B6C7D0 VA: 0x1B707D0
	public static void PlaySound(EventReference eventReference, GameObject triggerObj, GameObject targetObj) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B707E5 Offset: 0x1B6C7E5 VA: 0x1B707E5
	public static void StopSound(EventReference eventReference, GameObject targetObj) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B7081E Offset: 0x1B6C81E VA: 0x1B7081E
	public static void StopTargetObjectAllSound(GameObject targetObj) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B708BE Offset: 0x1B6C8BE VA: 0x1B708BE
	public static bool ReleaseAudioClip(string szPath) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B70A76 Offset: 0x1B6CA76 VA: 0x1B70A76
	public static AudioClip LoadAudioClipSync(string szPath) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B70C99 Offset: 0x1B6CC99 VA: 0x1B70C99
	public static void PlayMusic(int nSoundID) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B70D19 Offset: 0x1B6CD19 VA: 0x1B70D19
	public static void StopMusic() { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B70DA7 Offset: 0x1B6CDA7 VA: 0x1B70DA7
	public static void SetMusicVolume(float volume) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B70E86 Offset: 0x1B6CE86 VA: 0x1B70E86
	public static void SetSoundVolume(float volume) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B70F65 Offset: 0x1B6CF65 VA: 0x1B70F65
	public static void SetPos(Vector3 pos) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B71053 Offset: 0x1B6D053 VA: 0x1B71053
	public static bool SetEnable(bool enable) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B71250 Offset: 0x1B6D250 VA: 0x1B71250
	public static void SetPlayableInstancePoolLimit(uint value) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B713EA Offset: 0x1B6D3EA VA: 0x1B713EA
	public static bool IsEnable() { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B7142A Offset: 0x1B6D42A VA: 0x1B7142A
	private static void SetSystemMute(bool bMute) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B7199E Offset: 0x1B6D99E VA: 0x1B7199E
	private static void OnChangeVolume(float fVolume) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B71AE2 Offset: 0x1B6DAE2 VA: 0x1B71AE2
	private static void OnChangeRingerMode(int nType) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B71B94 Offset: 0x1B6DB94 VA: 0x1B71B94
	public static void ChangeLimitNumberInGameObjectOfSound(int newValue) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B71BFE Offset: 0x1B6DBFE VA: 0x1B71BFE
	public static void ChangeLimitNumberInGlobalOfSound(int newValue) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B71C62 Offset: 0x1B6DC62 VA: 0x1B71C62
	public static void ChangeLimitNumberInGameObjectOfMe(int newValue) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B71CB3 Offset: 0x1B6DCB3 VA: 0x1B71CB3
	public static void ChangeLimitNumberInGameObjectOfOtherPlayer(int newValue) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B71D04 Offset: 0x1B6DD04 VA: 0x1B71D04
	public static void ChangeLimitNumberInGameObjectOfNPC(int newValue) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B71D55 Offset: 0x1B6DD55 VA: 0x1B71D55
	public static int GetLimitNumber(AudioModule.AudioModuleLimitNumberType type) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B71ECB Offset: 0x1B6DECB VA: 0x1B71ECB
	private void OnDestroy() { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B72140 Offset: 0x1B6E140 VA: 0x1B72140
	public static void LoadSoundConfig() { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B72349 Offset: 0x1B6E349 VA: 0x1B72349
	public static int GetSoundID(string szKey) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

}
