using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TornadeT1 : MonoBehaviour
{
    public float speedH;
    public float speedV;

    private Rigidbody2D rb;

    public GameObject up;
    public GameObject bottom;
    public bool Vbool;


    private float timeBtwAttack;
    public float startTimeBtwAttack;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Vbool = false;
        startTimeBtwAttack = Random.Range(0f,2f);
        timeBtwAttack = startTimeBtwAttack;
    }

    void Update()
    {
        rb.velocity = new Vector2(speedH, speedV);
        if(transform.position.y < bottom.transform.position.y){
            if(!Vbool){
                speedV *= -1;
                Vbool = true;
                StartCoroutine("Vrecov");
            }
        }

        if(transform.position.y > up.transform.position.y){
            if(!Vbool){
                speedV *= -1;
                Vbool = true;
                StartCoroutine("Vrecov");
            }
        }


        if (timeBtwAttack <=0){
            speedV *= -1;
            startTimeBtwAttack = Random.Range(0f,2f);
            timeBtwAttack = startTimeBtwAttack;
               
           } else {
               timeBtwAttack -= Time.deltaTime * 2;
           }
              
    }
        IEnumerator Vrecov(){
            yield return new WaitForSeconds(0.005f);
            Vbool = false;
        }
}
