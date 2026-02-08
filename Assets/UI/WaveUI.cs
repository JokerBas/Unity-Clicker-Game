using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveUI : MonoBehaviour
{
    public TextMeshProUGUI waveText;

    public void UpdateWave(int wavescount)
    {
        waveText.text = wavescount + "/5";
    }
}
