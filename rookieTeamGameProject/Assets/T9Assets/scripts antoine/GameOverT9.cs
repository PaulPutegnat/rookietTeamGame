using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverT9 : MonoBehaviour
{
    
 public GameObject gameOverScreen;
    
    bool gameOver;

    void Start()
    {
        FindObjectOfType<PlayerT9>().OnPlayerDeath += OnGameOver;
    }

    void Update()
    {
        if (gameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(1);
            }
        }
    }

    void OnGameOver()
    {
        gameOverScreen.SetActive(true);
        
        gameOver = true;
    }
}
