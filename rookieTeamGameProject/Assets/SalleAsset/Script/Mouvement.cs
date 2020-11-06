﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Mouvement : MonoBehaviour
{
    public Animator anim;

    private SpriteRenderer SpriteR;

    public bool isInTeam3 = false;

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
        if (isInTeam3 && Input.GetMouseButtonDown(0))
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

        if (collision.gameObject.CompareTag("Team3"))
        {
            isInTeam3 = true;
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Team3"))
        {
            isInTeam3 = false;          
        }
    }
}