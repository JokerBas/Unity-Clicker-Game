// หน้าที่:
// - เจ้าของ HP
// - รับ damage
// - ตายแล้วประกาศ event
// - reset ตัวเองเมื่อเริ่มรอบใหม่
using System.Buffers.Text;
using UnityEngine;
using UnityEngine.UI;
public class Enemy : MonoBehaviour
{
    public EnemyUI enemyUI;
    public StageSystem stageSystem;
    public int baseHP = 10;
    public int maxHP = 10;
    public int currentHP;
    public bool isBoss = false;

    public Slider healthBar;

    void Start()
    {
        if (!gameObject.activeInHierarchy) return;
        int stage = stageSystem.CurrentStage;
        maxHP = Calculator.GetEnemyHP(isBoss = true,stage, baseHP);
        Debug.Log("Enemy Start");
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
        GameEvents.OnEnemyDead?.Invoke();
        int reward = Calculator.GetGoldReward(stageSystem.CurrentStage);
        GameEvents.OnGiveGold?.Invoke(reward);
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
