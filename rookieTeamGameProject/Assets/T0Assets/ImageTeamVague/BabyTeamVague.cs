using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyTeamVague : MonoBehaviour
{
    // Start is called before the first frame update
    public float StartForce;
    public Vector2 dir;
    public Rigidbody2D rb;
    public float rotatespeedmax;
    private int RotChoix;
    public float high;
    public Vector3 rot;
    void Start()
    {
        dir = new Vector2(Random.Range(-StartForce, StartForce), Random.Range(4, high));
        rb.AddForce(dir, ForceMode2D.Impulse);
        RotChoix = Random.Range(0, 2);
        if (RotChoix == 0)
        {
            rot = new Vector3(0, 0, Random.Range(-rotatespeedmax, -1));
        }
        else
        {
            rot = new Vector3(0, 0, Random.Range(1, rotatespeedmax));
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rot);
    }
}
