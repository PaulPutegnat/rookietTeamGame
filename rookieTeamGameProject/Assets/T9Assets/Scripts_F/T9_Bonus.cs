using UnityEngine;

public class T9_Bonus : MonoBehaviour
{
    private int bonusType = 0;

    public void Initialize(int bonus, Sprite sprite)
    {
        GetComponent<SpriteRenderer>().sprite = sprite;
        bonusType = bonus;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
            return;

        collision.gameObject.GetComponent<PlayerT9>().BonusType(bonusType);
        Destroy(gameObject);
    }
}
