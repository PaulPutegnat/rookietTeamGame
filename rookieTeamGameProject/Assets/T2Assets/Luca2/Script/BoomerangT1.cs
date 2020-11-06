using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangT1 : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    public int damage;
    public int hp = 2;
    public bool wait2sec;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update(){
        rb.velocity = transform.right * speed;
        if(hp <= 0){
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col){
        if(gameObject.tag == "Damage"){
            if (col.gameObject.tag == "Player"){  
            col.GetComponent<PlayerHPT1>().takeDamage(damage);
            Destroy(gameObject);
        }
        }

        if(gameObject.tag == "PlayerBullet"){
            if (col.gameObject.tag == "Enemy"){  
            col.GetComponent<HpEnemyT1>().takeDamage(damage);
        }
        }   

        if (col.gameObject.tag == "Wall"){ 
            if(!wait2sec){
                speed *= -1;
                wait2sec = true;
                hp -= 1;
                StartCoroutine("wait");
            } 
        }     
    }

    IEnumerator wait(){
        yield return new WaitForSeconds(0.25f);
        wait2sec = false;
    }
}
