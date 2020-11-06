using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerT1 : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float startTime;

    public int mode; // 0 = training / 1 = run1

    public bool start;
    public bool finished;

    public float t;

    public string minutes;
    public string seconds;

    public float minutes2;
    public float seconds2;

    /*public GameObject gold;
    public GameObject silver;
    public GameObject bronze;*/


    void Start()
    {   
        start = false;
        startTime = 0;
        finished = false;
    }

    void Update()
    {
        if(start){
            startTime = t;
            start = false;
        }
        if(finished){
            Finnish();
        }else{
        t = Time.time - startTime;

        minutes = ((int) t / 60).ToString();
        seconds = (t % 60).ToString("f2");

        timerText.text = minutes + ":" + seconds;
        }
    }

    public void Finnish(){
        minutes2 = float.Parse(minutes);
        seconds2 = float.Parse(seconds);
        finished = true;
        timerText.color = Color.Lerp(Color.white, Color.red, Mathf.PingPong(Time.time * 2, 1));
        if(mode == 1){
            if(minutes2 < 1 && seconds2 <= 25){
                Debug.Log("gold");
            }else if(minutes2 < 1 && seconds2 <= 30 && seconds2 > 25){
                Debug.Log("silver");
            }else if(minutes2 < 1 && seconds2 <= 40 && seconds2 > 30){
                Debug.Log("bronze");
            }
        }
        
    }
}
