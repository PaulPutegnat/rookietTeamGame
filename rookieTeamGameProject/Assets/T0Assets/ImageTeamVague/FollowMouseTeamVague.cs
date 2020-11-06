using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouseTeamVague : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 pos;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pos = Input.mousePosition;
       
        transform.position = Camera.main.ScreenToWorldPoint(pos);
    }

   
}
