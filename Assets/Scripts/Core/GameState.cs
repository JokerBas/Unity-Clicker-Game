// หน้าที่:
// - เก็บสถานะหลักของเกม
// - ใช้เป็นภาษากลางระหว่างระบบ
using UnityEngine;

public class GameState : MonoBehaviour
{
    public static GameState Pause { get; internal set; }
    public static GameState Playing { get; internal set; }
    public static GameState End { get; internal set; }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
