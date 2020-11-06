using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T2DifficultyManagement : MonoBehaviour
{
    [Header("Difficulty")]
    [SerializeField] private float tempsPhase12;
    [SerializeField] private float tempsPhase23;
    [SerializeField] private float tempsPhase34;
    [SerializeField] private float vitesseEmojisPhase1;
    [SerializeField] private float vitesseEmojisPhase2;
    [SerializeField] private float vitesseEmojisPhase3;
    [SerializeField] private float vitesseEmojisPhase4;
    public float currentspeed;
    [SerializeField] private float vitesseApparition1;
    [SerializeField] private float vitesseApparition2;
    [SerializeField] private float vitesseApparition3;
    [SerializeField] private float vitesseApparition4;
    public float temps;
    public int phase = 1;
    public bool PhaseActive = false;
    public bool ButtonIsPressed= false;
    public float MultiplicateurSpeed =1;
    public float MultiplicateurApparition =1;


    /*public AudioSource Spitfire;
    public AudioSource Ascenseur;*/

    // Start is called before the first frame update
    // Update is called once per frame
    private void Start()
    {
        /*Spitfire = GetComponent<AudioSource>();
        Ascenseur = GetComponent<AudioSource>();*/

        currentspeed = vitesseEmojisPhase1 * MultiplicateurSpeed;
        gameObject.GetComponent<T2EnnemyGenerator1>().IntervalleEntre2 = vitesseApparition1;
        temps = tempsPhase12;
        phase = 1;
        /*Spitfire.Stop();
        Ascenseur.Play();*/
    }

    /*public void ChangementMusic(bool changement, bool APlay)
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
    }*/


    void Update()
    {
        if(ButtonIsPressed == true)
        {
            Destroy(GameObject.Find("ButtonHolder").transform.GetChild(0).gameObject);
            Destroy(GameObject.Find("ButtonHolder").transform.GetChild(1).gameObject);
            Destroy(GameObject.Find("ButtonHolder").transform.GetChild(2).gameObject);
            ButtonIsPressed = false;
            /*Ascenseur.Stop();
            Spitfire.Play();*/
        }
        if(temps > 0 && PhaseActive)
        {
            
            temps -= Time.deltaTime;
        }
        else if(PhaseActive && phase <4)
        {
            
            phase++;
            switch (phase)
            {
                case 1:
                    currentspeed = vitesseEmojisPhase1 * MultiplicateurSpeed;
                    gameObject.GetComponent<T2EnnemyGenerator1>().IntervalleEntre2 = vitesseApparition1 * MultiplicateurApparition;
                    temps = 15f;
                    break;
                case 2:
                    currentspeed = vitesseEmojisPhase2 * MultiplicateurSpeed;
                    gameObject.GetComponent<T2EnnemyGenerator1>().IntervalleEntre2 = vitesseApparition2 * MultiplicateurApparition;
                    temps = tempsPhase23;
                    break;
                case 3:
                    currentspeed = vitesseEmojisPhase3 * MultiplicateurSpeed;
                    gameObject.GetComponent<T2EnnemyGenerator1>().IntervalleEntre2 = vitesseApparition3 * MultiplicateurApparition;
                    temps = tempsPhase34;
                    break;
                case 4:
                    currentspeed = vitesseEmojisPhase4 * MultiplicateurSpeed;
                    gameObject.GetComponent<T2EnnemyGenerator1>().IntervalleEntre2 = vitesseApparition4 * MultiplicateurApparition;
                    break;
            }
            
        }
        
    }
}
