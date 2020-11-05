﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mouvement : MonoBehaviour
{
    public Animator anim;

    private SpriteRenderer SpriteR;

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


}