﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class T1MenuPrincipale : MonoBehaviour {
    public void lancerJeu()
    {
        SceneManager.LoadScene("RouletteTimeT1", LoadSceneMode.Single);
    }

    public void quitterJeu()
    {
        Debug.Log("QUITTER");
        SceneManager.LoadScene("SalleArcade", LoadSceneMode.Single);
    }

    public void controle(){
        FindObjectOfType<AudioManagerT1>().Play("Menu");
    }

}
