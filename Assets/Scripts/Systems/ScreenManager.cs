using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    public GameObject enemy;
    public GameObject boss;
    public GameObject buttonFightBoss;
    public GameObject buttonLeftBoss;
    public GameObject timeBar;
    public GameObject waveUI;

    void Start()
    {
        waveUI.SetActive(true);
        buttonLeftBoss.SetActive(false);
        buttonFightBoss.SetActive(false);
        enemy.SetActive(true);
        boss.SetActive(false);
        timeBar.SetActive(false);

    }

    public void ShowBossScreen()
    {
        buttonFightBoss.SetActive(false);
        buttonLeftBoss.SetActive(true);
        enemy.SetActive(false);
        boss.SetActive(true);
        waveUI.SetActive(false);
        timeBar.SetActive(true);
    }
    public void ShowFarmScreen()
    {
        buttonFightBoss.SetActive(true);
        buttonLeftBoss.SetActive(false);
        boss.SetActive(false);
        enemy.SetActive(true);
        waveUI.SetActive(false);
        timeBar.SetActive(false);
    }



}
