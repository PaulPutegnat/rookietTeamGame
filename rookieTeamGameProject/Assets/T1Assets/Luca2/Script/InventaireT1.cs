using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventaireT1 : MonoBehaviour
{
    public List<ItemT1> Deck = new List<ItemT1>(4); // Dans l'inventaire

    public List<ItemT1> AllItem = new List<ItemT1>(); // Tous les item dispo pour la game

    public List<ItemT1> AllItemTrue = new List<ItemT1>(); // Tous les item dispo en tt

    public int maxItem;

    void Start()
    {
        var logosys = GameObject.Find("LogoSystem").GetComponent<LogoSystem>();
        if(logosys.logo1 == 0 || logosys.logo2 == 0){
            AllItem.Add(AllItemTrue[0]);
        }
        if(logosys.logo1 == 1 || logosys.logo2 == 1){
            AllItem.Add(AllItemTrue[1]);
        }
        if(logosys.logo1 == 2 || logosys.logo2 == 2){
            AllItem.Add(AllItemTrue[2]);
        }
        if(logosys.logo1 == 3 || logosys.logo2 == 3){
            AllItem.Add(AllItemTrue[3]);
        }
        if(logosys.logo1 == 4 || logosys.logo2 == 4){
            AllItem.Add(AllItemTrue[4]);
        }
        if(logosys.logo1 == 5 || logosys.logo2 == 5){
            AllItem.Add(AllItemTrue[5]);
        }
        if(logosys.logo1 == 6 || logosys.logo2 == 6){
            AllItem.Add(AllItemTrue[6]);
        }
        majItem();
    }

    void Update()
    {
        
    }

    public void majItem(){
        int counter = 0;
        if(Deck.Count == 0){
            while(Deck.Count < maxItem){
                ItemT1 addItem = AllItem[Random.Range(0,AllItem.Count)];
                Deck.Add(addItem);

                var visu = GameObject.Find("Object (" + counter +")");
                visu.GetComponent<Image>().sprite = Deck[counter].image;

                counter +=1;
            }
        }else{
            while(counter < Deck.Count){
                var visu = GameObject.Find("Object (" + counter +")");
                visu.GetComponent<Image>().sprite = Deck[counter].image;
                counter += 1;

            }
            while(counter == Deck.Count && counter < maxItem){
                ItemT1 addItem = AllItem[Random.Range(0,AllItem.Count)];
                Deck.Add(addItem);
                var visu = GameObject.Find("Object (" + counter +")");
                visu.GetComponent<Image>().sprite = Deck[counter].image;
                counter += 1;
            }
        }
        counter = 0;
        var nameItem = GameObject.Find("Nom");
        nameItem.GetComponent<Text>().text = Deck[counter].name;

        var nameDesc = GameObject.Find("Description");
        nameDesc.GetComponent<Text>().text = Deck[counter].description;

    }


    public void Deleteitem(){
        Deck.RemoveAt(0);
        majItem();
    }
}
