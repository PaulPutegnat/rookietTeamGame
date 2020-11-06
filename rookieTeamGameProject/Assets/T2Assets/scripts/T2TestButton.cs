using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class T2TestButton : MonoBehaviour
{
    [Header("Bouttons Existants")]
    [SerializeField] Button Theme1_Good1;
    [SerializeField] Button Theme1_Good2;
    [SerializeField] Button Theme1_Neutral1;
    [SerializeField] Button Theme1_Neutral2;
    [SerializeField] Button Theme1_Bad1;
    [SerializeField] Button Theme1_Bad2;
    [SerializeField] Button Theme2_Good1;
    [SerializeField] Button Theme2_Good2;
    [SerializeField] Button Theme2_Neutral1;
    [SerializeField] Button Theme2_Neutral2;
    [SerializeField] Button Theme2_Bad1;
    [SerializeField] Button Theme2_Bad2;
    [SerializeField] Button Theme3_Good1;
    [SerializeField] Button Theme3_Good2;
    [SerializeField] Button Theme3_Neutral1;
    [SerializeField] Button Theme3_Neutral2;
    [SerializeField] Button Theme3_Bad1;
    [SerializeField] Button Theme3_Bad2;


    [Header("Le reste")]
    [SerializeField] Button Boutton;
    [SerializeField] Button Boutton2;
    [SerializeField] Button Boutton3;
    [SerializeField] GameObject SpawnPoint;
    [SerializeField] GameObject SpawnPoint2;
    [SerializeField] GameObject SpawnPoint3;
    public GameObject ButtonHolder;
    public int rand;
    public int manche = 1;
    public bool InitialisationButton = true;

    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            rand = Random.Range(1, 3);
            switch (i)
            {
                case 0:
                    if (rand == 1)
                    {
                        Boutton = Theme1_Good1;
                    }
                    else
                    {
                        Boutton = Theme1_Good2;
                    }
                    break;

                case 1:
                    if (rand == 1)
                    {
                        Boutton2 = Theme1_Neutral1;
                    }
                    else
                    {
                        Boutton2 = Theme1_Neutral2;
                    }
                    break;

                case 2:
                    if (rand == 1)
                    {
                        Boutton3 = Theme1_Bad1;
                    }
                    else
                    {
                        Boutton3 = Theme1_Bad2;

                    }
                    break;
            }
        }

        rand = Random.Range(1, 4);
        switch (rand)
        {

            case 1:
                Instantiate(Boutton, SpawnPoint.transform.position, Quaternion.identity);
                GameObject.FindObjectOfType<Button>().transform.parent = ButtonHolder.transform;
                rand = Random.Range(2, 4);
                if (rand == 2)
                {
                    Instantiate(Boutton2, SpawnPoint2.transform.position, Quaternion.identity);
                    GameObject.FindObjectOfType<Button>().transform.parent = ButtonHolder.transform;
                    Instantiate(Boutton3, SpawnPoint3.transform.position, Quaternion.identity);
                    GameObject.FindObjectOfType<Button>().transform.parent = ButtonHolder.transform;
                }
                else
                {
                    Instantiate(Boutton2, SpawnPoint3.transform.position, Quaternion.identity);
                    GameObject.FindObjectOfType<Button>().transform.parent = ButtonHolder.transform;
                    Instantiate(Boutton3, SpawnPoint2.transform.position, Quaternion.identity);
                    GameObject.FindObjectOfType<Button>().transform.parent = ButtonHolder.transform;
                }

                break;
            case 2:
                Instantiate(Boutton, SpawnPoint2.transform.position, Quaternion.identity);
                GameObject.FindObjectOfType<Button>().transform.parent = ButtonHolder.transform;
                rand = Random.Range(2, 4);
                if (rand == 2)
                {
                    Instantiate(Boutton2, SpawnPoint.transform.position, Quaternion.identity);
                    GameObject.FindObjectOfType<Button>().transform.parent = ButtonHolder.transform;
                    Instantiate(Boutton3, SpawnPoint3.transform.position, Quaternion.identity);
                    GameObject.FindObjectOfType<Button>().transform.parent = ButtonHolder.transform;
                }
                else
                {
                    Instantiate(Boutton2, SpawnPoint3.transform.position, Quaternion.identity);
                    GameObject.FindObjectOfType<Button>().transform.parent = ButtonHolder.transform;
                    Instantiate(Boutton3, SpawnPoint.transform.position, Quaternion.identity);
                    GameObject.FindObjectOfType<Button>().transform.parent = ButtonHolder.transform;
                }

                break;
            case 3:
                Instantiate(Boutton, SpawnPoint3.transform.position, Quaternion.identity);
                GameObject.FindObjectOfType<Button>().transform.parent = ButtonHolder.transform; rand = Random.Range(2, 4);
                if (rand == 2)
                {
                    Instantiate(Boutton2, SpawnPoint2.transform.position, Quaternion.identity);
                    GameObject.FindObjectOfType<Button>().transform.parent = ButtonHolder.transform;
                    Instantiate(Boutton3, SpawnPoint.transform.position, Quaternion.identity);
                    GameObject.FindObjectOfType<Button>().transform.parent = ButtonHolder.transform;
                }
                else
                {
                    Instantiate(Boutton2, SpawnPoint.transform.position, Quaternion.identity);
                    GameObject.FindObjectOfType<Button>().transform.parent = ButtonHolder.transform;
                    Instantiate(Boutton3, SpawnPoint2.transform.position, Quaternion.identity);
                    GameObject.FindObjectOfType<Button>().transform.parent = ButtonHolder.transform;
                }
                break;
                
        }
        InitialisationButton = true;
        manche ++;
    }
    private void Update()
    {
        if (InitialisationButton == false && manche == 2)
        {
            for (int i = 0; i < 3; i++)
            {
                rand = Random.Range(1, 3);
                switch (i)
                {
                    case 0:
                        if (rand == 1)
                        {
                            Boutton = Theme2_Good1;
                        }
                        else
                        {
                            Boutton = Theme2_Good2;
                        }
                        break;

                    case 1:
                        if (rand == 1)
                        {
                            Boutton2 = Theme2_Neutral1;
                        }
                        else
                        {
                            Boutton2 = Theme2_Neutral2;
                        }
                        break;

                    case 2:
                        if (rand == 1)
                        {
                            Boutton3 = Theme2_Bad1;
                        }
                        else
                        {
                            Boutton3 = Theme2_Bad2;

                        }
                        break;
                }
            }

            rand = Random.Range(1, 4);
            switch (rand)
            {

                case 1:
                    Instantiate(Boutton, SpawnPoint.transform.position, Quaternion.identity);
                    GameObject.FindObjectOfType<Button>().transform.parent = ButtonHolder.transform;
                    rand = Random.Range(2, 4);
                    if (rand == 2)
                    {
                        Instantiate(Boutton2, SpawnPoint2.transform.position, Quaternion.identity);
                        GameObject.FindObjectOfType<Button>().transform.parent = ButtonHolder.transform;
                        Instantiate(Boutton3, SpawnPoint3.transform.position, Quaternion.identity);
                        GameObject.FindObjectOfType<Button>().transform.parent = ButtonHolder.transform;
                    }
                    else
                    {
                        Instantiate(Boutton2, SpawnPoint3.transform.position, Quaternion.identity);
                        GameObject.FindObjectOfType<Button>().transform.parent = ButtonHolder.transform;
                        Instantiate(Boutton3, SpawnPoint2.transform.position, Quaternion.identity);
                        GameObject.FindObjectOfType<Button>().transform.parent = ButtonHolder.transform;
                    }

                    break;
                case 2:
                    Instantiate(Boutton, SpawnPoint2.transform.position, Quaternion.identity);
                    GameObject.FindObjectOfType<Button>().transform.parent = ButtonHolder.transform;
                    rand = Random.Range(2, 4);
                    if (rand == 2)
                    {
                        Instantiate(Boutton2, SpawnPoint.transform.position, Quaternion.identity);
                        GameObject.FindObjectOfType<Button>().transform.parent = ButtonHolder.transform;
                        Instantiate(Boutton3, SpawnPoint3.transform.position, Quaternion.identity);
                        GameObject.FindObjectOfType<Button>().transform.parent = ButtonHolder.transform;
                    }
                    else
                    {
                        Instantiate(Boutton2, SpawnPoint3.transform.position, Quaternion.identity);
                        GameObject.FindObjectOfType<Button>().transform.parent = ButtonHolder.transform;
                        Instantiate(Boutton3, SpawnPoint.transform.position, Quaternion.identity);
                        GameObject.FindObjectOfType<Button>().transform.parent = ButtonHolder.transform;
                    }

                    break;
                case 3:
                    Instantiate(Boutton, SpawnPoint3.transform.position, Quaternion.identity);
                    GameObject.FindObjectOfType<Button>().transform.parent = ButtonHolder.transform; rand = Random.Range(2, 4);
                    if (rand == 2)
                    {
                        Instantiate(Boutton2, SpawnPoint2.transform.position, Quaternion.identity);
                        GameObject.FindObjectOfType<Button>().transform.parent = ButtonHolder.transform;
                        Instantiate(Boutton3, SpawnPoint.transform.position, Quaternion.identity);
                        GameObject.FindObjectOfType<Button>().transform.parent = ButtonHolder.transform;
                    }
                    else
                    {
                        Instantiate(Boutton2, SpawnPoint.transform.position, Quaternion.identity);
                        GameObject.FindObjectOfType<Button>().transform.parent = ButtonHolder.transform;
                        Instantiate(Boutton3, SpawnPoint2.transform.position, Quaternion.identity);
                        GameObject.FindObjectOfType<Button>().transform.parent = ButtonHolder.transform;
                    }
                    break;
            }
            InitialisationButton = true;
            manche++;
        }
        if (InitialisationButton == false && manche == 3)
        {
            for (int i = 0; i < 3; i++)
            {
                rand = Random.Range(1, 3);
                switch (i)
                {
                    case 0:
                        if (rand == 1)
                        {
                            Boutton = Theme3_Good1;
                        }
                        else
                        {
                            Boutton = Theme3_Good2;
                        }
                        break;

                    case 1:
                        if (rand == 1)
                        {
                            Boutton2 = Theme3_Neutral1;
                        }
                        else
                        {
                            Boutton2 = Theme3_Neutral2;
                        }
                        break;

                    case 2:
                        if (rand == 1)
                        {
                            Boutton3 = Theme3_Bad1;
                        }
                        else
                        {
                            Boutton3 = Theme3_Bad2;

                        }
                        break;
                }
            }

            rand = Random.Range(1, 4);
            switch (rand)
            {

                case 1:
                    Instantiate(Boutton, SpawnPoint.transform.position, Quaternion.identity);
                    GameObject.FindObjectOfType<Button>().transform.parent = ButtonHolder.transform;
                    rand = Random.Range(2, 4);
                    if (rand == 2)
                    {
                        Instantiate(Boutton2, SpawnPoint2.transform.position, Quaternion.identity);
                        GameObject.FindObjectOfType<Button>().transform.parent = ButtonHolder.transform;
                        Instantiate(Boutton3, SpawnPoint3.transform.position, Quaternion.identity);
                        GameObject.FindObjectOfType<Button>().transform.parent = ButtonHolder.transform;
                    }
                    else
                    {
                        Instantiate(Boutton2, SpawnPoint3.transform.position, Quaternion.identity);
                        GameObject.FindObjectOfType<Button>().transform.parent = ButtonHolder.transform;
                        Instantiate(Boutton3, SpawnPoint2.transform.position, Quaternion.identity);
                        GameObject.FindObjectOfType<Button>().transform.parent = ButtonHolder.transform;
                    }

                    break;
                case 2:
                    Instantiate(Boutton, SpawnPoint2.transform.position, Quaternion.identity);
                    GameObject.FindObjectOfType<Button>().transform.parent = ButtonHolder.transform;
                    rand = Random.Range(2, 4);
                    if (rand == 2)
                    {
                        Instantiate(Boutton2, SpawnPoint.transform.position, Quaternion.identity);
                        GameObject.FindObjectOfType<Button>().transform.parent = ButtonHolder.transform;
                        Instantiate(Boutton3, SpawnPoint3.transform.position, Quaternion.identity);
                        GameObject.FindObjectOfType<Button>().transform.parent = ButtonHolder.transform;
                    }
                    else
                    {
                        Instantiate(Boutton2, SpawnPoint3.transform.position, Quaternion.identity);
                        GameObject.FindObjectOfType<Button>().transform.parent = ButtonHolder.transform;
                        Instantiate(Boutton3, SpawnPoint.transform.position, Quaternion.identity);
                        GameObject.FindObjectOfType<Button>().transform.parent = ButtonHolder.transform;
                    }

                    break;
                case 3:
                    Instantiate(Boutton, SpawnPoint3.transform.position, Quaternion.identity);
                    GameObject.FindObjectOfType<Button>().transform.parent = ButtonHolder.transform; rand = Random.Range(2, 4);
                    if (rand == 2)
                    {
                        Instantiate(Boutton2, SpawnPoint2.transform.position, Quaternion.identity);
                        GameObject.FindObjectOfType<Button>().transform.parent = ButtonHolder.transform;
                        Instantiate(Boutton3, SpawnPoint.transform.position, Quaternion.identity);
                        GameObject.FindObjectOfType<Button>().transform.parent = ButtonHolder.transform;
                    }
                    else
                    {
                        Instantiate(Boutton2, SpawnPoint.transform.position, Quaternion.identity);
                        GameObject.FindObjectOfType<Button>().transform.parent = ButtonHolder.transform;
                        Instantiate(Boutton3, SpawnPoint2.transform.position, Quaternion.identity);
                        GameObject.FindObjectOfType<Button>().transform.parent = ButtonHolder.transform;
                    }
                    break;
            }
            InitialisationButton = true;
            manche++;
        }

    }




}
