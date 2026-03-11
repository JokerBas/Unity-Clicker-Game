using UnityEngine;

public class UpgradeSystem : MonoBehaviour
{
    public ButtonUI buttonUI;
    public PlayerStats playerStats;

    void Start()
    {
        RefreshUI();
    }

    private int CalculateUpgradeCost(int currentLevel)
    {
        const int baseCost = 10;
        const float growthRate = 1.15f;
        return Mathf.FloorToInt(baseCost * Mathf.Pow(growthRate, currentLevel - 1));
    }

    public void UpgradeClickDamage()
    {
        int nextLevel = playerStats.clickDamage + 1;
        int cost = CalculateUpgradeCost(nextLevel);

        if (playerStats.gold < cost)
            return;

        playerStats.SpendGold(cost);
        playerStats.UpgradeClick();

        // Milestone bonus every 5 levels
        if (nextLevel % 5 == 0)
            playerStats.clickDamage += 5;

        RefreshUI();
    }

    public void UpgradeAutoDamage()
    {
        int nextLevel = playerStats.autoDamage + 1;
        int cost = CalculateUpgradeCost(nextLevel);

        if (playerStats.gold < cost)
            return;

        playerStats.SpendGold(cost);
        playerStats.UpgradeAuto();

        // Milestone bonus every 5 levels
        if (nextLevel % 5 == 0)
            playerStats.autoDamage += 5;

        RefreshUI();
    }

    private void RefreshUI()
    {
        buttonUI.UpdatePrice(CalculateUpgradeCost(playerStats.clickDamage));
        buttonUI.UpdateGainDamage(playerStats.clickDamage);
    }
}
