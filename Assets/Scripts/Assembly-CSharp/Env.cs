// Class:  Env (gốc Lua global table — ported as C# static)
// GUID:   f1440d7b5fbc945c9810cf6279e870c1 (preserved via .meta)
// Source: KiemTheOrigin_DeepExtract/39_CommonUI/Lua/EnvDef.lua (lines 1-7)
//         + reference_kto_movement.md memory entry (movement constants)
//
// FULL 1-1 PORT 2026-04-25 — constants verified against EnvDef.lua line 1-7.
//
// CLASS-LEVEL DEVIATION:
// - Lua side dynamically loads LogWay.tab / LogWayMBI.tab / LogWayGame.tab / LogWayTracking.tab
//   into Env[<SubWayName>] = Value during game boot. We expose static dicts + a deferred
//   LoadLogWayTabs() helper (Phase 8) to populate after pack0.dat is loaded.

using System.Collections.Generic;

public static class Env
{
    // EnvDef.lua:1
    public const int GAME_FPS = 18;
    // EnvDef.lua:2
    public const int LOGIC_MAX_DIR = 256;
    // EnvDef.lua:3
    public const int INT_MAX = 2147483647;
    // EnvDef.lua:4
    public const uint UINT_MAX = 4294967295u;
    // EnvDef.lua:5
    public const int CAMERA_DEFAULT_X = 30;
    // EnvDef.lua:6
    public const int DAILY_BIT_OFFSET = 2048;
    // EnvDef.lua:7
    public const int NEW_DAY_OFFSET_TIME = 14400;

    // ============= Movement-related (CLAUDE.md memory: reference_kto_movement.md) =============
    // Logic position cell size (game world units per logic cell). 1/800 (== 0.00125f).
    public const float LOGIC_POS_CELL = 0.00125f;
    // Default run speed (logic units per game frame). 200.
    public const int DEFAULT_RUN_SPEED = 200;

    // ============= Direction convention (256-step, LOGIC_MAX_DIR/4 quarters) =============
    // 0=south, 64=west, 128=north, 192=east. Source: reference_kto_movement.md.
    public const int DIR_SOUTH = 0;
    public const int DIR_WEST = 64;
    public const int DIR_NORTH = 128;
    public const int DIR_EAST = 192;

    // ============= Dynamic lookup tables (populated by LoadLogWayTabs at boot) =============
    public static Dictionary<int, string> tbLogWayDesc = new Dictionary<int, string>();
    public static Dictionary<int, string> tbLogWayMainWays = new Dictionary<int, string>();
    public static Dictionary<int, string> tbLogWaySubWays = new Dictionary<int, string>();
    public static Dictionary<int, string> tbLogWayGameDesc = new Dictionary<int, string>();
}
