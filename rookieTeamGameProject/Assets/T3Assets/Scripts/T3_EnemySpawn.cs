using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T3_EnemySpawn : MonoBehaviour
{
    public SpriteRenderer spawnRenderer;


    [Header("Normal Enemies")]
    public GameObject[] normalEnemies;

    [Header("Advanced Enemies")]
    public GameObject[] advancedEnemies;

    [Header("Special Malus Enemies")]
    public GameObject[] specialMalusEnemies;
    
    [Header("Special Bonus Enemies")]
    public GameObject[] specialBonusEnemies;


    [Header("Classique Enemies RigidBody")]
    public Rigidbody2D enemyLove;
    public Rigidbody2D enemyBlaze;
    public Rigidbody2D enemyWink;
    public Rigidbody2D enemyShocked;
    public Rigidbody2D enemyMalice;
    public Rigidbody2D enemyMad;
    public Rigidbody2D enemyCry;
    public Rigidbody2D enemyLaugh;
    public Rigidbody2D enemySmile;
    
    [Header("Bipo Enemies RigidBody")]
    public Rigidbody2D enemyBipoLove;
    public Rigidbody2D enemyBipoBlaze;
    public Rigidbody2D enemyBipoWink;
    public Rigidbody2D enemyBipoShocked;
    public Rigidbody2D enemyBipoMalice;
    public Rigidbody2D enemyBipoMad;
    public Rigidbody2D enemyBipoCry;
    public Rigidbody2D enemyBipoLaugh;
    public Rigidbody2D enemyBipoSmile;
    
    [Header("Schizo Enemies RigidBody")]
    public Rigidbody2D enemySchizoLove;
    public Rigidbody2D enemySchizoBlaze;
    public Rigidbody2D enemySchizoWink;
    public Rigidbody2D enemySchizoShocked;
    public Rigidbody2D enemySchizoMalice;
    public Rigidbody2D enemySchizoMad;
    public Rigidbody2D enemySchizoCry;
    public Rigidbody2D enemySchizoLaugh;
    public Rigidbody2D enemySchizoSmile;


    [Header("Normal Gravity")]
    public float gravityNormalMin;
    public float gravityNormalMax;
    public float normalSpeedUp;

    [Header("Advanced Gravity")]
    public float gravityAdvancedMin;
    public float gravityAdvancedMax;
    public float advancedSpeedUp;

    [Header("Special Gravity")]
    public float gravitySpecialMin;
    public float gravitySpecialMax;
    public float specialSpeedUp;

    [Header("Timer")]
    public int timeUpgrade;
    public float timer;

    [Header("Normal SpawnRates")]
    public float spawnNormalEnemiesRate;
    private float nextSpawnNormalTime;
    public float minNormalSpawnRate;
    public float normalSpawnRateUpgrade;

    [Header("Advanced SpawnRates")]
    public float spawnAdvancedEnemiesRate;
    private float nextSpawnAdvancedTime;
    public float minAdvancedSpawnRate;
    public float advancedSpawnRateUpgrade;

    private void Start()
    {
        InitializeGravityScale();
        StartCoroutine(SpeedUpCoroutine());

        nextSpawnNormalTime = 2;
        nextSpawnAdvancedTime = 9;
    }

    private void Update()
    {
        timer = Time.time;

        if (Time.time > nextSpawnNormalTime)
            SpawnNormalEnemies();

        if (Time.time > nextSpawnAdvancedTime)
        {
            SpawnAdvancedEnemies();
        }

        if (spawnNormalEnemiesRate < minNormalSpawnRate)
        {
            spawnNormalEnemiesRate = minNormalSpawnRate;
        }

        if (spawnAdvancedEnemiesRate < minAdvancedSpawnRate)
        {
            spawnAdvancedEnemiesRate = minAdvancedSpawnRate;
        }
    }

    private void InitializeGravityScale()
    {
        enemyLove.gravityScale = Random.Range(gravityAdvancedMin, gravityAdvancedMax);
        enemyBlaze.gravityScale = Random.Range(gravityAdvancedMin, gravityAdvancedMax);
        enemyWink.gravityScale = Random.Range(gravityNormalMin, gravityNormalMax);
        enemyShocked.gravityScale = Random.Range(gravityNormalMin, gravityNormalMax);
        enemyMalice.gravityScale = Random.Range(gravityAdvancedMin, gravityAdvancedMax);
        enemyMad.gravityScale = Random.Range(gravityNormalMin, gravityNormalMax);
        enemyCry.gravityScale = Random.Range(gravityNormalMin, gravityNormalMax);
        enemyLaugh.gravityScale = Random.Range(gravityNormalMin, gravityNormalMax);
        enemySmile.gravityScale = Random.Range(gravityNormalMin, gravityNormalMax);
        enemyBipoLove.gravityScale = Random.Range(gravitySpecialMin, gravitySpecialMax);
        enemyBipoBlaze.gravityScale = Random.Range(gravitySpecialMin, gravitySpecialMax);
        enemyBipoWink.gravityScale = Random.Range(gravitySpecialMin, gravitySpecialMax);
        enemyBipoShocked.gravityScale = Random.Range(gravitySpecialMin, gravitySpecialMax);
        enemyBipoMalice.gravityScale = Random.Range(gravitySpecialMin, gravitySpecialMax);
        enemyBipoMad.gravityScale = Random.Range(gravitySpecialMin, gravitySpecialMax);
        enemyBipoCry.gravityScale = Random.Range(gravitySpecialMin, gravitySpecialMax);
        enemyBipoLaugh.gravityScale = Random.Range(gravitySpecialMin, gravitySpecialMax);
        enemyBipoSmile.gravityScale = Random.Range(gravitySpecialMin, gravitySpecialMax);
        enemySchizoLove.gravityScale = Random.Range(gravitySpecialMin, gravitySpecialMax);
        enemySchizoBlaze.gravityScale = Random.Range(gravitySpecialMin, gravitySpecialMax);
        enemySchizoWink.gravityScale = Random.Range(gravitySpecialMin, gravitySpecialMax);
        enemySchizoShocked.gravityScale = Random.Range(gravitySpecialMin, gravitySpecialMax);
        enemySchizoMalice.gravityScale = Random.Range(gravitySpecialMin, gravitySpecialMax);
        enemySchizoMad.gravityScale = Random.Range(gravitySpecialMin, gravitySpecialMax);
        enemySchizoCry.gravityScale = Random.Range(gravitySpecialMin, gravitySpecialMax);
        enemySchizoLaugh.gravityScale = Random.Range(gravitySpecialMin, gravitySpecialMax);
        enemySchizoSmile.gravityScale = Random.Range(gravitySpecialMin, gravitySpecialMax);
    }

    private void SpawnNormalEnemies()
    {
        Vector3 center = spawnRenderer.bounds.center;
        Vector3 size = spawnRenderer.bounds.size;
        Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), transform.position.z);
        nextSpawnNormalTime = Time.time + spawnNormalEnemiesRate;
        Instantiate(normalEnemies[Random.Range(0, normalEnemies.Length)], pos, Quaternion.identity);
    }
    
    private void SpawnAdvancedEnemies()
    {
        Vector3 center = spawnRenderer.bounds.center;
        Vector3 size = spawnRenderer.bounds.size;
        Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), transform.position.z);
        nextSpawnAdvancedTime = Time.time + spawnAdvancedEnemiesRate;
        Instantiate(advancedEnemies[Random.Range(0, advancedEnemies.Length)], pos, Quaternion.identity);
    }
    
    public void SpawnSpecialMalusEnemies()
    {
        Vector3 center = spawnRenderer.bounds.center;
        Vector3 size = spawnRenderer.bounds.size;
        Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), transform.position.z);
        Instantiate(specialMalusEnemies[Random.Range(0, specialMalusEnemies.Length)], pos, Quaternion.identity);
    }
    
    public void SpawnSpecialBonusEnemies()
    {
        Vector3 center = spawnRenderer.bounds.center;
        Vector3 size = spawnRenderer.bounds.size;
        Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), transform.position.z);
        Instantiate(specialBonusEnemies[Random.Range(0, specialBonusEnemies.Length)], pos, Quaternion.identity);
    }

    IEnumerator SpeedUpCoroutine()
    {
        WaitForSeconds wait = new WaitForSeconds(timeUpgrade);

        for (int i = 0; i < 100; i++)
        {
            gravityNormalMin += normalSpeedUp;
            gravityNormalMax += normalSpeedUp;
            gravityAdvancedMin += advancedSpeedUp;
            gravityAdvancedMax += advancedSpeedUp;
            gravitySpecialMin += specialSpeedUp;
            gravitySpecialMax += specialSpeedUp;

            spawnNormalEnemiesRate -= normalSpawnRateUpgrade;
            spawnAdvancedEnemiesRate -= advancedSpawnRateUpgrade;


            
            InitializeGravityScale();
            yield return wait;
        }
    }
}
