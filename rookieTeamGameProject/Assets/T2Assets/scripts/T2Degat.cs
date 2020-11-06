using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class T2Degat : MonoBehaviour
{
    public int maxAffection = 100;
    public int affection = 5;
    public T2BarreAffection BarreAffection;


    private void Start()
    {
        affection = maxAffection;
        BarreAffection.SetMaxAffection(maxAffection);
        affection = 50;
        BarreAffection.SetAffection(affection);
    }

    public void Soin(int heal)
    {
        affection += heal;
        BarreAffection.SetAffection(affection);
        if (affection >= maxAffection)
            affection = maxAffection;
    }

    public void Takedmg(int dmg)
    {
        affection -= dmg;
        BarreAffection.SetAffection(affection);
    }

    void Die()
    {
        SceneManager.LoadScene("GameOver");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            Takedmg(20);
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            Soin(20);
        }
     
    }
}
