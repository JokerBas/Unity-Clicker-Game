using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class EnemyUI : MonoBehaviour
{
    public TextMeshProUGUI hpText;
    public Slider healthSlider;
    public void SetMaxHealth(int health)
    {
        healthSlider.maxValue = health;
        healthSlider.value = health;
    }
    public void SetHealth(int health)
    {
        healthSlider.value = health;
    }
    public void UpdateHP(int hp)
    {
        hpText.text = hp + " HP";
    }
}