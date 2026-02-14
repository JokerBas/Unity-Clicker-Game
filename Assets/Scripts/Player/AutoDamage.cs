using UnityEngine;

public class AutoDamage : MonoBehaviour
{
    public PlayerStats playerStats;
    public float interval = 1f;
    float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= interval)
        {
            int dmg = playerStats.GetAutoDamage();
            GameEvents.OnDealDamageEnemy?.Invoke(dmg);
            timer = 0f;
        }
    }
    void OnEnable()
    {
       
    }

    void OnDisable()
    {
        
    }
}
