using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class T3_FirstSlotMachine : MonoBehaviour
{
    public Sprite[] sprites;

    public Sprite RandomizeSprite()
    {
        gameObject.GetComponent<UnityEngine.UI.Image>().sprite = sprites[Random.Range(0, sprites.Length)];
        return gameObject.GetComponent<UnityEngine.UI.Image>().sprite;
    }
}
