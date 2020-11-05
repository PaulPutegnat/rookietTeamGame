using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T8EnemySpawn : MonoBehaviour
{
    public GameObject[] enemy;

    public float spawnTimer;
    public float spawnTimerMax;
    public float spawnRadius;

    public int level;

    // Start is called before the first frame update
    void Start()
    {
        level = 0;
        AddSpawnLevel();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.L))
            AddSpawnLevel();

        if (level != 0 && spawnTimer >= 0)
        {
            spawnTimer -= Time.deltaTime;

            if (spawnTimer <= 0)
            {
                SpawnEnemy();
            }
        }
    }

    public void AddSpawnLevel()
    {
        level++;

        
        switch (level)
        {
            case 1:
                spawnTimerMax = 6.0f;
                break;

            case 2:
                spawnTimerMax = 5.8f;
                break;

            case 3:
                spawnTimerMax = 5.6f;
                break;

            default:
                break;
        }
    }
    
    void SpawnEnemy()
    {
        // Tirage Random : toSpawn GameObject

        Vector3 pos = Random.insideUnitCircle.normalized * spawnRadius;

        Instantiate(enemy[0], pos, Quaternion.identity);

        spawnTimer = spawnTimerMax;
    }
}
