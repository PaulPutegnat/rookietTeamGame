using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T2Audio : MonoBehaviour
{
    public AudioSource Spitfire;
    public AudioSource Ascenseur;

    void Start()
    {
        Spitfire = GetComponent<AudioSource>(); 
        Ascenseur = GetComponent<AudioSource>();
    }

    public void ChangementMusic(bool changement, bool APlay)
    {
        if (APlay == true && changement == true)
        {
            Ascenseur.Stop();
            Spitfire.Play();
            APlay = false;
        }

        if (APlay == false && changement == true)
        {
            Spitfire.Stop();
            Ascenseur.Play();
            APlay = true;
        }
    }

    void Update()
    {
        
    }

}
