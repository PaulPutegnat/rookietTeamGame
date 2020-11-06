using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayerManagerTeamVague : MonoBehaviour
{
    public float moveSpeed = 1.0f;
    public Vector3 moveVector;
    [Header("Building")]
    public List<GameObject> building;
    public Transform transmax;
    public Transform transmin;
    private Vector3 posbuild;
    [Header("Etat du Jeu")]
    public build state;
    [Header("TimerBuilding")]
    public float timeLeft = 15.0f;
    [SerializeField]
    private float currentTime;
    public bool fin;



    public void Start()
    {
        state = build.Replace;
    }

    public void Update()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            if(currentTime <= 0)
            {
                if (fin)
                {
                    SceneManager.LoadScene("ScoringTeamVague");
                }
                else
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
            }
        }

        if (state==build.Replace)
        {
            for(int i=0;i<building.Count;i++)
            {
                posbuild = building[i].transform.position;
                posbuild.y = Random.Range(transmin.position.y, transmax.position.y);
                building[i].transform.position = posbuild;
            }
            state = build.Playing;
            currentTime = timeLeft;
        }
    }

    public enum build
    {
        Replace,
        Playing,
    }
}
