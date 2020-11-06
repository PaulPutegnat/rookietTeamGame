using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControllerTeamVague : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Transform> tpplayer;
    public int nbr;
    public int nbrmax;
    public ControlToucheTeamVague control;
    public bool fin;
   
    void Start()
    {
        Move(nbr);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(control.down))
        {
            nbr += 1;
            Move(nbr);
        }
        else if (Input.GetKeyDown(control.up))
        {
            nbr -= 1;
            Move(nbr);

        }
    }


    public void Move(int count)
    {
        if(count<0)
        {
            nbr += 1;
        }else if(count>nbrmax)
        {
            nbr -= 1;
        }
        transform.position = tpplayer[nbr].position;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("DeathTrigger"))
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

}
