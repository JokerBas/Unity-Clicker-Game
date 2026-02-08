using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    public TextMeshProUGUI goldText;
    public TextMeshProUGUI damageText;
    public TextMeshProUGUI autodamageText;
    
    public void UpdateGold(int gold)
    {
        goldText.text = "Gold: " + gold;
    }
    public void UpdateDamage(int damage)
    {
        damageText.text = "Click Damage: " + damage;
    }

    public void UpdateAutoDamage(int autodamage)
    {
        autodamageText.text = "Auto Damage: " + autodamage;
    }
}
