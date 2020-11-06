using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiActiveTeamVague : MonoBehaviour
{
    public KeyCode Touche;

    public bool Active;

    public GameObject Object;
    void Update()
    {
        if (Input.GetKeyDown(Touche))
        {
            Active = ActiveUi(Active);
        }
    }

    bool ActiveUi(bool active)
    {
        Object.SetActive(active);
        return !active;
    }
}
