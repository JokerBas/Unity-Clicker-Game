using System;
using UnityEditor.Build.Content;
using UnityEngine;

public class RoundSystem : MonoBehaviour
{
    public WaveUI waveUI;
    public ScreenManager screenManager;
    public StageSystem stageSystem;
    public int currentRound = 1;
    public int wavescount = 0;
    private int wavesPerRound = 5;

    public void OnEnable()
    {
        GameEvents.OnBossDead += NextRound;
        GameEvents.OnEndGame += StartFarmRound;
    }
    public void OnDisable()
    {
        GameEvents.OnBossDead -= NextRound;
        GameEvents.OnEndGame -= StartFarmRound;
    }
    void Start()
    {
        StartRound();
    }


    public void StartFarmRound()
    {
        Debug.Log("Starting Farm Round");
        screenManager.ShowFarmScreen();
        currentRound--;
    }

    public void NextRound()
    {
        currentRound++;
        wavescount = 1;
    }
    public void StartRound()
    {
        Debug.Log("Starting Round " + currentRound);
        wavescount++;
        waveUI.UpdateWave(wavescount);
        if (wavescount > wavesPerRound)
        {
            IsBossRound();
        }
        GameEvents.OnRoundStart?.Invoke();
    }
    public void IsBossRound()
    {
        screenManager.ShowBossScreen();
        GameEvents.IsBossRound?.Invoke();
    }

}
