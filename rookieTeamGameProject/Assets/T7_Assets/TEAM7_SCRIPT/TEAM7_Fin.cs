using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TEAM7_Fin : MonoBehaviour
{
    public GameObject menuFin;
    public GameObject menuStart;
    public GameObject menuTuto;
    public TEAM7_tempsDeVie tdv;
    public TEAM7_score scoring;
    public TEAM7_mouvement mmv;

    void Start()
    {
        tdv = Camera.main.GetComponent<TEAM7_tempsDeVie>();
        menuFin.SetActive(false);
        menuTuto.SetActive(true);
        menuStart.SetActive(true);
        Time.timeScale = 0f;

    }

    // Update is called once per frame
    void Update()
    {
        if (mmv.team7_mouvement <= 0)
        {
            mmv.team7_mouvement = 0;
        }

        if (scoring.team7_score <= 0)
        {
            scoring.team7_score = 0;
        }

        if (scoring.team7_score == 0 || mmv.team7_mouvement == 0 || tdv.time <= 0)
        {
            stopHammerTime();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menuTuto.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void stopHammerTime()
    {
        if (!menuFin.activeSelf)
        {
            menuFin.SetActive(true);
            menuStart.SetActive(false);
        }
    }

}