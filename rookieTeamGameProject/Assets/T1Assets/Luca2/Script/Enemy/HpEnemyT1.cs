using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpEnemyT1 : MonoBehaviour
{
public int maxHp;
    public int currentHP;
    public int addScore = 1;

    public bool mother;
    public GameObject son;

    public GameObject blast;

    private GameObject scoreMaster;

    void Start()
    {
        currentHP = maxHp;
        scoreMaster = GameObject.Find("score_Manager");
    }

    void Update()
    {
        score_Manager scoreManager = scoreMaster.GetComponent<score_Manager>();

        if(currentHP <= 0){
            GameObject.Find("EnemyList").GetComponent<EnemyListT1>().numberOfEnnemies -= 1;

            if(mother){
                if(son){
                    var sonReal = GameObject.Find(son.name);
                    sonReal.GetComponent<FollowT1>().enabled = false;
                    sonReal.GetComponent<EnemyMoveT1>().enabled = true;
                }
            }
            Instantiate(blast, transform.position, transform.rotation);
            Destroy(gameObject);

            scoreManager.Score += addScore;
        }
    }

    public void takeDamage(int damage){
        currentHP -= damage;
        StartCoroutine("InvulFrame");
    }


    IEnumerator InvulFrame(){
        GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.2f);
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}
