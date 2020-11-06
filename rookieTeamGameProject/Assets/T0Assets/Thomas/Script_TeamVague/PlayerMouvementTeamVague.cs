using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouvementTeamVague : MonoBehaviour
{
    GamePlayerManagerTeamVague GameManager;

    [Header("Wall Checker")]

    public bool isStoped;
    public Transform wallCheck;
    //public float wallCheckRaduis;
    public Vector2 wallCheckRadius;
    public LayerMask whatIsStoped;
    public DecomptTeamVague dec;
    void Start()
    {
        GameObject gameController = GameObject.FindGameObjectWithTag("GameController");
        GameManager = gameController.GetComponent<GamePlayerManagerTeamVague>();

        isStoped = false;
    }

    void Update()
    {
        if(!isStoped && dec.last<=0)
        {
            transform.Translate(GameManager.moveVector * GameManager.moveSpeed * Time.deltaTime);
        }
        
    }

    private void FixedUpdate()
    {
        isStoped = Physics2D.OverlapBox(wallCheck.position, wallCheckRadius, 0.0f, whatIsStoped);
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "tag")
        {
            isStoped = true;
        }
        else
        {
            isStoped = false;
        }
    }
}
