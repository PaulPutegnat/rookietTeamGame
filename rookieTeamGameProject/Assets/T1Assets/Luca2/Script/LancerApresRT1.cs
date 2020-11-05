using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LancerApresRT1 : MonoBehaviour
{
    public T1ItemUiHandle truc1;
    public T1ItemUiHandle truc2;

    public GameObject button;
    void Start()
    {
        
    }

    void Update()
    {
        if(truc1.done){
            if(truc2.done){
                if(truc1.id == truc2.id){
                    SceneManager.LoadScene("RouletteTimeT1", LoadSceneMode.Single);
                }else{
                    button.SetActive(true);
                }
            }
        }
    }

    public void goLanceLeJeu(){
        SceneManager.LoadScene("SceneTestT1", LoadSceneMode.Single);
    }
}
