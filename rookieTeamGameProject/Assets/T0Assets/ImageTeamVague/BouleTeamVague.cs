using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BouleTeamVague : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject baby;
    public int nbrcrea;
    public Sprite sprite;
    public GameObject fond;
    public DecomptTeamVague dec;
    public float gravity;
    public bool fin;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(dec.last<=0)
        {
            GetComponent<Rigidbody2D>().gravityScale = gravity;
        }
    }

    public void Createbaby()
    {
        while (nbrcrea > 0)
        {
            GameObject Baby = Instantiate(baby, transform.position, Quaternion.identity);
            Baby.GetComponent<SpriteRenderer>().sprite = sprite;
            /*Baby.GetComponent*/
            nbrcrea -= 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("DeathTrigger"))
        {
            Createbaby();
            if(fin)
            {
                SceneManager.LoadScene("ScoringTeamVague");
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            
        }
        else if(collision.CompareTag("ChangeColor"))
        {
            fond.GetComponent<SpriteRenderer>().sprite = collision.GetComponent<SpriteRenderer>().sprite;
          
        }
    }

}
