// =============================================================================
// GameCalculator.cs
// หน้าที่:
//   - รวมสูตรคำนวณทั้งหมดของเกมไว้ที่เดียว
//   - ใช้เป็น Single Source of Truth สำหรับ balance ตัวเลข
//   - มี PrintGrowthTable() สำหรับดู growth chart ใน Console
//
// วิธีใช้:
//   - เรียก GameCalculator.EnemyMaxHP(stage) แทนการคำนวณกระจัดกระจาย
//   - แนบ GameCalculatorDebugger บน GameObject ใดก็ได้
//     แล้วกด "Print Growth Table" ใน Inspector เพื่อดูตาราง
// =============================================================================
//
// ╔══════════════════════════════════════════════════════════════════════╗
// ║                    GROWTH TABLE (PREVIEW)                           ║
// ╠════════╦══════════╦═══════════╦══════════════════════════════════════╣
// ║ STAGE  ║ Enemy HP ║ Gold/Kill ║ Notes                               ║
// ╠════════╬══════════╬═══════════╬══════════════════════════════════════╣
// ║      1 ║       10 ║        10 ║ Tutorial zone                       ║
// ║      2 ║       20 ║        20 ║                                     ║
// ║      5 ║       50 ║        50 ║                                     ║
// ║     10 ║      100 ║       100 ║                                     ║
// ║     15 ║      150 ║       150 ║                                     ║
// ║     20 ║      200 ║       200 ║ Late game                           ║
// ╚════════╩══════════╩═══════════╩══════════════════════════════════════╝
//
// ╔═══════════╦══════╦═══════════╦══════════════════╦════════════════════╗
// ║ Upgrades  ║ Cost ║ Click Dmg ║ Total Gold Spent ║ Notes              ║
// ╠═══════════╬══════╬═══════════╬══════════════════╬════════════════════╣
// ║         0 ║   11 ║         1 ║                0 ║ Starting state     ║
// ║         1 ║   13 ║         2 ║               11 ║                    ║
// ║         2 ║   15 ║         3 ║               24 ║                    ║
// ║         3 ║   17 ║         4 ║               39 ║                    ║
// ║         4 ║   40 ║        10 ║               56 ║ ★ Milestone Lv 5  ║
// ║         5 ║   46 ║        11 ║               96 ║ Cost spike!        ║
// ║         9 ║   94 ║        20 ║              362 ║ ★ Milestone Lv 15 ║
// ║        14 ║  188 ║        30 ║              926 ║ ★ Milestone Lv 25 ║
// ║        19 ║  377 ║        40 ║             2104 ║ ★ Milestone Lv 35 ║
// ║        24 ║  754 ║        50 ║             4466 ║ ★ Milestone Lv 45 ║
// ║        49 ║ 8116 ║       100 ║            56020 ║                    ║
// ╚═══════════╩══════╩═══════════╩══════════════════╩════════════════════╝
//
// =============================================================================

using System.Text;
using UnityEngine;

public static class GameCalculator
{
    // =========================================================================
    // CONSTANTS — แก้ตัวเลข balance ที่นี่ที่เดียว
    // =========================================================================

    public const int   BaseEnemyHP            = 10;
    public const int   BaseGoldReward         = 10;
    public const int   UpgradeBaseCost        = 10;
    public const float UpgradeCostGrowthRate  = 1.15f;
    public const int   MilestoneInterval      = 5;
    public const int   MilestoneBonusDamage   = 5;
    public const int   WavesPerRound          = 5;

    // =========================================================================
    // ENEMY
    // =========================================================================

    /// <summary>
    /// HP สูงสุดของ enemy ที่ stage นั้น
    /// สูตร: BaseEnemyHP * stage  (linear)
    /// </summary>
    public static int EnemyMaxHP(int stage)
    {
        return BaseEnemyHP * stage;
    }

    // =========================================================================
    // REWARDS
    // =========================================================================

    /// <summary>
    /// Gold ที่ได้เมื่อ enemy ตาย ที่ stage นั้น
    /// สูตร: BaseGoldReward * stage  (เหมือนกับ HP → kill 1 รอบได้ทุน)
    /// </summary>
    public static int GoldRewardOnKill(int stage)
    {
        return BaseGoldReward * stage;
    }

    // =========================================================================
    // UPGRADES
    // =========================================================================

    /// <summary>
    /// ราคา upgrade เมื่อ clickDamage ปัจจุบัน = currentDamage
    /// สูตร: floor( BaseCost * GrowthRate^(nextLevel - 1) )
    /// หมายเหตุ: nextLevel = currentDamage + 1  (ก่อนบวก milestone)
    /// </summary>
    public static int UpgradeCost(int currentDamage)
    {
        int nextLevel = currentDamage + 1;
        return Mathf.FloorToInt(UpgradeBaseCost * Mathf.Pow(UpgradeCostGrowthRate, nextLevel - 1));
    }

