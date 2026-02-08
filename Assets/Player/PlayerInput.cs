using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public PlayerStats playerStats;
    public void OnClick()
    {
        DamageEvents.OnDealDamageEnemy?.Invoke(playerStats.clickDamage);
    }
}