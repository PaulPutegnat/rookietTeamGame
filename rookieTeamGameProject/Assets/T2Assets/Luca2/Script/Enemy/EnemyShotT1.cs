using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShotT1 : MonoBehaviour
{
    private float timeBtwAttack;
    public float startTimeBtwAttack;

    public Transform firePoint;
    public GameObject bullet;

    void Update()
    {              
            if (timeBtwAttack <=0){
            Instantiate(bullet, firePoint.position, firePoint.rotation);
            timeBtwAttack = startTimeBtwAttack;
               
           } else {
               timeBtwAttack -= Time.deltaTime;
           }
    }
}
