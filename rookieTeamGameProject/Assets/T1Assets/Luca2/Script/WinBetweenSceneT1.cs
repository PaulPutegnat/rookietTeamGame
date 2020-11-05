using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinBetweenSceneT1 : MonoBehaviour
{
    public GameObject win1;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void winner(){
        win1.SetActive(true);
    }
    public void return2(){
        win1.SetActive(false);
    }
}
