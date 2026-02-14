using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public PlayerStats playerStats;
    public void OnClick()
    {
        int dmg = playerStats.GetClickDamage();
        GameEvents.OnDealDamageEnemy?.Invoke(dmg);
    }
}