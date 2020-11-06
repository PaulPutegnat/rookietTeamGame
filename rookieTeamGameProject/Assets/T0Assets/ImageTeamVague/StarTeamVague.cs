using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarTeamVague : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform posmax;
    public Transform posmin;
    public float cd;
    public float postogo;
    public float speed;
    public DecomptTeamVague dec;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(dec.last<=0)
        {

        if(cd<=0)
        {
            postogo = Random.Range(posmin.position.y, posmax.position.y);
            cd = 3;
        }
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, postogo, transform.position.z), speed);
        cd -= Time.deltaTime;
        }
    }
}
