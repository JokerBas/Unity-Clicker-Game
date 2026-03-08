// GameCalculatorDebugger.cs
// แนบ MonoBehaviour นี้บน GameObject ใดก็ได้
// แล้วกดปุ่ม "Print Growth Table" ใน Inspector (Context Menu)
// เพื่อดู Growth Table ทั้งหมดใน Unity Console

using UnityEngine;

public class GameCalculatorDebugger : MonoBehaviour
{
    [ContextMenu("Print Growth Table")]
    public void PrintGrowthTable()
    {
        GameCalculator.PrintGrowthTable();
    }
}
