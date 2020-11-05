using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T3_Bipo : MonoBehaviour
{
    public GameObject[] emot;

    void Start()
    {

    }

    public void BipoKill(GameObject emotBipo)
    {
        Instantiate(emot[Random.Range(0, emot.Length)],emotBipo.transform.position, Quaternion.identity);
        Destroy(emotBipo);
    }

}
