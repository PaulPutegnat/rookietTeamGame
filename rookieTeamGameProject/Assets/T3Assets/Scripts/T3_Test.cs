﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T3_Test : MonoBehaviour
{
    public T3_LifeManager lifeManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyT3"))
        {
            Destroy(collision.gameObject);
            lifeManager.TakeDamage(1);
        }
        
        if (collision.gameObject.CompareTag("BonusT3"))
        {
            Destroy(collision.gameObject);
        }
    }
}
