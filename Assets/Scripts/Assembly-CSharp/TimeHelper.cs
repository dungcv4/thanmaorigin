// Class:  TimeHelper
// GUID:   7dbc23561cd7b30954e42a2efdd2af86 (preserved via .meta)
// Source: KTO_DecompiledReference/_root/TimeHelper.c (8 methods, 287 LOC)
// Dump:   KTO_Resources/il2cpp_full_dump/dump.cs (TypeDefIndex 294)
//
// FULL 1-1 PORT 2026-04-25 — every method body verified against Ghidra C decompile.

using System;

public class TimeHelper
{
    // VMA: 0x01bb738c — Source: TimeHelper.c:265 (.cctor)
    // gốc body:
    //   UnixEpochTime = new DateTime(0x7b2 (=1970), 1, 1);
    //   UnixEpochTime2 = new DateTime(0x7b2, 1, 1, 0, 0, 0, 0);
    private static DateTime UnixEpochTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
    private static DateTime UnixEpochTime2 = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

    // VMA: 0x01bb6f0c — Source: TimeHelper.c:15 (DateTimeToUnixTime)
    // gốc body: return (dt.Ticks - UnixEpochTime.Ticks) / 10000;  // ticks→ms (10000 ticks per ms)
    public static long DateTimeToUnixTime(DateTime dt)
    {
        return (dt.Ticks - UnixEpochTime.Ticks) / 10000;
    }

    // VMA: 0x01bb6fb3 — Source: TimeHelper.c:50 (UnixTimeToDateTime)
    // gốc body: return new DateTime(ut * 10000 + UnixEpochTime.Ticks, DateTimeKind.Utc);
    public static DateTime UnixTimeToDateTime(long ut)
    {
        return new DateTime(ut * 10000 + UnixEpochTime.Ticks, DateTimeKind.Utc);
    }

    // VMA: 0x01bb7051 — Source: TimeHelper.c:84 (GetTimeStampSeconds)
    // gốc body: return (int)(DateTime.UtcNow - UnixEpochTime2).TotalSeconds;
    public static int GetTimeStampSeconds()
    {
        return (int)(DateTime.UtcNow - UnixEpochTime2).TotalSeconds;
    }

    // VMA: 0x01bb710d — Source: TimeHelper.c:124 (GetTimeStampMillSeconds)
    // gốc body: returns void in Ghidra (return value discarded); we return double to match dump signature.
    public static double GetTimeStampMillSeconds()
    {
        return (DateTime.UtcNow - UnixEpochTime2).TotalMilliseconds;
    }

    // VMA: 0x01bb71c5 — Source: TimeHelper.c:163 (FormatDateAsFileNameString)
    // gốc body: return string.Format("{0:D4}_{1:D2}_{2:D2}", dt.Year, dt.Month, dt.Day);  // DAT_035b7640 = "{0:D4}_{1:D2}_{2:D2}"
    public static string FormatDateAsFileNameString(DateTime dt)
    {
        return string.Format("{0:D4}_{1:D2}_{2:D2}", dt.Year, dt.Month, dt.Day);
    }

    // VMA: 0x01bb72a5 — Source: TimeHelper.c:205 (FormatTimeAsFileNameString)
    // gốc body: return string.Format("{0:D2}_{1:D2}_{2:D2}", dt.Hour, dt.Minute, dt.Second);  // DAT_035b7650
    public static string FormatTimeAsFileNameString(DateTime dt)
    {
        return string.Format("{0:D2}_{1:D2}_{2:D2}", dt.Hour, dt.Minute, dt.Second);
    }

    // VMA: 0x01bb7385 — Source: TimeHelper.c:247 (.ctor)
    // gốc body: System_Object___ctor(this, 0); — chain to base.
    public TimeHelper() { }
}
