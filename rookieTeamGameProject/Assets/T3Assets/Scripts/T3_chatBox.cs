using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class T3_chatBox : MonoBehaviour
{

    public int maxMessage;

    public GameObject chatPanel;
    public GameObject textObject;
    public InputField chatBox;
    public GameObject score;
    public GameObject death;

    public GameObject comboX2;
    public GameObject comboX3;
    public GameObject comboX4;
    public GameObject comboPoint;

    public T3_LifeManager life;
    public T3_Bipo bipo;

    public int valeur=10;
    public int valeurBipo = 20;
    public int ValeurSchizo = 50;
    int total ;
    [SerializeField]
    List<Message> messagesList = new List<Message>() ;


    void Awake()
    {
        chatBox.ActivateInputField();
        total = 0;

    }


    void Update()
    {
        score.GetComponent<Text>().text = total.ToString();
        chatBox.ActivateInputField();
        if (chatBox.text != "")
        {
            if(Input.GetKeyDown(KeyCode.Return))
            {
                SendMessageToChat(chatBox.text);
                Kill(chatBox.text);
                chatBox.text = "";
                chatBox.ActivateInputField();
            }
        }

        StartCoroutine(DeathAnimation());
        StartCoroutine(ComboAnimation());
    }

    public void SendMessageToChat(string text)
    {
        if(messagesList.Count>=maxMessage)
        {
            Destroy(messagesList[0].textObject.gameObject);
            messagesList.Remove(messagesList[0]);
        }
        Message newMessage = new Message();

        newMessage.text = text;

        GameObject newText = Instantiate(textObject, chatPanel.transform);
        newMessage.textObject = newText.GetComponent<Text>();
        newMessage.textObject.text = newMessage.text;

        messagesList.Add(newMessage);
    }
    
    private void Kill(string emotName)
    {

        List<GameObject> listEmot = new List<GameObject>();
        int combo = 0;

        foreach(GameObject go in Resources.FindObjectsOfTypeAll(typeof(GameObject))as GameObject[])
        {
            listEmot.Add(go);
        }

        foreach(GameObject element in listEmot)
        {
                                        /*Basique emot*/
            //Sourire
            if (emotName == ":)" && (element.name == "Smile(Clone)" || element.name =="BipoSmile(Clone)" || element.name == "Schizo_Smile(Clone)"))
            {
                if (element.name == "BipoSmile(Clone)")
                {
                    bipo.BipoKill(element);
                    total += valeurBipo;
                }
                else
                {
                    if (element.name == "Schizo_Smile(Clone)")
                    {
                        total += ValeurSchizo;
                    }
                    else
                    {
                        combo++;
                    }
                    Instantiate(death, element.transform.position, Quaternion.identity);
                    T3_SoundController.Instance.MakeSmileyDeathSound();
                    Destroy(element);
                }
            }
            //Clin d'oeil
            if (emotName == ";)" && (element.name == "Wink(Clone)" || element.name == "BipoWink(Clone)" || element.name == "Schizo_Wink(Clone)"))
            {
                if (element.name == "BipoWink(Clone)")
                {
                    bipo.BipoKill(element);
                    total += valeurBipo;
                }
                else
                {
                    if (element.name == "Schizo_Wink(Clone)")
                    {
                        total += ValeurSchizo;
                    }
                    else
                    {
                        combo++;
                    }
                    Destroy(element);
                    T3_SoundController.Instance.MakeSmileyDeathSound();
                    Instantiate(death, element.transform.position, Quaternion.identity);
                    
                }

            }
            //Rire
            if (emotName == ":')" && (element.name == "Laugh(Clone)" || element.name == "BipoLaugh(Clone)" || element.name == "Schizo_Laugh(Clone)"))
            {
                if (element.name == "BipoLaugh(Clone)")
                {
                    bipo.BipoKill(element);
                    total += valeurBipo;
                }
                else
                {
                    if (element.name == "Schizo_Laugh(Clone)")
                    {
                        total += ValeurSchizo;
                    }
                    else
                    {
                        combo++;
                    }
                    Instantiate(death, element.transform.position, Quaternion.identity);
                    T3_SoundController.Instance.MakeSmileyDeathSound();
                    Destroy(element);
                }
            }
            //Etonné
            if ((emotName == ":O" || emotName == ":o") && (element.name == "Shocked(Clone)" || element.name == "BipoShocked(Clone)" || element.name == "Schizo_Shocked(Clone)"))
            {
                if (element.name == "BipoShocked(Clone)")
                {
                    bipo.BipoKill(element);
                    total += valeurBipo;
                }
                else
                {
                    if (element.name == "Schizo_Shocked(Clone)")
                    {
                        total += ValeurSchizo;
                    }
                    else
                    {
                        combo++;
                    }
                    Instantiate(death, element.transform.position, Quaternion.identity);
                    T3_SoundController.Instance.MakeSmileyDeathSound();
                    Destroy(element);
                }
            }
            //Pleure
            if (emotName == ":'(" && (element.name == "Cry(Clone)" || element.name == "BipoCry(Clone)" || element.name == "Schizo_Cry(Clone)"))
            {
                if (element.name == "BipoCry(Clone)")
                {
                    bipo.BipoKill(element);
                    total += valeurBipo;
                }
                else
                {
                    if (element.name == "Schizo_Cry(Clone)")
                    {
                        total += ValeurSchizo;
                    }
                    else
                    {
                        combo++;
                    }
                    Instantiate(death, element.transform.position, Quaternion.identity);
                    T3_SoundController.Instance.MakeSmileyDeathSound();
                    Destroy(element);
                }
            }
            //Pas content
            if (emotName == ":(" && (element.name == "Mad(Clone)" || element.name == "BipoMad(Clone)" || element.name == "Schizo_Mad(Clone)"))
            {
                if (element.name == "BipoMad(Clone)")
                {
                    bipo.BipoKill(element);
                    total += valeurBipo;
                }
                else
                {
                    if (element.name == "Schizo_Mad(Clone)")
                    {
                        total += ValeurSchizo;
                    }
                    else
                    {
                        combo++;
                    }
                    Instantiate(death, element.transform.position, Quaternion.identity);
                    T3_SoundController.Instance.MakeSmileyDeathSound();
                    Destroy(element);
                }
            }

            /*Advanced emot*/
            //Blasé
            if (emotName == "-_-" && (element.name == "Blaze(Clone)" || element.name == "Schizo_Blaze(Clone)"))
            {
                if (element.name == "BipoBlaze(Clone)")
                {
                    bipo.BipoKill(element);
                    total += valeurBipo;
                }
                else
                {
                    if (element.name == "Schizo_Blaze(Clone)")
                    {
                        total += ValeurSchizo;
                    }
                    else
                    {
                        combo++;
                    }
                    Instantiate(death, element.transform.position, Quaternion.identity);
                    T3_SoundController.Instance.MakeSmileyDeathSound();
                    Destroy(element);
                }
            }

            //Malice
            if (emotName == "^^" && (element.name == "Malice(Clone)" || element.name == "BipoMalice(Clone)" || element.name == "Schizo_Malice(Clone)"))
            {
                if (element.name == "BipoMalice(Clone)")
                {
                    bipo.BipoKill(element);
                    total += valeurBipo;
                }
                else
                {
                    if (element.name == "Schizo_Malice(Clone)")
                    {
                        total += ValeurSchizo;
                    }
                    else
                    {
                        combo++;
                    }
                    Instantiate(death, element.transform.position, Quaternion.identity);
                    T3_SoundController.Instance.MakeSmileyDeathSound();
                    Destroy(element);
                }
            }
            //Love
            if (emotName == "*o*" && (element.name == "Love(Clone)" || element.name == "BipoLove(Clone)" || element.name == "Shizo_Love(Clone)"))
            {
                if (element.name == "BipoLove(Clone)")
                {
                    bipo.BipoKill(element);
                    total += valeurBipo;
                }
                else
                {
                    if (element.name == "Shizo_Love(Clone)")
                    {
                        total += ValeurSchizo;
                    }
                    else
                    {
                        combo++;
                    }
                    Instantiate(death, element.transform.position, Quaternion.identity);
                    T3_SoundController.Instance.MakeSmileyDeathSound();
                    Destroy(element);
                }
            }
            /*Spéciaux*/
            //Coeur
            if ((emotName=="<3")&&element.name == "Coeur(Clone)")
            {
                life.RestoreLife(1);
                Destroy(element);
            }
            //Bombe
            if ((emotName == "tnt" || emotName == "TNT") && element.name == "TNT(Clone)")
            {
                foreach (GameObject bomb in listEmot)
                {
                    if (bomb.name == "TNT(Clone)" || bomb.name == "Smile(Clone)" || bomb.name == "Wink(Clone)" || bomb.name == "Laugh(Clone)" || bomb.name == "Shocked(Clone)" || bomb.name == "Cry(Clone)" || bomb.name == "Mad(Clone)" || bomb.name == "Coeur(Clone)" || bomb.name == "Blaze(Clone)" || bomb.name == "Malice(Clone)" || bomb.name == "Love(Clone)")
                    {
                        Destroy(bomb);
                        T3_SoundController.Instance.MakeTNTSound();
                    }
                }
            }


        }

            if (combo == 2)
        {
            Instantiate(comboX2, comboPoint.transform.position, Quaternion.identity);
            T3_SoundController.Instance.MakeComboSound();
        }
        
        if(combo == 3)
        {
            Instantiate(comboX3, comboPoint.transform.position, Quaternion.identity);
            T3_SoundController.Instance.MakeComboSound();
        }
        
        if(combo >= 4)
        {
            Instantiate(comboX4, comboPoint.transform.position, Quaternion.identity);
            T3_SoundController.Instance.MakeComboSound();
        }
        total += (valeur*combo)*combo;
        score.GetComponent<Text>().text = total.ToString();
    }

    IEnumerator DeathAnimation()
    {
        WaitForSeconds wait = new WaitForSeconds(1);
        GameObject deathAnimation;
        deathAnimation = GameObject.Find("DeathAnimation(Clone)");
        yield return wait;
        Destroy(deathAnimation);
    }
    
    IEnumerator ComboAnimation()
    {
        WaitForSeconds wait = new WaitForSeconds(4);
        GameObject combo;
        combo = GameObject.FindGameObjectWithTag("ComboT3");
        yield return wait;
        Destroy(combo);
    }
}




[System.Serializable]
public class Message
{
    public string text;
    public Text textObject;
}


