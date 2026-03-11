using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public PlayerUI playerUI;
    public int clickDamage = 1;
    public int autoDamage = 1;
    public int gold = 0;

    void Start()
    {
        RefreshUI();
    }

    void OnEnable()
    {
        GameEvents.OnGainGold += GainGold;
    }

    void OnDisable()
    {
        GameEvents.OnGainGold -= GainGold;
    }

    public void UpgradeClick()
    {
        clickDamage++;
        playerUI.UpdateDamage(clickDamage);
    }

    public void UpgradeAuto()
    {
        autoDamage++;
        playerUI.UpdateAutoDamage(autoDamage);
    }

    public void GainGold(int amount)
    {
        gold += amount;
        playerUI.UpdateGold(gold);
    }

    public void SpendGold(int amount)
    {
        gold -= amount;
        playerUI.UpdateGold(gold);
    }

    private void RefreshUI()
    {
        playerUI.UpdateGold(gold);
        playerUI.UpdateDamage(clickDamage);
        playerUI.UpdateAutoDamage(autoDamage);
    }
}
