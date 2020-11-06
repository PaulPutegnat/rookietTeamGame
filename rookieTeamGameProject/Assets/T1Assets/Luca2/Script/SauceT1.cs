using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SauceT1 : MonoBehaviour
{
    private Rigidbody2D rb;

    public Vector3 limit;

    public float speedH;
    public float speedV;

    public GameObject flaque1;
    public GameObject flaque2;
    public GameObject flaque3;

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
            int number = Random.Range(0, 3);
            if(number == 0){
                Instantiate(flaque1, transform.position, transform.rotation);
            }else if(number == 1){
                Instantiate(flaque2, transform.position, transform.rotation);
            }else if(number == 2){
                Instantiate(flaque3, transform.position, transform.rotation);
            }
            Destroy(gameObject);
            
        }
    }

}
