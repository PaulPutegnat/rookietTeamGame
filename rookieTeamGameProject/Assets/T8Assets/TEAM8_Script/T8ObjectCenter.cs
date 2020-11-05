using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T8ObjectCenter : MonoBehaviour
{

    [HideInInspector]
    public bool inZone1;
    [HideInInspector]
    public bool inZone2;
    [HideInInspector]
    public bool inZone3;
    GameObject sector1;
    GameObject sector2;
    GameObject sector3;
    T8DragableItem parent;
    Color sectorColor;
    // Start is called before the first frame update
    void Awake()
    {
        parent = gameObject.GetComponentInParent<T8DragableItem>();
        
        sector1 = GameObject.Find("Zone 1");
        sector2 = GameObject.Find("Zone 2");
        sector3 = GameObject.Find("Zone 3");
        
        sectorColor.r = 0f;
        sectorColor.g = 0f;
        sectorColor.b = 0f;
        sectorColor.a = 0f;
        sector1.GetComponent<SpriteRenderer>().color = sectorColor;
        sector2.GetComponent<SpriteRenderer>().color = sectorColor;
        sector3.GetComponent<SpriteRenderer>().color = sectorColor;
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "Player" || other.name == "ItemSlot"){
            setActiveSector("");
        } else if(!other.name.Contains("Asteroid")){
            setActiveSector(other.name);
        }
    }

    
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.name == "Player"){
            setActiveSector("Zone 1");
        }else 
        if(other.name == "Zone 3"){
            float d1 = sector2.GetComponent<PolygonCollider2D>().Distance(parent.GetComponent<PolygonCollider2D>()).distance;
            
            if(d1 < 0){
                setActiveSector("Zone 2");
            } else {
                setActiveSector("");
            }
        }
    }
    
    public void setActiveSector(string sector)
    {
        if(sector == "Zone 1"){
            inZone1 = true;
            inZone2 = false;
            inZone3 = false;
            sectorColor.a = 0.2f;
            if(parent.materialType >= 1){
                sectorColor.r = 0f;
                sectorColor.g = 1f;
                sectorColor.b = 0f;
            } else {
                sectorColor.r = 1f;
                sectorColor.g = 0f;
                sectorColor.b = 0f;
            }
            sector1.GetComponent<SpriteRenderer>().color = sectorColor;
            
            sectorColor.a = 0f;
            sector2.GetComponent<SpriteRenderer>().color = sectorColor;
            
            sectorColor.a = 0f;
            sector3.GetComponent<SpriteRenderer>().color = sectorColor;
        } else if(sector == "Zone 2"){
            inZone1 = false;
            inZone2 = true;
            inZone3 = false;
            sectorColor.a = 0f;
            sector1.GetComponent<SpriteRenderer>().color = sectorColor;
            
            sectorColor.a = 0.2f;
            if(parent.materialType >= 2){
                sectorColor.r = 0f;
                sectorColor.g = 1f;
                sectorColor.b = 0f;
            } else {
                sectorColor.r = 1f;
                sectorColor.g = 0f;
                sectorColor.b = 0f;
            }
            sector2.GetComponent<SpriteRenderer>().color = sectorColor;
            
            sectorColor.a = 0f;
            sector3.GetComponent<SpriteRenderer>().color = sectorColor;
        } else if(sector == "Zone 3"){
            inZone1 = false;
            inZone2 = false;
            inZone3 = true;
            sectorColor.a = 0f;
            sector1.GetComponent<SpriteRenderer>().color = sectorColor;
            
            sectorColor.a = 0f;
            sector2.GetComponent<SpriteRenderer>().color = sectorColor;
            
            sectorColor.a = 0.2f;
            if(parent.materialType >= 3){
                sectorColor.r = 0f;
                sectorColor.g = 1f;
                sectorColor.b = 0f;
            } else {
                sectorColor.r = 1f;
                sectorColor.g = 0f;
                sectorColor.b = 0f;
            }
            sector3.GetComponent<SpriteRenderer>().color = sectorColor;
        } else {
            inZone1 = false;
            inZone2 = false;
            inZone3 = false;
            sectorColor.a = 0f;
            sector1.GetComponent<SpriteRenderer>().color = sectorColor;
            
            sectorColor.a = 0f;
            sector2.GetComponent<SpriteRenderer>().color = sectorColor;
            
            sectorColor.a = 0f;
            sector3.GetComponent<SpriteRenderer>().color = sectorColor;
        }
    }
}
