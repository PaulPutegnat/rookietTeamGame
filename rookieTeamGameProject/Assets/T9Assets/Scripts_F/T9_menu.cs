using UnityEngine;
using UnityEngine.SceneManagement;

public class T9_menu : MonoBehaviour
{
    [SerializeField] private GameObject PauseM;
    [SerializeField] private GameObject VictoryM;
    [SerializeField] private GameObject LoseM;

    [Space]
    [SerializeField] private T9_Boss boss;

    public void Pause()
    {
        PauseM.SetActive(true);
    }

    public void Victory()
    {
        VictoryM.SetActive(true);
    }

    public void Lose()
    {
        LoseM.SetActive(true);
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Proto malik");
    }

    public void Back()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void Continue()
    {
        PauseM.SetActive(false);
        boss.Pause();
    }
}
