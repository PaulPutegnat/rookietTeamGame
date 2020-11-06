using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallcheckt9 : MonoBehaviour
{
    GameObject Player;
    public bool anotherWall = true;
    // Start is called before the first frame update
    void Start()
    {
        Player = gameObject.transform.parent.gameObject;
    }
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Wall" && anotherWall == true)
        {
            Player.GetComponent<PlayerT9>().isOnAWall = true;
            anotherWall = false;
        }

        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Wall")
        {
            Player.GetComponent<PlayerT9>().isOnAWall = false;
            anotherWall = true;
        }
    }
}
