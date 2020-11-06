using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoringTeamVague : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioManagerTeamVague audioo;
    public TextMeshProUGUI text;
    void Start()
    {
        audioo =GameObject.Find("SoundManagerTeamVague").GetComponent<AudioManagerTeamVague>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Score: " + audioo.Score.ToString();
    }
}
