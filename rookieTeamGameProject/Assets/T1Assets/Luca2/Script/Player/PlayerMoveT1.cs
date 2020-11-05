using System.Collections;//Equipe Nuage
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveT1 : MonoBehaviour
{
    private Rigidbody2D rb;
    public Animator anim;
    public float speedH;
    public float speedV;
    private float speedHBase;
    private float speedVBase;

    public Transform firePoint;
    public GameObject knife;
    public GameObject boomerang;
    public GameObject enclume;
    public GameObject ballon;

    public GameObject tornade1;
    public GameObject tornade2;
    public GameObject tornade3;

    public GameObject tomate;

    public Transform firePointB;
    public GameObject boxer;
    public GameObject bullet;

    private float timeBtwAttack;
    public float startTimeBtwAttack;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        rb.velocity = new Vector2(speedHBase, speedVBase); //Movement *****************************************************************************************
        if(!anim.GetCurrentAnimatorStateInfo(0).IsName("PlayerAttack") && !anim.GetCurrentAnimatorStateInfo(0).IsName("PlayerDeath")){
           if(Input.GetKey("z")){
               speedVBase = speedV;
           }else if(Input.GetKey("s")){
               speedVBase = -speedV;
           }else{
               speedVBase = 0;
           }

           if(Input.GetKey("q")){
               speedHBase = -speedH;
           }else if(Input.GetKey("d")){
               speedHBase = speedH;
           }else{
               speedHBase = 0;
           }
           if(speedHBase == 0 && speedVBase == 0){
               anim.SetBool("Move", false);
           }else{
               anim.SetBool("Move", true);
           }
        }else{
            speedHBase = 0;
            speedVBase = 0;
        }

        if(!anim.GetCurrentAnimatorStateInfo(0).IsName("PlayerDeath")){
           if(Input.GetKeyDown(KeyCode.Space)){ // Shoot ****************************************************************************************************************
                if (timeBtwAttack <=0){
                        StartCoroutine("Shooting");
                        timeBtwAttack = startTimeBtwAttack;
                        anim.SetTrigger("Attack");
                }
                } else {
                    timeBtwAttack -= Time.deltaTime;
                }
        }
           

    }


    IEnumerator Shooting(){
        yield return new WaitForSeconds(0.2f);
        var inv = GameObject.Find("GestionInventaire").GetComponent<InventaireT1>();
        if(inv.Deck[0].name == "Knife"){
            Instantiate(knife, firePoint.position, firePoint.rotation);
        }else if(inv.Deck[0].name == "Gant De Boxe"){
            Instantiate(boxer, firePointB.position, firePointB.rotation);
        }else if(inv.Deck[0].name == "Boomerang"){
            Instantiate(boomerang, firePoint.position, firePoint.rotation);
        }else if(inv.Deck[0].name == "Enclume"){
            Instantiate(enclume, firePoint.position, firePoint.rotation);
        }else if(inv.Deck[0].name == "Ballon"){
            Instantiate(ballon, firePoint.position, firePoint.rotation);
        }else if(inv.Deck[0].name == "Sauce"){
            Instantiate(tomate, firePoint.position, firePoint.rotation);
        }else if(inv.Deck[0].name == "Tornade"){
            var number = GameObject.Find("EnemyList").GetComponent<EnemyListT1>();
            if(number.number == 1){
                Instantiate(tornade1, firePoint.position, firePoint.rotation);
            }else if(number.number == 2){
                Instantiate(tornade2, firePoint.position, firePoint.rotation);
            }else if(number.number == 3){
                Instantiate(tornade3, firePoint.position, firePoint.rotation);
            }    
        }
        inv.Deleteitem();
        
    }
}
