using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TEAM7_mouvement : MonoBehaviour
{
    public static TEAM7_mouvement instance;
    public Text text;
    public int team7_mouvement = 5;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        text.text = "Mouvements restants: 5";
    }

    public void ChangeScore(int mouvValue, bool isDebited)
    {
        if(isDebited == true)
        {
        team7_mouvement += mouvValue;
        }
        if (isDebited == false)
        {
            team7_mouvement -= mouvValue;
        }
        text.text = "Mouvements restants: " + team7_mouvement.ToString();
    }

}
