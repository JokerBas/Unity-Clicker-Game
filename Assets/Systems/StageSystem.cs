using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSystem : MonoBehaviour
{
    public int CurrentStage { get; private set; } = 1;

    public void NextStage()
    {
        CurrentStage++;
        GameEvents.OnStageAdvance?.Invoke(CurrentStage);
    }

    public void PreviousStage()
    {
        if (CurrentStage > 1)
        {
            CurrentStage--;
            GameEvents.OnStageAdvance?.Invoke(CurrentStage);
        }
    }

    public void ResetStage()
    {
        CurrentStage = 1;
    }
}
