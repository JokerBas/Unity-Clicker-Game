// หน้าที่:
// - เก็บสถานะหลักของเกม
// - ใช้เป็นภาษากลางระหว่างระบบ
using UnityEngine;

public class GameState : MonoBehaviour
{
    public static GameState Win { get; internal set; }
    public static GameState Playing { get; internal set; }
    public static GameState Lose { get; internal set; }

    /*public enum GameState
{
Playing,
Win,
Lose
}*/
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
