using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T8GenerationSlot : MonoBehaviour
{
    private GameObject item;
    public string type;

    private GameObject child1;
    private GameObject child2;
    private GameObject child3;
    private GameObject result;

    T8ItemSlot itemSlot;

    public bool empty = true;
    public float rollingTime = 5.0f;
    public float rollingDelay = 0.2f;
    float _rollTime;
    float _rollDelay;

    
    void Awake()
    {
        if(type == ""){
            Debug.Log("Vous n'avez pas défini le type de slot (shape/material/power)");
        }
        itemSlot = GameObject.Find("ItemSlot").GetComponent<T8ItemSlot>();
    }
    void Start()
    {
        child1 = gameObject.transform.GetChild(0).gameObject;
        child2 = gameObject.transform.GetChild(1).gameObject;
        child3 = gameObject.transform.GetChild(2).gameObject;

        _rollTime = rollingTime;
        _rollDelay = rollingDelay;


        // defineItem();
    }

    void FixedUpdate(){
        
        if(_rollTime > 0 && empty){
            if(_rollDelay < 0){
                float random = Random.value;

                if(type == "shape"){
                    if(random < 0.33f){
                        child1.SetActive(true);
                        child2.SetActive(false);
                        child3.SetActive(false);
                        result = child1;
                    } else if(0.33f <= random && random < 0.66f){
                        child1.SetActive(false);
                        child2.SetActive(true);
                        child3.SetActive(false);
                        result = child2;
                    } else {
                        child1.SetActive(false);
                        child2.SetActive(false);
                        child3.SetActive(true);
                        result = child3;
                    }
                } else if(type == "material"){
                    if(random < 0.15f){
                        child1.SetActive(true);
                        child2.SetActive(false);
                        child3.SetActive(false);
                        result = child1;
                    } else if(0.15f <= random && random < 0.575f){
                        child1.SetActive(false);
                        child2.SetActive(true);
                        child3.SetActive(false);
                        result = child2;
                    } else {
                        child1.SetActive(false);
                        child2.SetActive(false);
                        child3.SetActive(true);
                        result = child3;
                    }
                } else if(type == "power"){
                    if(random < 0.20f){
                        child1.SetActive(true);
                        child2.SetActive(false);
                        child3.SetActive(false);
                        result = child1;
                    } else if(0.20f <= random && random < 0.60f){
                        child1.SetActive(false);
                        child2.SetActive(true);
                        child3.SetActive(false);
                        result = child2;
                    } else {
                        child1.SetActive(false);
                        child2.SetActive(false);
                        child3.SetActive(true);
                        result = child3;
                    }
                } 

                _rollDelay = rollingDelay;
            }
            _rollTime -= Time.deltaTime;
            _rollDelay -= Time.deltaTime;
        } else if(empty) {
            defineItem();
        }
    }

    public void rollItem(){
        _rollTime = rollingTime;
    }

    void defineItem()
    {
        if(result == child1){
            itemSlot.setCharacteristic(type, 1);
        } else if(result == child2){
            itemSlot.setCharacteristic(type, 2);
        } else {
            itemSlot.setCharacteristic(type, 3);
        }
        empty = false;
    }

    public void clearItem()
    {
        child1.SetActive(false);
        child2.SetActive(false);
        child3.SetActive(false);

        item = null;
    }

}
