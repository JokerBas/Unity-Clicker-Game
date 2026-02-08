using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class EnemyUI : MonoBehaviour
{
    public TextMeshProUGUI hpText;
    public void UpdateHP(int hp)
    {
        hpText.text = hp + " HP";
    }
}