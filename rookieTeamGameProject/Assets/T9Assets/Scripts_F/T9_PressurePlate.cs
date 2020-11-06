using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T9_PressurePlate : MonoBehaviour
{
    private SpriteRenderer spriteRenderer = null;
    [HideInInspector] public int plateNum = -1;
    [HideInInspector] public T9_EmojiManager emojiManager;

    private void Awake()
    {
        SpriteRenderer[] sp = GetComponentsInChildren<SpriteRenderer>();
        spriteRenderer = sp[1]; // Get children sp not the actual gameobject sp
    }

    void Update()
    {
        
    }

    public void ChangeEmoji(Sprite sprite)
    {
        spriteRenderer.sprite = sprite;

        if (spriteRenderer.size.x != 0.3)
            spriteRenderer.size = new Vector2(0.3f, 0.6f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
            return;

        PlayerT9 player = collision.gameObject.GetComponent<PlayerT9>();

        if (player.isDashingBack)
        {
            player.isDashingBack = false;
            emojiManager.PlateHit(plateNum);
        }
    }
}
