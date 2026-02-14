using UnityEngine;

public static class Calculator
{
    public static int BaseDamage(int level, int baseDamage, float exponent = 1.2f)
    {
        return Mathf.FloorToInt(baseDamage * Mathf.Pow(level, exponent));
    }

    public static int GetClickDamage(int level, int baseDamage, float exponent = 1.3f)
    {
        return Mathf.FloorToInt(baseDamage * Mathf.Pow(level, exponent));
    }

    public static int GetAutoDamage(int level, int baseDamage = 1, float exponent = 1.15f)
    {
        return Mathf.FloorToInt(baseDamage * Mathf.Pow(level, exponent));
    }

    public static int GetEnemyHP(bool state, int stage, int baseHP = 10, float hpExponent = 1.5f)
    {
        if (state)
        {
            return Mathf.FloorToInt(baseHP * Mathf.Pow(stage, hpExponent));
        }
        else
        {
            return GetBossHP(stage);
        }
    }

    private static int GetBossHP(int stage, int baseHP = 50, float hpExponent = 1.7f)
    {
        return Mathf.FloorToInt(baseHP * Mathf.Pow(stage, hpExponent));
    }

    public static int GetGoldReward(int stage, int baseGold = 5, float goldExp = 1.2f)
    {
        return Mathf.FloorToInt(baseGold * Mathf.Pow(stage, goldExp));
    }

    public static int GetUpgradeCost(int level, int baseCost = 10, float costExp = 1.3f)
    {
        return Mathf.FloorToInt(baseCost * Mathf.Pow(level, costExp));
    }
}
