using UnityEngine;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    public TextMeshProUGUI goldText;
    public TextMeshProUGUI damageText;
    public TextMeshProUGUI autodamageText;

    public void UpdateGold(int gold)
    {
        goldText.text = $"Gold: {gold}";
    }

    public void UpdateDamage(int damage)
    {
        damageText.text = $"Click DMG: {damage}";
    }

    public void UpdateAutoDamage(int autoDamage)
    {
        autodamageText.text = $"Auto DMG: {autoDamage}";
    }
}
