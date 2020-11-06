using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Team7_retourMenu : MonoBehaviour
{
    public void LoadMenu(string nameScene)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(nameScene);
    }
}
