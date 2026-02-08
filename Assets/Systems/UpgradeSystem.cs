using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeSystem : MonoBehaviour
{
    public ButtonUI buttonUI;
    public PlayerStats playerStats;
    bool isUpgrading = false;
    private int CalculateUpgradeCost(int currentLevel)
    {
        int baseCost = 10;
        float growthRate = 1.15f;
        return Mathf.FloorToInt(baseCost * Mathf.Pow(growthRate, currentLevel - 1));
    }

    void Update()
    {
        if (isUpgrading)
        {
            buttonUI.UpdatePrice(CalculateUpgradeCost(playerStats.clickDamage));
            buttonUI.UpdateGainDamage(playerStats.clickDamage);
            isUpgrading = false;
        }
    }
    public void UpgradeClickDamage()
    {
        int nextLevel = playerStats.clickDamage + 1;
        int cost = CalculateUpgradeCost(nextLevel);
        if (playerStats.gold >= cost)
        {
            isUpgrading = true;
            playerStats.gold -= cost;
            playerStats.UpgradeClick();
            if (nextLevel % 5 == 0)
            {
                playerStats.clickDamage += 5;
            }
        }
    }
    public void UpgradeAutoDamage()
    {
        int nextLevel = playerStats.autoDamage + 1;
        int cost = CalculateUpgradeCost(nextLevel);
        if (playerStats.gold >= cost)
        {
            isUpgrading = true;
            playerStats.gold -= cost;
            playerStats.UpgradeAuto();
            if (nextLevel % 5 == 0)
            {
                playerStats.autoDamage += 5;
            }
        }
    }
    
}
