using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class score_ManagerT1 : MonoBehaviour
{
    public int Score = 0;
    
    public TextMeshProUGUI textScore;

    private void Update() 
    {
        textScore.text = "Score : " + Score.ToString();

    }

}
