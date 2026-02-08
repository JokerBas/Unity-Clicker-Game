// หน้าที่:
// - รวม event ที่เกี่ยวกับ damage โดยเฉพาะ
// - แยกจาก GameEvents เพื่อไม่ให้ปน

using System;
using UnityEngine;

public static class DamageEvents
{
    public static Action<int> OnDealDamageEnemy;
}
