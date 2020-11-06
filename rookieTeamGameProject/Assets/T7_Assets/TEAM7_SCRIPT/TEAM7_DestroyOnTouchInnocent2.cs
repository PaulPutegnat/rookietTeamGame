using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEAM7_DestroyOnTouchInnocent2 : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip sound;
    public AudioClip sound2;
    public int scoreValue = 25;
    public bool isDebited;
    public bool isAugmented;
    public int mouvValue = 1;

    void OnMouseDown()
    {
        AudioSource.PlayClipAtPoint(sound, transform.position);
        AudioSource.PlayClipAtPoint(sound2, transform.position);
        isDebited = true;
        isAugmented = false;
        TEAM7_score.instance.ChangeScore(scoreValue, isAugmented);
        TEAM7_mouvement.instance.ChangeScore(mouvValue, isDebited);
        Destroy(gameObject);
    }
}
