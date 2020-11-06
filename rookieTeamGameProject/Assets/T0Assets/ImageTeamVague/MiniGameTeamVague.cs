using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MiniGameTeamVague : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI touche1;
    public TextMeshProUGUI touche2;
    public ControlToucheTeamVague Control;
    public List<KeyCode> listtouche;
    public int set;
    public GameObject GameManage;
    public float TimeMiniGame;
    public GameObject pref;
    public Sprite sprite;
    public int scoring;
  
    public AudioManagerTeamVague audioo;
    void Start()
    {
        audioo = GameObject.Find("SoundManagerTeamVague").GetComponent<AudioManagerTeamVague>();
    }

    // Update is called once per frame
    void Update()
    {
        TimeMiniGame -= Time.deltaTime;
        if(TimeMiniGame<=0)
        {
            GameManage.GetComponent<GameManagerGlobalTeamVague>().ObsoToMini();
            if(scoring!=0)
            {
                audioo.Score += scoring;
            }
            Destroy(gameObject);
        }
    }


    public void AfficheAndSetTouche()
    {
        set=Random.Range(0, listtouche.Count / 2);
        touche1.text = listtouche[set].ToString();
        touche2.text = listtouche[set + listtouche.Count / 2].ToString();
        Control.up = listtouche[set];
        Control.down = listtouche[set+listtouche.Count/2];
    }
}
