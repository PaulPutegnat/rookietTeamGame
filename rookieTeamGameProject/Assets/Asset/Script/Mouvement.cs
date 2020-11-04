using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouvement : MonoBehaviour
{
    [SerializeField] private float speed;
    void Update()
    {
        if (Input.GetKey("right"))
        {
            transform.Translate(Time.deltaTime * speed, 0, 0);
        }
        if (Input.GetKey("left"))
        {
            transform.Translate(-Time.deltaTime * speed, 0, 0);
        }
    }


}