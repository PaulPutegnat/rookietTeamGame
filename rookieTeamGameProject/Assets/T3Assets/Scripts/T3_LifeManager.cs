using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T3_LifeManager : MonoBehaviour
{
    public T3_GameController gameController;

    [Header("Vie")]
    public int maxHealth = 3;
    public int currentHealth;
    public GameObject[] healthPoints;

    void Start()
    {
        currentHealth = maxHealth;

        for (int i = 0; i < healthPoints.Length; i++)
        {
            if (currentHealth >= maxHealth / healthPoints.Length * (i + 1))
            {
                healthPoints[i].SetActive(true);
            }
        }
    }

    public void RestoreLife(int lifeUp)
    {
        currentHealth += lifeUp;
        T3_SoundController.Instance.MakeRestoreLifeSound();

        if (currentHealth >= maxHealth)
        {
            maxHealth = currentHealth;
        }

        for (int i = 0; i < healthPoints.Length; i++)
        {
            if (currentHealth >= maxHealth / healthPoints.Length * (i + 1))
            {
                healthPoints[i].SetActive(true);
            }
            else
            {
                healthPoints[i].SetActive(false);
            }

        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        T3_SoundController.Instance.MakeTakeDamageSound();

        if (currentHealth <= 0)
        {
            Die();
        }

        for (int i = 0; i < healthPoints.Length; i++)
        {
            if (currentHealth >= maxHealth / healthPoints.Length * (i + 1))
            {
                healthPoints[i].SetActive(true);
            }
            else
            {
                healthPoints[i].SetActive(false);
            }

        }
    }


    public void Die()
    {
        gameController.Defeat();
    }
}
