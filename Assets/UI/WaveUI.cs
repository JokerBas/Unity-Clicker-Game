using UnityEngine;
using TMPro;

public class WaveUI : MonoBehaviour
{
    public TextMeshProUGUI waveText;

    public void UpdateWave(int current, int max)
    {
        waveText.text = $"Wave {current}/{max}";
    }
}
