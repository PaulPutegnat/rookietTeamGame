using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class T2Score : MonoBehaviour
{
    public Text scoreText;
    public int score;



    void Start()
    {
        score = 0;
        SetScoreText();
    }

    void SetScoreText()
    {
        scoreText.text = score.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
      
        if (collision.gameObject.CompareTag("T2MauvaisSmiley"))
        {
            score = ++score;
            SetScoreText();
            Destroy(collision.gameObject);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            score = ++score;
            SetScoreText();
        }
    }
}
