using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnclumeT1 : MonoBehaviour
{
    private Rigidbody2D rb;

    public Vector3 limit;

    public float speedH;
    public float speedV;

    public Collider2D hitBox;
    public int damage;

    public bool OneTime;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        limit.y = GameObject.Find("EnclumeTrans").GetComponent<Transform>().transform.position.y;
        StartCoroutine("Patern");
    }

    void Update()
    {
        rb.velocity = new Vector2(speedH, speedV);

        if(transform.position.y < limit.y + 1){
            if(!OneTime){
                OneTime = true;
                speedH = 0;
                speedV = 0;
                StartCoroutine("damage2");
            }
        }
    }

    IEnumerator Patern(){
        speedH = 10;
        speedV = 5;
        yield return new WaitForSeconds(0.3f);
        speedH = 0;
        speedV = 0;
        yield return new WaitForSeconds(0.3f);
        speedV = -15;
    }

    IEnumerator damage2(){
        hitBox.enabled = true;
        yield return new WaitForSeconds(0.2f);
        hitBox.enabled = false;
        yield return new WaitForSeconds(0.7f);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D col){
        if(gameObject.tag == "PlayerBullet"){
            if (col.gameObject.tag == "Enemy"){  
                col.GetComponent<HpEnemyT1>().takeDamage(damage);
            }
        }
    }
}
