using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHPT1 : MonoBehaviour
{
    public int maxHp;
    public int currentHP;

    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;
    public GameObject heart4;
    public GameObject heart5;
    public Animator anim;

    public bool isInvulneary;

    public bool Onetime;
    void Start()
    {
        currentHP = maxHp;
    }

    void Update()
    {
        if(isInvulneary){
            var player = GameObject.Find("Player").GetComponent<SpriteRenderer>();
            player.color = Color.Lerp(Color.white, Color.red, Mathf.PingPong(Time.time * 8, 0.5f));
        }else{
            var player = GameObject.Find("Player").GetComponent<SpriteRenderer>();
            player.color = Color.white;
        }

        if(currentHP <= 0) {
            if(!Onetime){
                Onetime = true;
                StartCoroutine("death");
            }
        }

        if(currentHP > 5){
            currentHP = 5;
        }
    }

    public void takeDamage(int damage){
        var enmyList = GameObject.Find("EnemyList").GetComponent<EnemyListT1>();
        if(isInvulneary || currentHP <= 0 || enmyList.numberOfEnnemies == 0){
            return;
        }else{
            currentHP -= damage;
            StartCoroutine("InvulFrame");
        }

        ActuLife();
    }

    public void ActuLife(){
        if(currentHP == 5){
            heart1.SetActive(true);
            heart2.SetActive(true);
            heart3.SetActive(true);
            heart4.SetActive(true);
            heart5.SetActive(true);
        }
        if(currentHP == 4){
            heart1.SetActive(true);
            heart2.SetActive(true);
            heart3.SetActive(true);
            heart4.SetActive(true);
            heart5.SetActive(false);
        }
        if(currentHP == 3){
            heart1.SetActive(true);
            heart2.SetActive(true);
            heart3.SetActive(true);
            heart4.SetActive(false);
            heart5.SetActive(false);
        }
        if(currentHP == 2){
            heart1.SetActive(true);
            heart2.SetActive(true);
            heart3.SetActive(false);
            heart4.SetActive(false);
            heart5.SetActive(false);
        }
        if(currentHP == 1){
            heart1.SetActive(true);
            heart2.SetActive(false);
            heart3.SetActive(false);
            heart4.SetActive(false);
            heart5.SetActive(false);
        }if(currentHP == 0){
            heart1.SetActive(false);
            heart2.SetActive(false);
            heart3.SetActive(false);
            heart4.SetActive(false);
            heart5.SetActive(false);
        }

    }

    IEnumerator InvulFrame(){
        isInvulneary = true;
        yield return new WaitForSeconds(1f);
        isInvulneary = false;
    }

    IEnumerator death(){
        anim.SetTrigger("Death");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("RouletteTimeT1", LoadSceneMode.Single);
    }
}
