using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Boss : MonoBehaviour
{
    public EnemyUI enemyUI;
    public StageSystem stageSystem;
    [SerializeField] public int baseHP = 50;
    [SerializeField] public int maxHP = 50;
    [SerializeField] public int currentHP;
    public bool isBoss = true;

    public Slider healthBar;

    void Start()
    {
        if (!gameObject.activeInHierarchy) return;
        int stage = stageSystem.CurrentStage;
        maxHP = Calculator.GetEnemyHP(isBoss = true, stage, baseHP);
        currentHP = maxHP;
        healthBar.maxValue = maxHP;
        healthBar.value = currentHP;
        enemyUI.UpdateHP(currentHP);
    }
    void OnEnable()
    {
        GameEvents.OnDealDamageEnemy += TakeDamage;
        GameEvents.OnRoundStart += OnRoundStart;
    }

    void OnDisable()
    {
        GameEvents.OnDealDamageEnemy -= TakeDamage;
        GameEvents.OnRoundStart -= OnRoundStart;
    }

    void TakeDamage(int damage)
    {
        currentHP -= damage;
        enemyUI.UpdateHP(currentHP);
        healthBar.value = currentHP;
        if (currentHP <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        GameEvents.OnBossDead?.Invoke();

    }
    void OnRoundStart()
    {
        if (!gameObject.activeInHierarchy) return;
        int stage = stageSystem.CurrentStage;
        maxHP = Calculator.GetEnemyHP(isBoss = true, stage, baseHP);
        currentHP = maxHP;
        healthBar.maxValue = maxHP;
        healthBar.value = currentHP;
        enemyUI.UpdateHP(currentHP);
    }
}
