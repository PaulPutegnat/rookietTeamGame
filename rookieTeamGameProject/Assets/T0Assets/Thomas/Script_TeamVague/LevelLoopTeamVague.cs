using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoopTeamVague : MonoBehaviour
{
    public GamePlayerManagerTeamVague gameMana;


    private void Start()
    {
        gameMana = FindObjectOfType<GamePlayerManagerTeamVague>();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            gameMana.state = GamePlayerManagerTeamVague.build.Replace;
            other.transform.position = GameObject.FindGameObjectWithTag("Spawn_TV").transform.position;
        }
    }
}
