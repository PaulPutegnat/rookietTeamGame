using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class T1menuPause : MonoBehaviour
{
    public static bool pauseJeu = false;

    public GameObject menuPauseUI;
  
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseJeu)
            {
                Reprendre();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Reprendre()
    {
        menuPauseUI.SetActive(false);
        Time.timeScale = 1f;
        pauseJeu = false;
    }

    void Pause()
    {
        menuPauseUI.SetActive(true);
        Time.timeScale = 0f;
        pauseJeu = true;
    }

    public void retourMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("T1Menu");
    }

}

