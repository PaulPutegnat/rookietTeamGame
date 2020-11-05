using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class T8_GameManager : MonoBehaviour
{
    public GameObject endScreen;
    public Text textScore;
    bool gameHasEnded = false;

    // Start is called before the first frame update
    void Start()
    {
        if (endScreen.activeInHierarchy)
        {
            endScreen.SetActive(false);
        }
    }

    public void EndGame()
    {
        if (!gameHasEnded)
        {
            gameHasEnded = true;
            Debug.Log("EndGame");

            FindObjectOfType<T8_Score>().StopScore();
            textScore.text = "Score Final : " + FindObjectOfType<T8_Score>().scoreText.text;
            endScreen.SetActive(true);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
