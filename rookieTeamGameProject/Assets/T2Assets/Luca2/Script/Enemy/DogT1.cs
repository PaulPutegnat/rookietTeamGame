using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogT1 : MonoBehaviour
{
    public Vector3 target;
    public GameObject targetR;
    public float speed;
    public float speedBase;

    public GameObject damageArea;

    public bool stopFollow;
    void Start()
    {
        target = targetR.transform.position;
        target.y -= 1;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);

        if(transform.position == target){
            StartCoroutine("waitToMove");
        }
    }

    IEnumerator waitToMove(){
        yield return new WaitForSeconds(1f);
        target = targetR.transform.position;
        target.y -= 1;
    }

}
