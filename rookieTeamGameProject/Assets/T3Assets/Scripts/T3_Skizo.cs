using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T3_Skizo : MonoBehaviour
{
    public GameObject[] emot;
    public int timeSwitch;

    private int spawn = 0;

    private void Update()
    { 
        StartCoroutine(SwitchEmot());
        StartCoroutine(KillEmot());
    }

    IEnumerator SwitchEmot()
    {
        yield return new WaitForSeconds(timeSwitch);
        if(spawn == 0 )
        {
            Instantiate(emot[Random.Range(0, emot.Length)], gameObject.transform.position, Quaternion.identity);
            spawn++;
        }

    }
    IEnumerator KillEmot()
    {
        yield return new WaitForSeconds(timeSwitch);
        Destroy(gameObject);
    }
}
