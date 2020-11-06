using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DecomptTeamVague : MonoBehaviour
{
    // Start is called before the first frame update
    public float decompt;
    public int last;
    public TextMeshProUGUI text;
    public GameObject pan;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        decompt -= Time.deltaTime;
        if(last>decompt)
        {
            last -= 1;
            text.text = "";
        }

        if(last<=0)
        {
            pan.SetActive(false);
          
        }
    }
}
