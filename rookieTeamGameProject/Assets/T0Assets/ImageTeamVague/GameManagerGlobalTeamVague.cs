using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManagerGlobalTeamVague : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> minigames;
    [HideInInspector]
    public List<GameObject> minigamesobso;
    public bool acti;
    public int NombreDeMiniGames;
    [HideInInspector]
    public  int nbr;
    [HideInInspector]
    public float counter;
    public float CounterBetween;
    public float CounterFinManche;
    public string NextManche;
    public List<Transform> listTransform;
    [HideInInspector]
    public List<Transform> listTransformObso;
    
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      if(counter<=0 && minigames.Count!=0 && acti==false && listTransform.Count!=0 & NombreDeMiniGames!=0)
      {
       nbr=Random.Range(0, minigames.Count);
       ActiveMiniGame(minigames[nbr],listTransform[0]);
       minigamesobso.Add(minigames[nbr]);
            listTransform[0].GetComponent<TransformLinkBackTeamVague>().Applique(minigames[nbr].GetComponent<MiniGameTeamVague>().sprite);
            NombreDeMiniGames -= 1;
       minigames.Remove(minigames[nbr]);
       listTransformObso.Add(listTransform[0]);
      listTransform.Remove(listTransform[0]);
      counter = CounterBetween;
      }
      if(CounterFinManche<=0)
        {
            Nextlevel(NextManche);
        }
        counter -= Time.deltaTime;
        if(NombreDeMiniGames<=0)
        {
            CounterFinManche -= Time.deltaTime;
        }
    }

    void Nextlevel(string manche)
    {
        SceneManager.LoadScene(manche);
    }
    void ActiveMiniGame(GameObject game,Transform list)
    {
        GameObject mini = Instantiate(game, list.position, transform.rotation);
        mini.GetComponent<MiniGameTeamVague>().GameManage = this.gameObject;
        mini.GetComponent<MiniGameTeamVague>().AfficheAndSetTouche();
    }

    public void ObsoToMini()
    {
        minigames.Add(minigamesobso[0]);
        minigamesobso.Remove(minigamesobso[0]);
        listTransform.Add(listTransformObso[0]);
        listTransformObso[0].GetComponent<TransformLinkBackTeamVague>().Remove();
        listTransformObso.Remove(listTransformObso[0]);
    }
}
