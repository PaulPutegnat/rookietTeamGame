using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnnemyTeamVague : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;
    public float speed;
    public EnnemyManagerTeamVague manage;
    public DecomptTeamVague dec;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Moving()
    {
        if(dec.last<=0)
        {
        rb.velocity = new Vector2(speed, 0);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Trigger"))
        {
            manage.state = EnnemyManagerTeamVague.phase.Replace;
        }
    }

    
}
