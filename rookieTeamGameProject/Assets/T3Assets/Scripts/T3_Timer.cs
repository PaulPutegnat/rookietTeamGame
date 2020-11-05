using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class T3_Timer : MonoBehaviour
{
    public Slider timeSlider;

    public float difficulty = 1.0f;
    public float timerStartValue;
    private float timerValue;

    public Color startColor;
    public Color endColor;
    private bool redColor = false;
    private bool stopTimer = false;

    void Update()
    {
        if (!stopTimer)
        {
            timerValue -= (Time.deltaTime % 60);
            timeSlider.value = timerValue;
        }

        if (timerValue <= 3 && !redColor)
            ColorChange();


        if (timeSlider.value == 0)
        {
            // OUTPUT --> PERDU !!
        }
    }

    public void SetTimer(float startValue)
    {
        timeSlider.maxValue = startValue;
        timeSlider.value = startValue;
        timerValue = startValue;
        GameObject.Find("Fill").GetComponent<Image>().color = startColor;
    }

    void ColorChange()
    {
        GameObject.Find("Fill").GetComponent<Image>().color = endColor;
    }

    public void StopTimer()
    {
        stopTimer = true;
    }
}
