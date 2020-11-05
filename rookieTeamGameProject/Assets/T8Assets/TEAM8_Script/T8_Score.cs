using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class T8_Score : MonoBehaviour
{
    public Text scoreText;
    public float scorePerSec;
    float score = 0;
    bool isStop = false;

    // Update is called once per frame
    void Update()
    {
        if (!isStop)
        {
            score += 20 * Time.deltaTime; 
            scoreText.text = score.ToString("0");
        }
    }

    public void StopScore()
    {
        isStop = true;
    }

    public void StatScore()
    {
        isStop = false;
    }
}