    /// <summary>
    /// Simulates click damage after N upgrades (รวม milestone bonus ทุก 5 levels)
    /// Milestone: เมื่อ nextLevel % 5 == 0 → ได้ damage +5 พิเศษ
    /// ผลจริง: ทุก 5 upgrades จะได้ +10 damage แทน +5
    /// </summary>
    public static int ClickDamageAfterUpgrades(int upgradeCount)
    {
        int damage = 1;
        for (int i = 0; i < upgradeCount; i++)
        {
            int nextLevel = damage + 1;
            damage++;
            if (nextLevel % MilestoneInterval == 0)
                damage += MilestoneBonusDamage;
        }
        return damage;
    }

    /// <summary>
    /// Gold ทั้งหมดที่ต้องใช้เพื่อ upgrade N ครั้ง (เริ่มจาก damage = 1)
    /// </summary>
    public static int CumulativeUpgradeCost(int upgradeCount)
    {
        int total  = 0;
        int damage = 1;
        for (int i = 0; i < upgradeCount; i++)
        {
            int nextLevel = damage + 1;
            total += Mathf.FloorToInt(UpgradeBaseCost * Mathf.Pow(UpgradeCostGrowthRate, nextLevel - 1));
            damage++;
            if (nextLevel % MilestoneInterval == 0)
                damage += MilestoneBonusDamage;
        }
        return total;
    }

    // =========================================================================
    // ROUNDS
    // =========================================================================

    /// <summary>
    /// Round จาก wave number (1-indexed)
    /// </summary>
    public static int RoundFromWave(int waveCount)
    {
        return Mathf.CeilToInt((float)waveCount / WavesPerRound);
    }

    /// <summary>
    /// Stage จาก round number (1-indexed)
    /// ปัจจุบัน: 1 round = 1 stage (StageSystem.NextStage ทุกครบ 5 waves)
    /// </summary>
    public static int StageFromRound(int round)
    {
        return round;
    }

    // =========================================================================
    // GROWTH TABLE PRINTER
    // =========================================================================

    /// <summary>
    /// Print ตาราง growth ทั้งหมดลง Unity Console
    /// เรียกผ่าน GameCalculatorDebugger ใน Inspector หรือจาก Editor script
    /// </summary>
    public static void PrintGrowthTable()
    {
        var sb = new StringBuilder();
        sb.AppendLine("╔══════════════════════════════════════════════════════════╗");
        sb.AppendLine("║              GAME CALCULATOR — GROWTH TABLE             ║");
        sb.AppendLine("╚══════════════════════════════════════════════════════════╝");

        // --- Stage Table ---
        sb.AppendLine();
        sb.AppendLine("[ STAGE GROWTH ]");
        sb.AppendLine($"{"Stage",-7} | {"Enemy HP",-9} | {"Gold/Kill",-10} | {"Waves/Round",-12}");
        sb.AppendLine(new string('─', 50));
        int[] stageRows = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 15, 20 };
        foreach (int s in stageRows)
        {
            string milestone = (s % 5 == 0) ? " ★" : "";
            sb.AppendLine($"{s,-7} | {EnemyMaxHP(s),-9} | {GoldRewardOnKill(s),-10} | {WavesPerRound,-12}{milestone}");
        }

        // --- Upgrade Table ---
        sb.AppendLine();
        sb.AppendLine("[ UPGRADE GROWTH — Click Damage ]");
        sb.AppendLine($"{"Upgrades",-9} | {"Next Cost",-10} | {"Click Dmg",-10} | {"Total Spent",-12} | {"Notes",-20}");
        sb.AppendLine(new string('─', 72));
        int[] upgradeRows = { 0, 1, 2, 3, 4, 5, 9, 10, 14, 15, 19, 20, 24, 25, 29, 30, 49, 50 };
        foreach (int u in upgradeRows)
        {
            int  dmg       = ClickDamageAfterUpgrades(u);
            int  nextCost  = UpgradeCost(dmg);
            int  cumCost   = CumulativeUpgradeCost(u);
            int  nextLevel = dmg + 1;
            bool milestone = (nextLevel % MilestoneInterval == 0);
            string notes   = milestone ? $"★ Milestone Lv {nextLevel}" : "";
            sb.AppendLine($"{u,-9} | {nextCost,-10} | {dmg,-10} | {cumCost,-12} | {notes,-20}");
        }

        // --- Break-even Analysis ---
        sb.AppendLine();
        sb.AppendLine("[ BREAK-EVEN: Upgrades needed to 1-shot enemy per stage ]");
        sb.AppendLine($"{"Stage",-7} | {"Enemy HP",-9} | {"Upgrades Needed",-16} | {"Gold to Reach",-14}");
        sb.AppendLine(new string('─', 56));
        int[] breakStages = { 1, 2, 3, 5, 10, 15, 20 };
        foreach (int s in breakStages)
        {
            int targetHP  = EnemyMaxHP(s);
            int upgNeeded = 0;
            while (ClickDamageAfterUpgrades(upgNeeded) < targetHP && upgNeeded < 500)
                upgNeeded++;
            int goldNeeded = CumulativeUpgradeCost(upgNeeded);
            sb.AppendLine($"{s,-7} | {targetHP,-9} | {upgNeeded,-16} | {goldNeeded,-14}");
        }

        Debug.Log(sb.ToString());
    }
}
