using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyListT1 : MonoBehaviour
{
    public int numberOfEnnemies;
    public bool OneTime;
    public int number;

    public GameObject mama1;
    public GameObject papy1;
    public GameObject mamy1;
    public GameObject kid1;
    public GameObject dog1;
    public GameObject bicept1;
    public GameObject mascotte1;


    public GameObject mama2;
    public GameObject papy2;
    public GameObject mamy2;
    public GameObject kid2;
    public GameObject dog2;
    public GameObject bicept2;
    public GameObject mascotte2;


    public GameObject mama3;
    public GameObject papy3;
    public GameObject mamy3;
    public GameObject kid3;
    public GameObject dog3;
    public GameObject bicept3;
    public GameObject mascotte3;
    void Start()
    {
        creatEnemy();
    }

    void Update()
    {
        if(numberOfEnnemies == 0 && OneTime == false){
            StartCoroutine("EndOfBattle");
        }
    }

    IEnumerator EndOfBattle(){
        OneTime = true;
        yield return new WaitForSeconds(0.2f);
        Debug.Log("GG t un bg");
        if(number == 1){
            GameObject.Find("WinTP").GetComponent<WinBetweenSceneT1>().winner();
            number+=1;
        }
        else if(number == 2){
            GameObject.Find("WinTP").GetComponent<WinBetweenSceneT1>().winner();
            number+=1;
        }
        else if(number == 3){
            GameObject.Find("WinTP").GetComponent<WinBetweenSceneT1>().winner();
            number+=1;
        }
     }

     public void creatEnemy(){
         if(number == 1){
             int enemy1 = (Random.Range(0, 5));
                 if(enemy1 == 0){
                     mama1.SetActive(true);
                 }else if(enemy1 == 1){
                     papy1.SetActive(true);
                 }else if(enemy1 == 2){
                     kid1.SetActive(true);
                 }else if(enemy1 == 3){
                     dog1.SetActive(true);
                 }else if(enemy1 == 4){
                     bicept1.SetActive(true);
                 }
             
            if(enemy1 != 0){
                int enemy2 = (Random.Range(1, 5));
             if(enemy2 == enemy1){
                 while(enemy2 == enemy1){
                    enemy2 = (Random.Range(1, 5));
                 }
             }
             
                if(enemy2 == 1){
                     papy1.SetActive(true);
                 }else if(enemy2 == 2){
                     kid1.SetActive(true);
                 }else if(enemy2 == 3){
                     dog1.SetActive(true);
                 }else if(enemy2 == 4){
                     bicept1.SetActive(true);
                 }
            }

            //GameObject.Find("Timer").GetComponent<TimerT1>().start = true;
            }
             



        if(number == 2){
             int enemy12 = (Random.Range(0, 5));
                 if(enemy12 == 0){
                     mama2.SetActive(true);
                 }else if(enemy12 == 1){
                     papy2.SetActive(true);
                 }else if(enemy12 == 2){
                     kid2.SetActive(true);
                 }else if(enemy12 == 3){
                     dog2.SetActive(true);
                 }else if(enemy12 == 4){
                     bicept2.SetActive(true);
                 }
             
            if(enemy12 != 0){
                int enemy22 = (Random.Range(1, 5));
             if(enemy22 == enemy12){
                 while(enemy22 == enemy12){
                    enemy22 = (Random.Range(1, 5));
                 }
             }
             
                if(enemy22 == 1){
                     papy2.SetActive(true);
                 }else if(enemy22 == 2){
                     kid2.SetActive(true);
                 }else if(enemy22 == 3){
                     dog2.SetActive(true);
                 }else if(enemy22 == 4){
                     bicept2.SetActive(true);
                 }
            }
             
            }


        if(number == 3){
             int enemy13 = (Random.Range(0, 5));
                 if(enemy13 == 0){
                     mama3.SetActive(true);
                 }else if(enemy13 == 1){
                     papy3.SetActive(true);
                 }else if(enemy13 == 2){
                     kid3.SetActive(true);
                 }else if(enemy13 == 3){
                     dog3.SetActive(true);
                 }else if(enemy13 == 4){
                     bicept3.SetActive(true);
                 }
             
            if(enemy13 != 0){
                int enemy23 = (Random.Range(0, 5));
             if(enemy23 == enemy13){
                 while(enemy23 == enemy13){
                    enemy23 = (Random.Range(0, 5));
                 }
             }
             
                 if(enemy23 == 0){
                     mama3.SetActive(true);
                 }else if(enemy23 == 1){
                     papy3.SetActive(true);
                 }else if(enemy23 == 2){
                     kid3.SetActive(true);
                 }else if(enemy23 == 3){
                     dog3.SetActive(true);
                 }else if(enemy23 == 4){
                     bicept3.SetActive(true);
                 }
            }
             
            }
            checkEnemy();
            Debug.Log("voqjzjvju");
         }

     void checkEnemy(){
         foreach (var enemy in GameObject.FindGameObjectsWithTag("Enemy"))
         {
             numberOfEnnemies += 1;
         }
         OneTime = false;
     }
}
