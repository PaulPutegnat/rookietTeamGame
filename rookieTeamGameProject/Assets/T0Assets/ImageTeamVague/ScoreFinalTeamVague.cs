using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreFinalTeamVague : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Audioo;
    public TextMeshProUGUI text;
    void Start()
    {
        Audioo = GameObject.Find("SoundManagerTeamVague");
    }

    // Update is called once per frame
    void Update()
    {
        if(Audioo!=null)
        {

        text.text = "Votre Score: " + Audioo.GetComponent<AudioManagerTeamVague>().Score.ToString();
        }
    }
}
