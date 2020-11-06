using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreenT1 : MonoBehaviour
{
    public GameObject transition;

    public int number;

    public GameObject cam1;
    public GameObject cam2;

    public Vector3 spawn2;
    public Transform spawn2R;

    void Start()
    {
        spawn2 = spawn2R.position;
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col){
            if (col.gameObject.tag == "Player"){  
                StartCoroutine("gotonextscene");
            
        }
    }

    IEnumerator gotonextscene(){
        GameObject.Find("Player").GetComponent<PlayerHPT1>().currentHP += 1;
        GameObject.Find("Player").GetComponent<PlayerHPT1>().ActuLife();
        if(number == 2){
            transition.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            SceneManager.LoadScene("EndingT1", LoadSceneMode.Single);
        }else{
            transition.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            cam1.SetActive(false);
            cam2.SetActive(true);
            GameObject.Find("Player").GetComponent<Transform>().transform.position = spawn2;
            yield return new WaitForSeconds(0.2f);
            transition.SetActive(false);
            GameObject.Find("EnemyList").GetComponent<EnemyListT1>().creatEnemy();
            GameObject.Find("WinTP").GetComponent<WinBetweenSceneT1>().return2();
            yield return new WaitForSeconds(1f);
            transition.SetActive(false);
        }

    }
}
