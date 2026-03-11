using UnityEngine;
using TMPro;

public class EnemyUI : MonoBehaviour
{
    public TextMeshProUGUI hpText;

    public void UpdateHP(int currentHP, int maxHP)
    {
        hpText.text = $"{currentHP} / {maxHP}";
    }
}
