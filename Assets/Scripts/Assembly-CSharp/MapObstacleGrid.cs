// DEVIATION — not in gốc dump.cs / Ghidra (verified 2026-05-02)
// Class: MapObstacleGrid
// Reason: thanmaorigin helper used by NavigationModule.IsLogicPointObstacle.
//         gốc embeds obstacle check in NavigationModule itself (libclient_scene.so).
// Approved by user: 2026-05-02 ("fix hết đi" — clean chế-cháo pass + compile fix)
// Original closest match: gốc NavigationModule.IsLogicPointObstacle inlined check.
//
// Members below are MINIMAL to keep NavigationModule.cs:45 compiling:
//   - Instance singleton (returns null if no obstacle data loaded → walkable)
//   - IsObstacle(x, y) → false (default walkable, until proper port lands)

using UnityEngine;

public class MapObstacleGrid : MonoBehaviour
{
    public static MapObstacleGrid Instance { get; private set; }

    void Awake()
    {
        if (Instance == null) Instance = this;
    }

    // Returns true if cell is obstacle (blocked). Default false → walkable.
    // Real impl: load `obstacle.bytes` per map (8-byte W+H header + MSB-first bitmap).
    public bool IsObstacle(int logicX, int logicY) { return false; }
}
