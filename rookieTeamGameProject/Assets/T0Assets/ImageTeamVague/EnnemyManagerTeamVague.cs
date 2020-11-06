using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyManagerTeamVague : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> ennemy;
    public phase state;
    public int rdm;
    public Transform pos;
    void Start()
    {
        
        state = phase.Active;
    }

    // Update is called once per frame
    void Update()
    {
        if(state==phase.Active)
        {
            rdm = Random.Range(0,3);
            ennemy[rdm].SetActive(false);
            Debug.Log(rdm);
            state = phase.Moving;
        }else if(state==phase.Moving)
        { 
            for(int i=0;i<ennemy.Count;i++)
            {
                ennemy[i].GetComponent<MovingEnnemyTeamVague>().Moving();
            }
        }else if(state==phase.Replace)
        {
            for (int j = 0; j < ennemy.Count; j++)
            {
                ennemy[j].transform.position = new Vector3(pos.position.x, ennemy[j].transform.position.y, ennemy[j].transform.position.z);
                ennemy[j].SetActive(true);
            }
            state = phase.Active;
        }
    }

    public enum phase
    {
        Active,
        Moving,
        Replace,
    }
}
