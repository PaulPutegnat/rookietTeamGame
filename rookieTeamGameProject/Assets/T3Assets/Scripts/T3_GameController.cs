using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class T3_GameController : MonoBehaviour
{

    public GameObject defeatPanel;
    public GameObject hudPanel;
    public GameObject startScreen;
    public GameObject tutoScreen;
    public GameObject pausePanel;
    public GameObject score;

    private bool isStartScreenActive = true;
    private bool isTutoScreenPassed = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (startScreen.activeInHierarchy == true)
        {
            Time.timeScale = 0;
            if (Input.GetKeyDown(KeyCode.Return))
            {
                startScreen.SetActive(false);
                Time.timeScale = 1;
                isStartScreenActive = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pausePanel.activeInHierarchy == false)
            {
                pausePanel.SetActive(true);
                PauseButton();
            }
            else
            {
                pausePanel.SetActive(false);
                PlayButton();
            }
        }

        StartCoroutine(TutoScreen());
    }

    public void PauseButton()
    {
        Time.timeScale = 0;
    }

    public void PlayButton()
    {
        Time.timeScale = 1;
    }

    public void HomeButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("SalleArcade");
    }

    public void RetryButton()
    {
        score.GetComponent<Text>().text = "0";
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    public void Defeat()
    {
        Time.timeScale = 0;
        defeatPanel.SetActive(true);
        hudPanel.SetActive(false);
    }

    IEnumerator TutoScreen()
    {
        WaitForSecondsRealtime waitForTutoScreen = new WaitForSecondsRealtime(5);

        if (!isStartScreenActive && !isTutoScreenPassed)
        {
            Time.timeScale = 0;
            isTutoScreenPassed = true;
            tutoScreen.SetActive(true);
            yield return waitForTutoScreen;
            tutoScreen.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
