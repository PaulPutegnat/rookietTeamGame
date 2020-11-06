using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T9_MovingEnemy : MonoBehaviour
{
    private Vector3 position = Vector3.zero;
    [SerializeField] private float moveSpeed = 5f;
    private Rigidbody2D rb;
    private int count = 0;
    [HideInInspector] public T9_Boss boss;

    void Start()
    {
        StartCoroutine("Moving");
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (count >= 5 || boss.phase > 0)
        {
            StopCoroutine(Moving());
            Destroy(gameObject);
        }
        if (Vector3.Distance(position, transform.position) > 0.1f)
        {
            Vector3 direction = position - transform.position;
            direction.Normalize();

            rb.MovePosition(transform.position + (direction * moveSpeed * Time.deltaTime));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
            return;

        PlayerT9 player = collision.gameObject.GetComponent<PlayerT9>();

        if (!player.invincibility)
        {
            player.PlayerTakeDamage();

            StopCoroutine(Moving());
            boss.Phase0();
            Destroy(gameObject);
        }
    }

    IEnumerator Moving()
    {
        while (count <= 4)
        {
            {
                position.x = Random.Range(-28f, 28f);
            }
            {
                position.y = Random.Range(-11f, 14f);
            }

            yield return new WaitForSeconds(5f);

            count += 1;
        }
    }
}
