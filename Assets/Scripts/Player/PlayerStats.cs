// PlayerStats.cs
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public PlayerUI playerUI;        // ผูกใน Inspector
    public int clickLevel = 1;       // เก็บ level แทน damage
    public int autoLevel = 1;
    public int clickDamage = 1;
    public int autoDamage = 1;
    public int gold = 0;

    void Start()
    {
        UpdateAllUI();
    }

    public void GainGold(int amount)
    {
        gold += amount;
        playerUI.UpdateGold(gold);
    }

    public bool SpendGold(int amount)
    {
        if (gold < amount) return false;
        gold -= amount;
        playerUI.UpdateGold(gold);
        return true;
    }

    public int GetClickDamage()
    {
        return Calculator.GetClickDamage(clickLevel, clickDamage);
    }

    public int GetAutoDamage()
    {
        return Calculator.GetAutoDamage(autoLevel, autoDamage);
    }

    public void UpgradeClickLevel()
    {
        clickLevel++;
        playerUI.UpdateDamage(GetClickDamage());
    }

    public void UpgradeAutoLevel()
    {
        autoLevel++;
        playerUI.UpdateAutoDamage(GetAutoDamage());
    }

    void UpdateAllUI()
    {
        playerUI.UpdateGold(gold);
        playerUI.UpdateDamage(GetClickDamage());
        playerUI.UpdateAutoDamage(GetAutoDamage());
    }
    public void OnEnable()
    {
        GameEvents.OnGiveGold += GainGold;
    }
}
