using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltereT1 : MonoBehaviour
{
    public float speedH;
    public float speedV;

    private Rigidbody2D rb;

    public GameObject up;
    public GameObject bottom;

    public bool Vbool;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Vbool = false;
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
    }
        IEnumerator Vrecov(){
            yield return new WaitForSeconds(0.25f);
            Vbool = false;
        }
}
