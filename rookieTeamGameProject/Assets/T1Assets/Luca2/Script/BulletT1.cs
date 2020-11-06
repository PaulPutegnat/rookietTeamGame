﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletT1 : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    public int damage;
    public float timeToDelete;

    public bool destroyOnContact;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
        if(timeToDelete != 0){
            Destroy(gameObject, timeToDelete);
        }
    }

    void OnTriggerEnter2D(Collider2D col){
        if(gameObject.tag == "Damage"){
            if (col.gameObject.tag == "Player"){  
            col.GetComponent<PlayerHPT1>().takeDamage(damage);
            if(destroyOnContact){
                Destroy(gameObject);
            }
        }
        }

        if(gameObject.tag == "PlayerBullet"){
            if (col.gameObject.tag == "Enemy"){  
            col.GetComponent<HpEnemyT1>().takeDamage(damage);
            if(destroyOnContact){
                Destroy(gameObject);
            }
        }
        }
    }
}
