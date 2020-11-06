using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingMovementTeamVague : MonoBehaviour
{
    public float speed;

    [Header("moveUp")]
    public Vector2 moveUp;
    public Transform transmax;
    public Transform upMax;

    [Header("moveDown")]
    public Vector2 moveDown;
    public Transform transmin;
    public Transform downMin;

    [HideInInspector]
    public Vector3 building3;
    public ControlToucheTeamVague control;
    public DecomptTeamVague dec;

    private void Start()
    {
        
    }

    private void Update()
    {
        if(dec.last<=0)
        {

        if (Input.GetKey(control.up))
        {
            transform.Translate(moveUp * speed * Time.deltaTime);
        }
        else if (!Input.GetKey(control.up))
        {
            transform.Translate(moveDown * speed * Time.deltaTime);
        }

        if(transform.position.y >= upMax.position.y)
        {
            building3 = transform.position;
            building3.y = upMax.position.y;
            transform.position = building3;
        }
        else if(transform.position.y <= downMin.position.y)
        {
            building3 = transform.position;
            building3.y = downMin.position.y;
            transform.position = building3;
        }
        }
    }
}
