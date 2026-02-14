// หน้าที่:
// - ฟัง event จาก Enemy
// - ตัดสินผลแพ้–ชนะ
// - ? ไม่รู้ HP
// - ? ไม่ยุ่ง UI โดยตรง
// เริ่มเกม เริ่มรอบ ,บอสเกิดเวลานับถอยหลัง

using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public RoundSystem roundSystem;
    public PlayerStats playerStats;
    public float maxTime = 10f;
    public float timeLeft;

    public TimeBar timeBar;
    private bool isBossRound = false;

    void Start()
    {

    }

    void Update()
    {
        if (isBossRound)
        {
            timeLeft -= Time.deltaTime;
            timeBar.SetTime(timeLeft);

            if (timeLeft <= 0f)
            {
                EndBossTime();
            }
        }
    }

    void StartGame()
    {
        roundSystem.StartRound();
    }
    public void StartBossTimer()
    {
        isBossRound = true;
    }

    void EndBossTime()
    {
        isBossRound = false;
        GameEvents.OnEndGame?.Invoke();
        roundSystem.StartFarmRound();
    }

    void OnEnable()
    {
        GameEvents.OnEnemyDead += HandleWin;
        GameEvents.OnBossDead += HandleWin;
        GameEvents.IsBossRound += StartBossTimer;
    }

    void OnDisable()
    {
        GameEvents.OnEnemyDead -= HandleWin;
        GameEvents.OnBossDead -= HandleWin;
        GameEvents.IsBossRound -= StartBossTimer;
    }

    void HandleWin()
    {
        StartGame();
    }
}
