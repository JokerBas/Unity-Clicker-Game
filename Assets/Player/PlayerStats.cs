// หน้าที่:
// - เก็บพลังทั้งหมดของผู้เล่น
// - clickDamage / autoDamage
// - upgrade จะมาที่นี่ทั้งหมด
// - ? ไม่รู้ enemy
// - ? ไม่รู้ UI
using System;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public PlayerUI playerUI;
    public int clickDamage = 1;
    public int autoDamage = 1;
    public int gold = 0;

    void Update()
    {
        playerUI.UpdateGold(gold);
        playerUI.UpdateDamage(clickDamage);
        playerUI.UpdateAutoDamage(autoDamage);
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
    }

    public void UpgradeAuto()
    {
        autoDamage++;
    }
    public void GainGold(int amount)
    {
        gold += amount;
    }
}
