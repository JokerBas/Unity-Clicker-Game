using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeBar : MonoBehaviour
{
    public Slider timeBar;

    public void SetMaxTime(float maxTime)
    {
        timeBar.maxValue = maxTime;
        timeBar.value = maxTime;
    }
    public void SetTime(float time)
    {
        timeBar.value = time;
    }
}
