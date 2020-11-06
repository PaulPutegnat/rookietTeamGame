using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreFinal : MonoBehaviour
{
    public Text FinalScore;
    public Text Highscore;
    public int result;
    private int score ;

    // Start is called before the first frame update
    void Start()
    {
        Highscore.text = "HighScore : " + PlayerPrefs.GetInt("Highscore", 0).ToString();
        FinalScore.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<T2Movement>().GameOver)
        {
            score = GameObject.Find("ScoreHolder").GetComponent<T2Score>().score;
            result = GameObject.FindGameObjectWithTag("Player").GetComponent<T2Degat>().affection;
            if (result <= 0)
            {
               
            }
            else
            {
                if (result >= 1 && result <= 49)
                {
                       score *= 2;
                }
                else
                {
                    if (result == 50)
                    {
                        score *= 3;
                    }
                    else
                    {
                        if (result > 50 && result <= 99)
                        {
                            score *= 4;
                        }
                        else
                        {
                            score *= 5;
                        }
                    }
                }
            }

            
        }
        FinalScore.text = score.ToString();

        if (score > PlayerPrefs.GetInt("Highscore", 0))
        {
            PlayerPrefs.SetInt("Highscore", score);
        }
        GameObject.FindGameObjectWithTag("Player").GetComponent<T2Movement>().GameOver = false;
        Highscore.text = "HighScore " + PlayerPrefs.GetInt("Highscore", 0).ToString();

    }
}
