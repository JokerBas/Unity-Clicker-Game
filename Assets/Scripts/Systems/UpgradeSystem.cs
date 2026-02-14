// UpgradeSystem.cs (ใช้ PlayerStats + DamageCalculator)
using System;
using UnityEngine;

public class UpgradeSystem : MonoBehaviour
{
    public PlayerStats playerStats;
    public ButtonUI buttonUI; // แค่ UI helper

    public void RefreshUI()
    {
        buttonUI.UpdatePrice(Calculator.GetUpgradeCost(playerStats.clickLevel + 1));
    }

    public void BuyClickUpgrade()
    {
        Console.WriteLine("Click Upgrade Attempting");
        int nextLevel = playerStats.clickLevel;
        int cost = Calculator.GetUpgradeCost(nextLevel);
        if (!playerStats.SpendGold(cost)) return;
        Console.WriteLine("Click Upgrade Bought");
        buttonUI.UpdatePrice(cost);
        playerStats.UpgradeClickLevel();
        RefreshUI();
    }

    public void BuyAutoUpgrade()
    {
        int nextLevel = playerStats.autoLevel;
        int cost = Calculator.GetUpgradeCost(nextLevel);
        if (!playerStats.SpendGold(cost)) return;
        Console.WriteLine("Auto Upgrade Bought");
        buttonUI.UpdatePrice(cost);
        playerStats.UpgradeAutoLevel();
        RefreshUI();
    }
}
