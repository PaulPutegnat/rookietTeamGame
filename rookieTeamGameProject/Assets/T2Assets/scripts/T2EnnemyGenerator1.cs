using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T2EnnemyGenerator1 : MonoBehaviour
{
    // Start is called before the first frame update
    public float IntervalleEntre2;
    public GameObject pos1;
    public GameObject pos2;
    public GameObject pos3;
    public GameObject pos4;
    public GameObject pos5;
    public GameObject pos6;
    public GameObject ennemy;
    public float TempsRestant;
    private int rand;
    private void Start()
    {
        TempsRestant = IntervalleEntre2;
    }
    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<T2DifficultyManagement>().PhaseActive) {
            if (TempsRestant > 0)
            {
                TempsRestant -= Time.deltaTime;
            }
            else
            {
                rand = Random.Range(1, 7);
                switch (rand)
                {
                    case 1:

                        Instantiate(ennemy, new Vector3(pos1.transform.position.x, pos1.transform.position.y, 0), Quaternion.identity);
                        break;
                    case 2:

                        Instantiate(ennemy, new Vector3(pos2.transform.position.x, pos2.transform.position.y, 0), Quaternion.identity);
                        break;
                    case 3:

                        Instantiate(ennemy, new Vector3(pos3.transform.position.x, pos3.transform.position.y, 0), Quaternion.identity);
                        break;
                    case 4:

                        Instantiate(ennemy, new Vector3(pos4.transform.position.x, pos4.transform.position.y, 0), Quaternion.identity); break;
                    case 5:

                        Instantiate(ennemy, new Vector3(pos5.transform.position.x, pos5.transform.position.y, 0), Quaternion.identity); break;
                    case 6:

                        Instantiate(ennemy, new Vector3(pos6.transform.position.x, pos6.transform.position.y, 0), Quaternion.identity); break;
                    default:
                        break;
                }
                TempsRestant = IntervalleEntre2;
            }
        }
    }
}
