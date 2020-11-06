using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TEAM7_tempsDeVie : MonoBehaviour
{
    public Slider timeBar;
    public float time = 15.0f;
    
    private bool actif = true;

    void Update()
    {
        okay();
    }

    public void okay()
    {
        //timeBar.maxValue = 15.0f;
        timeBar.value = time;
        
        if (actif == true)
        {
            StartCoroutine(tempsLess());
        }
    }

    public IEnumerator tempsLess()
    {
        actif = false;
        time -= 0.05f;
        yield return new WaitForSeconds(0.05f);
        actif = true;
    }
}
