using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T8_Player : MonoBehaviour
{
    public Sprite[] spritePlayer;

    [SerializeField]
    int maxLife = 3;
    [SerializeField]
    int lifePoints = 3;
    [SerializeField]
    int damagePerHit = 1;

    
    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Hit detected");
        GetHit();
    }*/

    public void GetHit()
    {
        lifePoints -= damagePerHit;
        if (lifePoints <= 0)
        {
            Debug.Log("lifepoints <= 0");
            GetComponentInChildren<SpriteRenderer>().sprite = spritePlayer[3];
            FindObjectOfType<T8_GameManager>().EndGame();
        }
       else if (lifePoints ==  maxLife && GetComponentInChildren<SpriteRenderer>().sprite != spritePlayer[0])
       {
           GetComponentInChildren<SpriteRenderer>().sprite = spritePlayer[0];
       }
       else if (lifePoints ==  2  && GetComponentInChildren<SpriteRenderer>().sprite != spritePlayer[1])
       {
           GetComponentInChildren<SpriteRenderer>().sprite = spritePlayer[1];
       }
       else if (lifePoints ==  1  && GetComponentInChildren<SpriteRenderer>().sprite != spritePlayer[2])
       {
           GetComponentInChildren<SpriteRenderer>().sprite = spritePlayer[2];
       }
    }
}
