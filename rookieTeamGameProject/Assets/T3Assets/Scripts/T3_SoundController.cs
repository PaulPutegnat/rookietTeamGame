using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T3_SoundController : MonoBehaviour
{

    public static T3_SoundController Instance;

    public AudioClip combo;
    public AudioClip smileyDeath;
    public AudioClip takeDamage;
    public AudioClip restoreLife;
    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Multiple instances of SoundEffectsHelper!");
        }
        Instance = this;
    }

    public void MakeComboSound()
    {
        MakeSound(combo);
    }
    
    public void MakeSmileyDeathSound()
    {
        MakeSound(smileyDeath);
    }
    
    public void MakeTakeDamageSound()
    {
        MakeSound(takeDamage);
    }
    
    public void MakeRestoreLifeSound()
    {
        MakeSound(restoreLife);
    }

    private void MakeSound(AudioClip originalClip)
    {
        AudioSource.PlayClipAtPoint(originalClip, transform.position);
    }
}
