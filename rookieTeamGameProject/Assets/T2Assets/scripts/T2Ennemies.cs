using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class T2Ennemies : MonoBehaviour
{
    [SerializeField] private float wait;
    public GameObject Manager;
    public float speed;
    public GameObject EnnemyHolder;
    private void Start()
    {
        EnnemyHolder = GameObject.Find("EnnemyHolder");
        Manager = GameObject.Find("Ennemy_Generator");
        speed = Manager.GetComponent<T2DifficultyManagement>().currentspeed;
        Destroy(gameObject,10);
        
        gameObject.transform.parent = EnnemyHolder.transform;
    }
  
    void Update()
    {
        if(wait > 0)
        {
            wait -= Time.deltaTime;
        }
        else
        {
            transform.Translate(0, Time.deltaTime * speed, 0);
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            GameObject.Find("Canvas").GetComponent<T2TestButton>().InitialisationButton = false;
            collision.GetComponent<T2Movement>().conteur++;
            GameObject.Find("Ennemy_Generator").GetComponent<T2DifficultyManagement>().PhaseActive = false;

            GameObject.Find("Ennemy_Generator").GetComponent<T2DifficultyManagement>().phase = 1;
            GameObject.Find("Ennemy_Generator").GetComponent<T2DifficultyManagement>().temps = 15f; ;
            Manager.GetComponent<T2DifficultyManagement>().currentspeed = 5 * GameObject.Find("Ennemy_Generator").GetComponent<T2DifficultyManagement>().MultiplicateurSpeed;
            if (GameObject.Find("Canvas").GetComponent<T2TestButton>().manche == 4 )
            {
                
            }
            foreach (Transform child in EnnemyHolder.transform)
                Destroy(child.gameObject);
        }
    }
   
       
        
            
            
      
    
}
