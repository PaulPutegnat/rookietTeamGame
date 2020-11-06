using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FollowerTeamVague : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;
    public float force;
    public ControlToucheTeamVague control;
    public DecomptTeamVague dec;
    public float gravity;
    public bool fin;
    
 
    // Update is called once per frame
    void Update()
    {
        if(dec.last<=0)
        {
            rb.gravityScale = gravity;
        if (Input.GetKeyDown(control.down))
        {
            rb.AddForce(new Vector2(0, force), ForceMode2D.Impulse);
           
        }
        }
        

    }

   


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("ChangeColor"))
        {
          GetComponent<SpriteRenderer>().sprite = collision.GetComponent<SpriteRenderer>().sprite;
        }
        else if (collision.CompareTag("DeathTrigger"))
        {
            if (fin)
            {
                SceneManager.LoadScene("ScoringTeamVague");
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }




}
