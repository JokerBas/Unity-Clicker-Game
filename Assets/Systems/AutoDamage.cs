using UnityEngine;

public class AutoDamage : MonoBehaviour
{
    public PlayerStats playerStats;
    public float interval = 1f;
    bool canDamage = true;
    float timer = 0f;

    void Update()
    {
        if (!canDamage) return;
        timer += Time.deltaTime;

        if (timer >= interval)
        { 
            DamageEvents.OnDealDamageEnemy?.Invoke(playerStats.autoDamage);
            timer = 0f;
        }
    }
    void OnEnable()
    {
        GameEvents.OnGameStateChanged += OnGameStateChanged;
    }

    void OnDisable()
    {
        GameEvents.OnGameStateChanged -= OnGameStateChanged;
    }
    void OnGameStateChanged(GameState state)
    {
        canDamage = (state == GameState.Playing);
    }
}
