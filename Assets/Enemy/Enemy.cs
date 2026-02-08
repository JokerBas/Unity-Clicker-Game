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

    public Slider healthBar;

    void Start()
    {
        healthBar.maxValue = maxHP;
        healthBar.value = currentHP;
        currentHP = maxHP;
        enemyUI.UpdateHP(currentHP);
    }
    void OnEnable()
    {
        DamageEvents.OnDealDamageEnemy += TakeDamage;
        GameEvents.OnRoundStart += ResetEnemy;
        GameEvents.OnStageAdvance += caculateRewardGold;
    }

    void OnDisable()
    {
        DamageEvents.OnDealDamageEnemy -= TakeDamage;
        GameEvents.OnRoundStart -= ResetEnemy;
        GameEvents.OnStageAdvance -= caculateRewardGold;
    }

    void caculateRewardGold(int rewardGold)
    {
        int reward = rewardGold * stageSystem.CurrentStage;
        GameEvents.OnGainGold?.Invoke(reward);

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
        caculateRewardGold(10);
    }
    public void ResetEnemy()
    {
        int stage = stageSystem.CurrentStage;
        maxHP = baseHP * stage;   // สูตรง่ายก่อน
        currentHP = maxHP;
        healthBar.maxValue = maxHP;
        enemyUI.UpdateHP(currentHP);
    }
}
