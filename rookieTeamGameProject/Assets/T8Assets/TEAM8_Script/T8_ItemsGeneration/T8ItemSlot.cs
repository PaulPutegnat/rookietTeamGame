using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class T8ItemSlot : MonoBehaviour
{
    public bool empty = true;
    public GameObject placeableItem;
    public GameObject shapeSlot;
    public GameObject matSlot;
    public GameObject powerSlot;

    public bool readyToGenerate = false;

    public Sprite T8_item_shape1_material1_power1;
    public Sprite T8_item_shape1_material1_power2;
    public Sprite T8_item_shape1_material1_power3;
    public Sprite T8_item_shape1_material2_power1;
    public Sprite T8_item_shape1_material2_power2;
    public Sprite T8_item_shape1_material2_power3;
    public Sprite T8_item_shape1_material3_power1;
    public Sprite T8_item_shape1_material3_power2;
    public Sprite T8_item_shape1_material3_power3;
    public Sprite T8_item_shape2_material1_power1;
    public Sprite T8_item_shape2_material1_power2;
    public Sprite T8_item_shape2_material1_power3;
    public Sprite T8_item_shape2_material2_power1;
    public Sprite T8_item_shape2_material2_power2;
    public Sprite T8_item_shape2_material2_power3;
    public Sprite T8_item_shape2_material3_power1;
    public Sprite T8_item_shape2_material3_power2;
    public Sprite T8_item_shape2_material3_power3;
    public Sprite T8_item_shape3_material1_power1;
    public Sprite T8_item_shape3_material1_power2;
    public Sprite T8_item_shape3_material1_power3;
    public Sprite T8_item_shape3_material2_power1;
    public Sprite T8_item_shape3_material2_power2;
    public Sprite T8_item_shape3_material2_power3;
    public Sprite T8_item_shape3_material3_power1;
    public Sprite T8_item_shape3_material3_power2;
    public Sprite T8_item_shape3_material3_power3;


    int shapeId;
    int materialId;
    int powerId;



    void Awake()
    {
        // if(typeSlot == null){
        //     Debug.Log("Vous avez oublié de link le slot de génération de forme sur le slot de résultat");
        //     EditorApplication.isPlaying = false;
        // }
        
        // if(matSlot == null){
        //     Debug.Log("Vous avez oublié de link le slot de génération de matériau sur le slot de résultat");
        //     EditorApplication.isPlaying = false;
        // }
        
        // if(powerSlot == null){
        //     Debug.Log("Vous avez oublié de link le slot de génération de pouvoir sur le slot de résultat");
        //     EditorApplication.isPlaying = false;
        // }
    }


    public void setCharacteristic(string name, int i)
    {
        if(name.Equals("shape")){
            shapeId = i;
        } else if(name.Equals("material")){
            materialId = i;
        } else if(name.Equals("power")){
            powerId = i;
        }  
    }

    void Update()
    {
        if(readyToGenerate){
            shapeSlot.GetComponent<T8GenerationSlot>().rollItem();
            matSlot.GetComponent<T8GenerationSlot>().rollItem();
            powerSlot.GetComponent<T8GenerationSlot>().rollItem();
            shapeSlot.GetComponent<T8GenerationSlot>().empty = true;
            matSlot.GetComponent<T8GenerationSlot>().empty = true;
            powerSlot.GetComponent<T8GenerationSlot>().empty = true;
            readyToGenerate = false;
        }

        if(shapeId > 0 && materialId > 0 && powerId > 0){
            generateItem();
        }
    }


    void generateItem()
    {
        if(shapeId == 1){
            if(materialId == 1){
                if(powerId == 1){
                    placeableItem.GetComponent<SpriteRenderer>().sprite = T8_item_shape1_material1_power1;
                } else if(powerId == 2){
                    placeableItem.GetComponent<SpriteRenderer>().sprite = T8_item_shape1_material1_power2;
                }else if(powerId == 3){
                    placeableItem.GetComponent<SpriteRenderer>().sprite = T8_item_shape1_material1_power3;
                }
            } else if(materialId == 2){
                if(powerId == 1){
                    placeableItem.GetComponent<SpriteRenderer>().sprite = T8_item_shape1_material2_power1;
                } else if(powerId == 2){
                    placeableItem.GetComponent<SpriteRenderer>().sprite = T8_item_shape1_material2_power2;
                }else if(powerId == 3){
                    placeableItem.GetComponent<SpriteRenderer>().sprite = T8_item_shape1_material2_power3;
                }
            } else if(materialId == 3){
                if(powerId == 1){
                    placeableItem.GetComponent<SpriteRenderer>().sprite = T8_item_shape1_material3_power1;
                } else if(powerId == 2){
                    placeableItem.GetComponent<SpriteRenderer>().sprite = T8_item_shape1_material3_power2;
                }else if(powerId == 3){
                    placeableItem.GetComponent<SpriteRenderer>().sprite = T8_item_shape1_material3_power3;
                }
            }
        } else if(shapeId == 2){
            if(materialId == 1){
                if(powerId == 1){
                    placeableItem.GetComponent<SpriteRenderer>().sprite = T8_item_shape2_material1_power1;
                } else if(powerId == 2){
                    placeableItem.GetComponent<SpriteRenderer>().sprite = T8_item_shape2_material1_power2;
                }else if(powerId == 3){
                    placeableItem.GetComponent<SpriteRenderer>().sprite = T8_item_shape2_material1_power3;
                }
            } else if(materialId == 2){
                if(powerId == 1){
                    placeableItem.GetComponent<SpriteRenderer>().sprite = T8_item_shape2_material2_power1;
                } else if(powerId == 2){
                    placeableItem.GetComponent<SpriteRenderer>().sprite = T8_item_shape2_material2_power2;
                }else if(powerId == 3){
                    placeableItem.GetComponent<SpriteRenderer>().sprite = T8_item_shape2_material2_power3;
                }
            } else if(materialId == 3){
                if(powerId == 1){
                    placeableItem.GetComponent<SpriteRenderer>().sprite = T8_item_shape2_material3_power1;
                } else if(powerId == 2){
                    placeableItem.GetComponent<SpriteRenderer>().sprite = T8_item_shape2_material3_power2;
                }else if(powerId == 3){
                    placeableItem.GetComponent<SpriteRenderer>().sprite = T8_item_shape2_material3_power3;
                }
            }
        } else if(shapeId == 3){
            if(materialId == 1){
                if(powerId == 1){
                    placeableItem.GetComponent<SpriteRenderer>().sprite = T8_item_shape3_material1_power1;
                } else if(powerId == 2){
                    placeableItem.GetComponent<SpriteRenderer>().sprite = T8_item_shape3_material1_power2;
                }else if(powerId == 3){
                    placeableItem.GetComponent<SpriteRenderer>().sprite = T8_item_shape3_material1_power3;
                }
            } else if(materialId == 2){
                if(powerId == 1){
                    placeableItem.GetComponent<SpriteRenderer>().sprite = T8_item_shape3_material2_power1;
                } else if(powerId == 2){
                    placeableItem.GetComponent<SpriteRenderer>().sprite = T8_item_shape3_material2_power2;
                }else if(powerId == 3){
                    placeableItem.GetComponent<SpriteRenderer>().sprite = T8_item_shape3_material2_power3;
                }
            } else if(materialId == 3){
                if(powerId == 1){
                    placeableItem.GetComponent<SpriteRenderer>().sprite = T8_item_shape3_material3_power1;
                } else if(powerId == 2){
                    placeableItem.GetComponent<SpriteRenderer>().sprite = T8_item_shape3_material3_power2;
                }else if(powerId == 3){
                    placeableItem.GetComponent<SpriteRenderer>().sprite = T8_item_shape3_material3_power3;
                }
            }
        }


        GameObject newItem = Instantiate(placeableItem, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -1), Quaternion.identity);
        T8DragableItem dragableItem = newItem.GetComponent<T8DragableItem>();
        dragableItem.defineHolder(gameObject);
        dragableItem.setOrigin(newItem.transform.position);
        dragableItem.shapeType = shapeId;
        dragableItem.materialType = materialId;
        dragableItem.powerType = powerId;
        newItem.name = "PlacedItem";
        

        shapeId = 0;
        materialId = 0;
        powerId = 0;
        readyToGenerate = false;
    }


    public void clearGeneration()
    {
            shapeSlot.GetComponent<T8GenerationSlot>().clearItem();
            matSlot.GetComponent<T8GenerationSlot>().clearItem();
            powerSlot.GetComponent<T8GenerationSlot>().clearItem();
    }

    


}
