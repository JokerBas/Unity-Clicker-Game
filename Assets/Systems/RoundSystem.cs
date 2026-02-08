using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundSystem : MonoBehaviour
{
    public WaveUI waveUI;
    public StageSystem stageSystem;
    public int currentRound = 1;
    public int wavescount = 0;
    private int wavesPerRound = 5;

    void Update()
    {
        waveUI.UpdateWave(wavescount);
    }

    public void PreviousRound()
    {
        currentRound--;
        StartRound();
    }

    public void NextRound()
    {
        currentRound++;
        wavescount = 1;
    }

    public void ResetRound()
    {
        currentRound = 1;
        wavescount = 0;
    }
    public void StartRound()
    {
        wavescount++;
        if (wavescount > wavesPerRound)
        {
            stageSystem.NextStage();
            NextRound();
        }
        GameEvents.OnRoundStart?.Invoke();
    }

}
