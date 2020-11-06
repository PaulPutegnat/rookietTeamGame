using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TEAM7_score : MonoBehaviour
{
    public static TEAM7_score instance;
    public Text textScore;
    public Text textScoreFinal;
    public int team7_score = 100;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        textScore.text = "Points: " + team7_score.ToString();
        textScoreFinal.text = "Points: " + team7_score.ToString();
    }

    public void ChangeScore(int scoreValue, bool isAugmented)
    {
        if (isAugmented == true)
        {
            team7_score += scoreValue;
        }
        if (isAugmented == false)
        {
            team7_score -= scoreValue;
        }
        
        textScore.text = "Points: " + team7_score.ToString();
        textScoreFinal.text = "Points: " + team7_score.ToString();
        Debug.Log(team7_score);
    }
}
