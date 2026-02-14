// หน้าที่:
// - ปุ่ม UI
// - เรียก PlayerInput
// - ? ไม่รู้ logic
using UnityEngine;
using TMPro;

public class ButtonUI : MonoBehaviour
{
    public TextMeshProUGUI PriceText;
    public TextMeshProUGUI GainDamageText;

    public void UpdatePrice(int price)
    {
        PriceText.text = "Gold: " + price;
    }
    public void UpdateGainDamage(int gainDamage)
    {
        GainDamageText.text = "+" + gainDamage;
    }

}
