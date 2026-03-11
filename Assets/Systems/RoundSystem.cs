using UnityEngine;

public class RoundSystem : MonoBehaviour
{
    public WaveUI waveUI;
    public StageSystem stageSystem;
    public int currentRound = 1;
    public int wavesCount = 0;
    private const int WavesPerRound = 5;

    public void PreviousRound()
    {
        currentRound--;
        StartRound();
    }

    public void NextRound()
    {
        currentRound++;
        wavesCount = 1;
        waveUI.UpdateWave(wavesCount, WavesPerRound);
    }

    public void ResetRound()
    {
        currentRound = 1;
        wavesCount = 0;
        waveUI.UpdateWave(wavesCount, WavesPerRound);
    }

    public void StartRound()
    {
        wavesCount++;
        waveUI.UpdateWave(wavesCount, WavesPerRound);

        if (wavesCount > WavesPerRound)
        {
            stageSystem.NextStage();
            NextRound();
        }

        GameEvents.OnRoundStart?.Invoke();
    }
}
