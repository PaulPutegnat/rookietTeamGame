using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFinT1 : MonoBehaviour
{
    void Start()
    {
        
    }

    public void goLanceLeJeu(){
        SceneManager.LoadScene("T1Menu", LoadSceneMode.Single);
    }
}
