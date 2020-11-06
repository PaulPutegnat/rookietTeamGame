using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Mouvement : MonoBehaviour
{
    public Animator anim;

    private SpriteRenderer SpriteR;

    public bool isInTeam0 = false;
    public bool isInTeam1 = false;
    public bool isInTeam2 = false;
    public bool isInTeam3 = false;
    public bool isInTeam4 = false;
    public bool isInTeam6 = false;
    public bool isInTeam7 = false;
    public bool isInTeam8 = false;
    public bool isInTeam9 = false;
    public bool isInTeam10 = false;

    [SerializeField] private float speed;

    void Start()
    {
        anim = GetComponent<Animator>();
        SpriteR = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        if (Input.GetKey("right"))
        {
            anim.SetBool("speed", true);
            SpriteR.flipX = false;
            transform.Translate(Time.deltaTime * speed, 0, 0);
        }
        else
        if (Input.GetKey("left"))
        {
            anim.SetBool("speed", true);
            SpriteR.flipX = true;
            transform.Translate(-Time.deltaTime * speed, 0, 0);
        }
        else
        {
            anim.SetBool("speed", false);
        }


        
    }

    private void Update()
    {
        if (isInTeam0 && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("Smileyxique");
        }

        if (isInTeam1 && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("Smileyxique");
        }

        if (isInTeam2 && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("Smileyxique");
        }

        if (isInTeam3 && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("Smileyxique");
        }

        if (isInTeam4 && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("Smileyxique");
        }

        if (isInTeam6 && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("Smileyxique");
        }

        if (isInTeam7 && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("Smileyxique");
        }

        if (isInTeam8 && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("Smileyxique");
        }

        if (isInTeam9 && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("Smileyxique");
        }

        if (isInTeam10 && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("Smileyxique");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*if (collision.gameObject.CompareTag("Team1"))
        {
            SceneManager.LoadScene("T1Menu");
        }*/

        if (collision.gameObject.CompareTag("Team0"))
        {
            isInTeam0 = true;
        }
        if (collision.gameObject.CompareTag("Team1"))
        {
            isInTeam1 = true;
        }
        if (collision.gameObject.CompareTag("Team2"))
        {
            isInTeam2 = true;
        }
        if (collision.gameObject.CompareTag("Team3"))
        {
            isInTeam3 = true;
        }
        if (collision.gameObject.CompareTag("Team4"))
        {
            isInTeam4 = true;
        }
        if (collision.gameObject.CompareTag("Team6"))
        {
            isInTeam6 = true;
        }
        if (collision.gameObject.CompareTag("Team7"))
        {
            isInTeam7 = true;
        }
        if (collision.gameObject.CompareTag("Team8"))
        {
            isInTeam8 = true;
        }
        if (collision.gameObject.CompareTag("Team9"))
        {
            isInTeam9 = true;
        }
        if (collision.gameObject.CompareTag("Team10"))
        {
            isInTeam10 = true;
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Team0"))
        {
            isInTeam0 = false;
        }
        if (collision.gameObject.CompareTag("Team1"))
        {
            isInTeam1 = false;
        }
        if (collision.gameObject.CompareTag("Team2"))
        {
            isInTeam2 = false;
        }
        if (collision.gameObject.CompareTag("Team3"))
        {
            isInTeam3 = false;          
        }
        if (collision.gameObject.CompareTag("Team4"))
        {
            isInTeam4 = false;
        }
        if (collision.gameObject.CompareTag("Team6"))
        {
            isInTeam6 = false;
        }
        if (collision.gameObject.CompareTag("Team7"))
        {
            isInTeam7 = false;
        }
        if (collision.gameObject.CompareTag("Team8"))
        {
            isInTeam8 = false;
        }
        if (collision.gameObject.CompareTag("Team9"))
        {
            isInTeam9 = false;
        }
        if (collision.gameObject.CompareTag("Team10"))
        {
            isInTeam10 = false;
        }
    }
}