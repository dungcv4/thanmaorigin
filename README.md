# thanmaorigin

KiemThe Origin (KTO) port 1-1 từ gốc — Unity 2022.3.62f3 + XLua + DOTween Free.

## Status

**Phase 3 COMPLETE** — 296/296 IL2CPP methods VMA-cited (100%)

| Class | Methods | LOC Ghidra | Status |
|---|---|---|---|
| UIView | 22/22 | 1176 | ✅ |
| UIPanel | 135/135 | 9883 | ✅ |
| UIModule | 39/39 | 2891 | ✅ |
| ResourceModule | 25/25 | 1658 | ✅ |
| AudioModule | 30/30 | 1608 | ✅ |
| CppModule | 22/22 | 1232 | ✅ |
| BundleLoader | 11/11 | 474 | ✅ |
| UIViewAnimationScale | 7/7 | 439 | ✅ |
| UIViewAnimationController | 5/5 | 128 | ✅ |
| **Total** | **296/296** | **19489** | **100%** |

**Bridge layer**: LuaEngine + LuaEventBridge + CmdRegistry + KTOLuaNative (libclient_scene.so port).

## Stack

- Unity 2022.3.62f3 + URP 14.0.11
- XLua (Tencent) — gốc Lua VM
- DOTween Free 1.0.327 — animation
- C# IL2CPP target

## Project Structure

```
thanmaorigin/
├── Assets/
│   ├── Scripts/Assembly-CSharp/   ← 1276 stub + 9 fully-ported critical classes
│   ├── Plugins/Demigiant/DOTween/ ← DOTween Free (75 .cs)
│   ├── XLua/                       ← XLua plugin
│   ├── _Project/                   ← thanmaorigin code
│   │   └── Scripts/{Lua,Network,Bootstrap,...}
│   ├── Resources/Lua/              ← 2164 .lua source
│   ├── Resources/Setting/          ← 62k configs
│   ├── YAMLImport/  → symlink      ← 1035 prefabs + 417 ctrl + 529 anim
│   └── StreamingAssets/Bundles/    ← 2556 APK bundles
├── Packages/manifest.json          ← URP + Input System + 2D + CoPlay MCP
└── ProjectSettings/
```

## Source-of-Truth Hierarchy

Every C# method ported with VMA cite từ:
- **IL2CPP method body**: `KTO_DecompiledReference/<Namespace>/<Class>.c` (Ghidra)
- **Class signature**: `KTO_Resources/il2cpp_full_dump/dump.cs` (Il2CppDumper)
- **Lua source**: `KiemTheOrigin_DeepExtract/<NN>_*/Lua/*.lua`
- **Native bindings**: `KTO_LibClientScene_Decompiled/INDEX.tsv`
- **Prefab YAML**: `KTO_FullExtract/Assets_YAML/`

## DEVIATIONs (Documented Inline)

1. UIViewAnimationScale: DOTween Free thay vì gốc Tencent stub
2. AudioModule: Unity AudioSource thay vì GME
3. BundleLoader: AssetBundle.LoadFromFile thay vì LoaderManager+KCoroutine chain
4. ResourceModule: Resources.Load + StreamingAssets thay vì native pack reader
5. KTOLuaNative.LuaIsPayOpen: false (skip Tencent SDK)

## Roadmap

- [x] Phase 0-2: Setup + ingest 100% data
- [x] Phase 3: Port IL2CPP behavior (296 methods, 9 classes)
- [ ] Phase 4: Server base (LocalCDN HTTP + GameServer + 50 CMD)
- [ ] Phase 5: Boot-to-Login flow
- [ ] Phase 6: HUD auto-spawn + Player spawn
- [ ] Phase 7: Gameplay loop (move + combat + bag)
- [ ] Phase 8: Feature waves (Skill/Quest/Social/Guild/Dungeon)
- [ ] Phase 9: Final verification

## Build

Unity 2022.3.62f3 required. First import ~30 min (1035 prefabs + 41GB YAML via symlink).

## License

Personal port project. KTO assets © Tencent / VNG. Code style port theo CLAUDE.md rules.
