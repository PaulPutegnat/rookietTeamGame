using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BicepsT1 : MonoBehaviour
{
    private float timeBtwAttack;
    public float startTimeBtwAttack;

    public Transform firePoint;
    public GameObject bullet;

    private Animator anim;
    private Rigidbody2D rb;
    public Transform UpLimit;
    public Transform DownLimit;
    public Transform LeftLimit;
    public Transform RightLimit;

    public float speedV;
    public float speedH;

    public bool Vbool;
    public bool Hbool;

    public float saveV;
    public float saveH;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        UpLimit.transform.parent = null;
        DownLimit.transform.parent = null;
        RightLimit.transform.parent = null;
        LeftLimit.transform.parent = null;

        var number = Random.Range(0, 2);
        if(number == 0){
            speedH *= -1;
        }
        number = Random.Range(0, 2);
        if(number == 0){
            speedV *= -1;
        } 
        
    }

    void Update()
    {              
            if (timeBtwAttack <=0){
            Instantiate(bullet, firePoint.position, firePoint.rotation);
            timeBtwAttack = startTimeBtwAttack;
            StartCoroutine("Shooting");
               
           } else {
               timeBtwAttack -= Time.deltaTime;
           }



           rb.velocity = new Vector2(speedH, speedV);

        if(transform.position.x < LeftLimit.position.x || transform.position.x > RightLimit.position.x){
            if(!Hbool){
                speedH *= -1;
                saveH *= -1;
                Hbool = true;
                StartCoroutine("Hrecov");
            }
        }

        if(transform.position.y < DownLimit.position.y || transform.position.y > UpLimit.position.y){
            if(!Vbool){
                speedV *= -1;
                saveV *= -1;
                Vbool = true;
                StartCoroutine("Vrecov");
            }
        }


    }
        IEnumerator Hrecov(){
            yield return new WaitForSeconds(0.25f);
            Hbool = false;
        }

        IEnumerator Vrecov(){
            yield return new WaitForSeconds(0.25f);
            Vbool = false;
        }

        IEnumerator Shooting(){
            anim.SetTrigger("Attack");
            speedH = 0;
            speedV = 0;
            yield return new WaitForSeconds(0.3f);
            speedH = saveH;
            speedV = saveV;
            
        }
}