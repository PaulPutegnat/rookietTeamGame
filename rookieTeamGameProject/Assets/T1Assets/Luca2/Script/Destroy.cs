using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public float timeToDelete;
    public bool intro;
    void Start()
    {
        if(intro){
            StartCoroutine("startihyefzihur");
        }else{
            Destroy(gameObject, timeToDelete);
        }
    }

    IEnumerator startihyefzihur(){
        yield return new WaitForSecondsRealtime(timeToDelete);
        Destroy(gameObject, timeToDelete);
    }
}
