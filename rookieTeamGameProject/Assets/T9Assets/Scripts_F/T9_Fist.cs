using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T9_Fist : MonoBehaviour
{
    private bool canAttack = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (canAttack)
            {
                PlayerT9 player = collision.gameObject.GetComponent<PlayerT9>();

                if (!player.invincibility)
                    player.PlayerTakeDamage();

                SpriteRenderer sp = GetComponent<SpriteRenderer>();
                sp.color = new Color(1f, 1f, 1f, 0.25f);
                canAttack = false;
            }
        }
        else if (collision.gameObject.CompareTag("IWFist"))
        {
            Destroy(gameObject);
        }
    }
}
