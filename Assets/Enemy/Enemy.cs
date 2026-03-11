using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public EnemyUI enemyUI;
    public StageSystem stageSystem;
    public int baseHP = 10;
    public int maxHP = 10;
    public int currentHP;

    public Slider healthBar;

    void Start()
    {
        // Assign currentHP before setting the slider value to avoid showing an empty bar
        currentHP = maxHP;
        healthBar.maxValue = maxHP;
        healthBar.value = currentHP;
        enemyUI.UpdateHP(currentHP, maxHP);
    }

    void OnEnable()
    {
        DamageEvents.OnDealDamageEnemy += TakeDamage;
        GameEvents.OnRoundStart += ResetEnemy;
        GameEvents.OnStageAdvance += CalculateRewardGold;
    }

    void OnDisable()
    {
        DamageEvents.OnDealDamageEnemy -= TakeDamage;
        GameEvents.OnRoundStart -= ResetEnemy;
        GameEvents.OnStageAdvance -= CalculateRewardGold;
    }

    void CalculateRewardGold(int rewardGold)
    {
        int reward = rewardGold * stageSystem.CurrentStage;
        GameEvents.OnGainGold?.Invoke(reward);
    }

    void TakeDamage(int damage)
    {
        currentHP -= damage;
        healthBar.value = currentHP;
        enemyUI.UpdateHP(currentHP, maxHP);

        if (currentHP <= 0)
            Die();
    }

    void Die()
    {
        GameEvents.OnEnemyDead?.Invoke();
        CalculateRewardGold(10);
    }

    public void ResetEnemy()
    {
        maxHP = baseHP * stageSystem.CurrentStage;
        currentHP = maxHP;
        healthBar.maxValue = maxHP;
        healthBar.value = currentHP;  // bug fix: was missing this line
        enemyUI.UpdateHP(currentHP, maxHP);
    }
}
