using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEAM7_DestroyOnTouchFauxCoupable : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip sound;
    public AudioClip sound2;
    public int scoreValue = 25;
    public bool isDebited;
    public bool isAugmented;
    public int mouvValue = 1;
    public TEAM7_tempsDeVie tdv;

    void Start()
    {
        tdv = Camera.main.GetComponent<TEAM7_tempsDeVie>();
    }

    void OnMouseDown()
    {
        AudioSource.PlayClipAtPoint(sound, transform.position);
        AudioSource.PlayClipAtPoint(sound2, transform.position);
        isDebited = false;
        isAugmented = false;
        TEAM7_score.instance.ChangeScore(scoreValue, isAugmented); 
        TEAM7_mouvement.instance.ChangeScore(mouvValue, isDebited);
        tdv.time = tdv.time - 2.0f;
        Destroy(gameObject);
    }
}
