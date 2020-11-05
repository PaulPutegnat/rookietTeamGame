using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallonT1 : MonoBehaviour
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
        limit.y = GameObject.Find("EnclumeTrans").GetComponent<Transform>().transform.position.y - 0.5f;
        rb.velocity = Vector2.up * speedV;
        Destroy(gameObject, 10);
    }

    void Update()
    {
        rb.velocity = new Vector2(speedH, rb.velocity.y);

        if(transform.position.y < limit.y + 1){
            if(!OneTime){
                OneTime = true;
                rb.velocity = Vector2.up * speedV;
                StartCoroutine("damage2");
            }
        }
    }

    IEnumerator damage2(){
        hitBox.enabled = true;
        yield return new WaitForSeconds(0.2f);
        OneTime = false;
        hitBox.enabled = false;
    }
}
