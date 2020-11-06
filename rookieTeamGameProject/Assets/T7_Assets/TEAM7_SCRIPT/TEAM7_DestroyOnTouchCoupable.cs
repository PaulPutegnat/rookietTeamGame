using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class TEAM7_DestroyOnTouchCoupable : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip sound;
    public AudioClip sound2;
    public int scoreValue = 50;
    public bool isDebited;
    public bool isAugmented;
    public int mouvValue = 1;
    public float time = 0.5f;
    public TEAM7_tempsDeVie tdv;

    void Start()
    {
        tdv = Camera.main.GetComponent<TEAM7_tempsDeVie>();
    }

    void OnMouseDown()
    {
        AudioSource.PlayClipAtPoint(sound, transform.position);
        AudioSource.PlayClipAtPoint(sound2, transform.position);
        isDebited = true;
        isAugmented = true;
        TEAM7_score.instance.ChangeScore(scoreValue, isAugmented);
        TEAM7_mouvement.instance.ChangeScore(mouvValue, isDebited);
        tdv.timeBar.maxValue -= time;
        tdv.timeBar.maxValue = Mathf.Clamp(tdv.timeBar.maxValue, 2,15);
        tdv.time = tdv.timeBar.maxValue;
        Destroy(gameObject);
    }
}
