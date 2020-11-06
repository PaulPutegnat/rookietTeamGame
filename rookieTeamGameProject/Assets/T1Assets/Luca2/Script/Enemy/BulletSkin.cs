using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSkin : MonoBehaviour
{
    public Sprite n1;
    public Sprite n2;
    public Sprite n3;
    public Sprite n4;
    public Sprite n5;
    void Start()
    {
        int number = Random.Range(0, 4);
        if(number == 0){
            GetComponent<SpriteRenderer>().sprite = n1;
        }else if(number == 1){
            GetComponent<SpriteRenderer>().sprite = n2;
        }else if(number == 2){
            GetComponent<SpriteRenderer>().sprite = n3;
        }else if(number == 3){
            GetComponent<SpriteRenderer>().sprite = n4;
        }else if(number == 4){
            GetComponent<SpriteRenderer>().sprite = n5;
        }
    }

    void Update()
    {
        
    }
}
