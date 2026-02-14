// หน้าที่:
// - เป็นศูนย์กลาง event ทั้งเกม
// - ไม่มี logic ใด ๆ
// - แค่ประกาศเหตุการณ์
using System;

public static class GameEvents
{
    public static Action<int> OnDealDamageEnemy;
    public static Action OnEnemyDead;
    public static Action OnRoundStart;
    public static Action<int> OnGiveGold;
    public static Action OnEndGame;
    public static Action<int> OnStageAdvance;
    public static Action OnBossDead;
    public static Action IsBossRound;


}
