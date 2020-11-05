using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T8_OvniScr : MonoBehaviour
{
    public float frequency;
    public float magnitude;

    public float percent = 0;
    public int i = 1;

    [SerializeField]
    public float speed = 1;
    
    Vector3 velocity;

    void Awake()
    {
        velocity = (GameObject.Find("Player").transform.position - transform.position).normalized;

        /*float angle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);*/
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += (velocity * Time.deltaTime * speed / 10);
        //float posY = transform.localPosition.y * Mathf.Sin(Time.deltaTime * frequency) * magnitude;

        //Vector3 basePosition = transform.forward * Time.deltaTime * speed / 10;
        //transform.position = basePosition + transform.up * Mathf.Sin(frequency) * magnitude;
        

        transform.position = new Vector3(transform.position.x + velocity.x * percent * Time.deltaTime * speed, transform.position.y + velocity.y * (1 - percent) * Time.deltaTime * speed, transform.position.z);
        percent += (0.01f * i);
        if (percent <= 0)
            i = 1;
        else if (percent >= 1)
            i = -1;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            collision.gameObject.GetComponent<T8_Player>().GetHit();
            Destroy(gameObject);
        }
    }
}
