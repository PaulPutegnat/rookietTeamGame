using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class T2Movement : MonoBehaviour
{
    public float speed;
    public int conteur;
    public bool GameOver;
    public GameObject ScoreScreen;
    public Text text;
    private void Start()
    {
        text.text = "HighScore " + PlayerPrefs.GetInt("Highscore", 0).ToString();
        Debug.Log(PlayerPrefs.GetInt("HighsScore", 0));
    }
    void Update()
    {
        if (Input.GetKey("left"))
        {
            transform.Translate(Time.deltaTime * speed, 0, 0);
        }
        if (Input.GetKey("right"))
        {
            transform.Translate(-Time.deltaTime * speed, 0, 0);
        }
        if (conteur == 3)
        {
            ScoreScreen.SetActive(true);
            GameOver = true;
            conteur++;
        }
        if(!ScoreScreen.activeSelf)
        {
            text.text = "HighScore "+ PlayerPrefs.GetInt("Highscore", 0).ToString();
        } 
        
    }
    
}
