// หน้าที่:
// - เป็นศูนย์กลาง event ทั้งเกม
// - ไม่มี logic ใด ๆ
// - แค่ประกาศเหตุการณ์
using System;

public static class GameEvents
{
    public static Action OnEnemyDead;
    public static Action<int> OnEnemyHPChanged;
    public static Action<GameState> OnGameStateChanged;
    public static Action OnRoundStart;
    public static Action<int> OnGainGold;
    public static Action OnEndGame;
    public static Action OnCriticalUpgrade;
    public static Action<int> OnStageAdvance;

}
