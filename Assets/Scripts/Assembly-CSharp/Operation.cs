// Class:  Operation (gốc Lua module — C# bridge)
// GUID:   ff9a25f93d0d0493889d434522d37f21 (preserved via .meta)
// Source: KiemTheOrigin_DeepExtract/39_CommonUI/Lua/Script_Common_Operation.lua
//
// SCAFFOLD PORT 2026-04-25:
// gốc Operation is a Lua singleton (no IL2CPP class). Per CLAUDE.md kto-port-1-1-
// lua-runtime skill, the canonical port is to load Script_Common_Operation.lua
// via XLua and call methods from C# via XLua bridge. This C# class exposes the
// public API surface (matching Lua function signatures) so C# subscribers (e.g.
// JoystickEvents wired in Joystick.cs / UIJoyStick.cs) can call the right entry
// points. Bodies bridge to LuaEngine when available, else log + no-op.
//
// Lua entry points ported here (signature 1-1 with Lua):
//   Operation:GoDirection(nDir)         — Script_Common_Operation.lua:119
//   Operation:StopGoDir()               — Script_Common_Operation.lua:151
//   Operation:ClearLastDir()            — Script_Common_Operation.lua:177
//   Operation:SimpleTap(nNpcID, bFriend) — Script_Common_Operation.lua:182
//   Operation:OnDialogerClicked(...)
//   Operation:ClickMap(x, y)
//
// CLASS-LEVEL DEVIATION:
// - Lua-side body relies on me / KNpc / Npc.Doing / AFK / TeamMgr / EventNotify /
//   FightSkill / Kin / AFKFightSetting — none of which have C# IL2CPP equivalents
//   (all in Lua). Until LuaEngine is wired in Phase 8, these are no-ops with
//   Debug.Log to enable smoke-test of Joystick → Operation routing.

using UnityEngine;

public class Operation
{
    // Static state (gốc Lua: Operation.nLastGoDir, Operation.bOnJoyStick, Operation.bBlock)
    public static int? nLastGoDir = null;
    public static bool bOnJoyStick = false;
    public static bool bBlock = false;
    public static int nKickFrame = 0;

    // Source: Script_Common_Operation.lua:119 (Operation:GoDirection)
    // gốc body (paraphrased):
    //   if not nDir then return end
    //   if AFK:IsRunning() then AFK:InterruptStep_GoToFightPos() end
    //   AFK:Suspend()
    //   local nDoing = me.GetDoing()
    //   if self.nLastGoDir == nDir and nDoing != hover/qingkung/stand then return end
    //   if TeamMgr:IsFollowTeammateWithMsg(...) then return end
    //   EventNotify.OnNotify(EventNotify.emNOTIFY_MOVE_BY_STICK)
    //   if pNpc.HaveRefFlag(npc_forbid_move) then return end
    //   if doing == common then me.StopDirection() end
    //   me.GoDirection(nDir, Env.GAME_FPS * 10)   /* native bind */
    //   me.StartDirection(nDir)
    //   self.nLastGoDir = nDir
    //   self.bOnJoyStick = true
    //   self.nKickFrame = 0
    //   AFKFightSetting:CloseAutoFightRange(false)
    public static void GoDirection(int nDir)
    {
        // DEVIATION: Lua bridge not wired yet — log direction so Joystick→Operation
        //            dispatch is verifiable end-to-end.
        nLastGoDir = nDir;
        bOnJoyStick = true;
        nKickFrame = 0;
        Debug.Log($"[Operation.GoDirection] dir={nDir}");
    }

    // Source: Script_Common_Operation.lua:151 (Operation:StopGoDir)
    // gốc body: me.GoDirection(nLastGoDir, 2); me.StopDirection(); ClearLastDir();
    public static void StopGoDir()
    {
        ClearLastDir();
        Debug.Log("[Operation.StopGoDir]");
    }

    // Source: Script_Common_Operation.lua:177 (Operation:ClearLastDir)
    // gốc body: self.nLastGoDir = nil; self.bOnJoyStick = false;
    public static void ClearLastDir()
    {
        nLastGoDir = null;
        bOnJoyStick = false;
    }

    // Source: Script_Common_Operation.lua:182 (Operation:SimpleTap)
    // gốc body: dispatch to KNpc.GetById; if player → ShowProfile; if monster/quest → SimpleTapEnemy.
    public static void SimpleTap(int nNpcID, bool isFriend)
    {
        Debug.Log($"[Operation.SimpleTap] npc={nNpcID} friend={isFriend}");
    }

    // Source: Script_Common_Operation.lua (Operation:ClickMap)
    // gốc body: NavigationModule.GotoPosition(x, y) via me.GotoPosition.
    public static void ClickMap(int x, int y)
    {
        Debug.Log($"[Operation.ClickMap] x={x} y={y}");
    }

    // Source: Script_Common_Operation.lua (Operation:OnDialogerClicked)
    // gốc body: forward to NPC dialog system.
    public static void OnDialogerClicked(int nNpcID)
    {
        Debug.Log($"[Operation.OnDialogerClicked] npc={nNpcID}");
    }

    // ============= Joystick subscription wire-up =============
    // Subscribes to JoystickEvents at boot — matches gốc Lua subscription pattern
    // (Operation:OnJoyStickMove / Operation:OnJoyStickUp internal handlers).
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    private static void WireJoystickEvents()
    {
        JoystickEvents.OnMove += (dir, idx) => GoDirection(dir);
        JoystickEvents.OnUp += (idx) => StopGoDir();
    }
}
