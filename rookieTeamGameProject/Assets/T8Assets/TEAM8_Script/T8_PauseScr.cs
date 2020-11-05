using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class T8_PauseScr : MonoBehaviour
{
    public GameObject pauseScreen;
    private bool paused = false;

    // Start is called before the first frame update
    void Start()
    {
        if (pauseScreen.activeInHierarchy)
        {
            pauseScreen.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonUp("Cancel"))
            Pause();
    }

    void Pause()
    {
        paused = !paused;

        if (paused)
        {
            pauseScreen.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            pauseScreen.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void BackToArcade()
    {
        //Debug.Log("Quit !");
        //----- SceneManager : Load "Arcade" Scene. ------------------------------------------------------------
        SceneManager.LoadScene(0);
    }
}
