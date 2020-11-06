using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEAM7_DestroyOnTouchInnocent1 : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip sound;
    public AudioClip sound2;
    public int scoreValue = 25;
    public bool isAugmented;
    public TEAM7_tempsDeVie tdv;

    void Start()
    {
        tdv = Camera.main.GetComponent<TEAM7_tempsDeVie>();
    }

    void OnMouseDown()
    {
        AudioSource.PlayClipAtPoint(sound, transform.position);
        AudioSource.PlayClipAtPoint(sound2, transform.position);
        isAugmented = false;
        TEAM7_score.instance.ChangeScore(scoreValue, isAugmented);
        tdv.time = tdv.time + 3.0f;
        Destroy(gameObject);
    }
}
