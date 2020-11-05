using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T8AsteroidScr : MonoBehaviour
{
    public Sprite[] asteroid;

    [SerializeField]
    public float speed = 1.0f;
    public float aliveTime = 10.0f;
    // Vector3 target;
    Vector3 target;
    GameObject targetObject;
    public bool doDamage = true;


    
    Rigidbody2D rb;

    Vector2 lookDirection;

    float lookAngle;


    void Awake()
    {
        GetComponentInChildren<SpriteRenderer>().sprite = asteroid[Random.Range(0, asteroid.Length)];

        rb = GetComponent<Rigidbody2D>();
        targetObject = GameObject.Find("Player");
        target = targetObject.transform.position;
        // itemRange = planetRange;
        // gravityForce = planetForce;
    }

    void FixedUpdate()
    {
        moveTarget();
        aliveTime -= Time.deltaTime;
        if(aliveTime < 0){
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player" && doDamage)
        {
            collision.gameObject.GetComponent<T8_Player>().GetHit();
            Destroy(gameObject);
        }
    }

    private void moveTarget()
    {
        Vector3 v;
        if(targetObject.name == "Player"){
            v = target - transform.position;

            rb.AddForce(v.normalized * 0.1f * speed);

            // Rotating to the target
            lookDirection = target - transform.position;
            lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(0f, 0f, lookAngle);  
        }



    }
}
