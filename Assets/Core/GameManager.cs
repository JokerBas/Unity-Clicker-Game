// หน้าที่:
// - คุม state เกม (Playing / Win / Lose)
// - ฟัง event จาก Enemy
// - ตัดสินผลแพ้–ชนะ
// - ? ไม่รู้ HP
// - ? ไม่ยุ่ง UI โดยตรง

using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public StageSystem stageSystem;
    public EnemySpawner enemySpawner;
    public RoundSystem roundSystem;
    public float maxTime = 10f;
    public float timeLeft;

    public TimeBar timeBar;

    void Start()
    {
        StartGame();
    }

    void Update()
    {
        timeLeft -= Time.deltaTime;
        timeBar.SetTime(timeLeft);
        if (timeLeft <= 0f)
        {
            roundSystem.ResetRound();
            GameEvents.OnEndGame?.Invoke();
            StartGame();
        }
    }

    void StartGame()
    {
        timeLeft = maxTime;
        timeBar.SetMaxTime(maxTime);
        timeBar.SetTime(timeLeft);
        roundSystem.StartRound();
    }

    void OnEnable()
    {
        GameEvents.OnEnemyDead += HandleWin;
    }

    void OnDisable()
    {
        GameEvents.OnEnemyDead -= HandleWin;
    }

    void HandleWin()
    {
        StartGame();
    }
}
