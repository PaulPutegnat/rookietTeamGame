using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowT1 : MonoBehaviour
{
    public Vector3 target;
    public GameObject targetR;
    public float speed;
    public float speedBase;

    public bool stopFollow;
    void Start()
    {
        StartCoroutine("speedActu");
    }

    void Update()
    {
        if(!stopFollow){
            target = targetR.transform.position;
            transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);
        }else{
            
        }
    }

    IEnumerator speedActu(){
        yield return new WaitForSeconds(0.25f);
        speed = speedBase;
    }
}
