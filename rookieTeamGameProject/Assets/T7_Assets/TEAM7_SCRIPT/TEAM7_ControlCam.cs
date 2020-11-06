using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TEAM7_ControlCam : MonoBehaviour
{
    GameObject maCam;

    int cam7;

    public GameObject zone0;
    public GameObject zoneN;
    public GameObject zoneS;
    public GameObject zoneE;
    public GameObject zoneO;
    public GameObject zoneNO;
    public GameObject zoneNE;
    public GameObject zoneSE;
    public GameObject zoneSO;


    void Start()
    {
        maCam = Camera.main.gameObject;
        cam7 = 0;
    }

    void Update()
    {

        if (cam7 == 0)
        {
            if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                maCam.transform.position = new Vector3(zoneN.transform.position.x, zoneN.transform.position.y, maCam.transform.position.z); //zoneN
                cam7 = 3;
            }
            else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                maCam.transform.position = new Vector3(zoneS.transform.position.x, zoneS.transform.position.y, maCam.transform.position.z); //zoneS
                cam7 = 7;
            }
            else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                maCam.transform.position = new Vector3(zoneE.transform.position.x, zoneE.transform.position.y, maCam.transform.position.z); //zoneE
                cam7 = 5;
            }
            else if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                maCam.transform.position = new Vector3(zoneO.transform.position.x, zoneO.transform.position.y, maCam.transform.position.z); //zoneO
                cam7 = 1;
            }
        }

        else if (cam7 == 3)
        {
            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                maCam.transform.position = new Vector3(zone0.transform.position.x, zone0.transform.position.y, maCam.transform.position.z); //zone0
                cam7 = 0;
            }
            else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                maCam.transform.position = new Vector3(18.6f, 10, maCam.transform.position.z); //zoneNE
                cam7 = 4;
            }
            else if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                maCam.transform.position = new Vector3(-18.6f, 10, maCam.transform.position.z); //zoneNO
                cam7 = 2;
            }
        }

        else if (cam7 == 7)
        {
            if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.UpArrow))

            {
                maCam.transform.position = new Vector3(zone0.transform.position.x, zone0.transform.position.y, maCam.transform.position.z); //zone0
                cam7 = 0;
            }
            else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                maCam.transform.position = new Vector3(18.6f, -10, maCam.transform.position.z); // zoneSE
                cam7 = 6;
            }
            else if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                maCam.transform.position = new Vector3(-18.6f, -10, maCam.transform.position.z); //zoneSO
                cam7 = 8;
            }
        }

        else if (cam7 == 5)
        {
            if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.UpArrow))

            {
                maCam.transform.position = new Vector3(18.6f, 10, maCam.transform.position.z); //zoneNE
                cam7 = 4;
            }
            else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                maCam.transform.position = new Vector3(18.6f, -10, maCam.transform.position.z); // zoneSE
                cam7 = 6;
            }
            else if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                maCam.transform.position = new Vector3(zone0.transform.position.x, zone0.transform.position.y, maCam.transform.position.z); //zone0
                cam7 = 0;
            }
        }

        else if (cam7 == 1)
        {
            if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.UpArrow))

            {
                maCam.transform.position = new Vector3(-18.6f, 10, maCam.transform.position.z); //zoneNO
                cam7 = 2;
            }
            else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                maCam.transform.position = new Vector3(-18.6f, -10, maCam.transform.position.z); //zoneSO
                cam7 = 8;
            }
            else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                maCam.transform.position = new Vector3(zone0.transform.position.x, zone0.transform.position.y, maCam.transform.position.z); //zone0
                cam7 = 0;
            }
        }

        else if (cam7 == 4)
        {
            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                maCam.transform.position = new Vector3(zoneE.transform.position.x, zoneE.transform.position.y, maCam.transform.position.z); //zoneE
                cam7 = 5;
            }
            else if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                maCam.transform.position = new Vector3(zoneN.transform.position.x, zoneN.transform.position.y, maCam.transform.position.z); //zoneN
                cam7 = 3;
            }
        }

        else if (cam7 == 6)
        {
            if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.UpArrow))

            {
                maCam.transform.position = new Vector3(zoneE.transform.position.x, zoneE.transform.position.y, maCam.transform.position.z); //zoneE
                cam7 = 5;
            }
            else if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                maCam.transform.position = new Vector3(zoneS.transform.position.x, zoneS.transform.position.y, maCam.transform.position.z); //zoneS
                cam7 = 7;
            }
        }

        else if (cam7 == 2)
        {
            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                maCam.transform.position = new Vector3(zoneO.transform.position.x, zoneO.transform.position.y, maCam.transform.position.z); //zoneO
                cam7 = 1;
            }
            else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                maCam.transform.position = new Vector3(zoneN.transform.position.x, zoneN.transform.position.y, maCam.transform.position.z); //zoneN
                cam7 = 3;
            }
        }

        else if (cam7 == 8)
        {
            if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.UpArrow))

            {
                maCam.transform.position = new Vector3(zoneO.transform.position.x, zoneO.transform.position.y, maCam.transform.position.z); //zoneO
                cam7 = 1;
            }
            else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                maCam.transform.position = new Vector3(zoneS.transform.position.x, zoneS.transform.position.y, maCam.transform.position.z); //zoneS
                cam7 = 7;
            }
        }

    }
}