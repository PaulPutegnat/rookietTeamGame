using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTeamVague : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public ControlToucheTeamVague control;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(control.down))
        {
            transform.Rotate(0, 0, -speed);
        }else if(Input.GetKey(control.up))
        {
            transform.Rotate(0, 0, speed);
        }
    }
}
