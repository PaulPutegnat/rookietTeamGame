using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T3_ThirdSlotMachine : MonoBehaviour
{
    public Sprite[] sprites;

    public Sprite RandomizeSprite()
    {
        gameObject.GetComponent<UnityEngine.UI.Image>().sprite = sprites[Random.Range(0, sprites.Length)];
        return gameObject.GetComponent<UnityEngine.UI.Image>().sprite;
    }


}
