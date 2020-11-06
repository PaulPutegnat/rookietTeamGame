using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class T9_Boss : MonoBehaviour
{
    public List<SpriteRenderer> spriteRenderers;

    [SerializeField] private List<Sprite> bossSprites;

    [SerializeField] private List<int> livesPhaseBoss;

    [SerializeField] private AudioSource audioSource = null;
    [HideInInspector] public int phase = 0;
    private int lives;
    private float tempPitch = 0f;

    [Header("Boss Movement")]
    [SerializeField] private List<Vector3> movementPoint;
    private int numPos = 0;

    [Header("Phase0")]
    [SerializeField] private List<Sprite> enemiesSprites;
    [SerializeField] private GameObject enemyPrefab;
    [Space]
    [SerializeField] private float speedTimeSpawnP0 = 10f;
    private float speedTimeSpawnFixP0 = 0f;
    [SerializeField] private float decreaseTimeP0 = 1f;
    [SerializeField] private float decreaseByP0 = 0.1f;

    [Header("Phase1")]
    [SerializeField] private GameObject FistP1 = null;
    [Range((int)200, (int)800)] [SerializeField] private float speedFistP1 = 200;
    [Space]
    [SerializeField] private float speedTimeSpawnP1 = 10f;
    [SerializeField] private float speedTimeSpawnFixP1 = 0f;
    [SerializeField] private float decreaseTimeP1 = 1f;
    [SerializeField] private float decreaseByP1 = 0.1f;
    [SerializeField] private float fist1SpeedIncreaseBy = 10f;

    [Header("Phase2")]
    [SerializeField] private GameObject FistP2 = null;
    [Range((int)200, (int)800)] [SerializeField] private float speedFistP2 = 200;
    [Space]
    [SerializeField] private float speedTimeSpawnP2 = 10f;
    [SerializeField] private float speedTimeSpawnFixP2 = 0f;
    [SerializeField] private float decreaseTimeP2 = 1f;
    [SerializeField] private float decreaseByP2 = 0.1f;
    [SerializeField] private float fist2SpeedIncreaseBy = 10f;
    
    [HideInInspector] public bool isDead = false;

    private T9_ShakeScreen shakeScreen;

    private Animator animator;

    [Header("Victory Sound")]
    [SerializeField] private AudioClip winClip;
    private AudioSource audioDamage;

    [Header("Menu")]
    [SerializeField] private T9_menu menu;
    private bool isPause = false;

    private void Start()
    {
        lives = livesPhaseBoss[phase];
        speedTimeSpawnFixP0 = speedTimeSpawnP0;
        speedTimeSpawnFixP1 = speedTimeSpawnP1;
        speedTimeSpawnFixP2 = speedTimeSpawnP2;

        shakeScreen = GetComponent<T9_ShakeScreen>();

        animator = GetComponent<Animator>();

        audioDamage = GetComponent<AudioSource>();

        StartCoroutine(Phase());
        StartCoroutine(BossAngry());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPause)
                Pause();
            else
                menu.Continue();
        }

        if (!isDead)
        {
            if (transform.position == movementPoint[numPos])
            {
                numPos = Random.Range(0, movementPoint.Count);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, movementPoint[numPos], 3.5f * Time.deltaTime);
            }
        }
    }

    public void Pause()
    {
        if (Time.timeScale > 0f)
        {
            isPause = true;
            tempPitch = audioSource.pitch;
            Time.timeScale = 0f;
            audioSource.pitch = 0.5f;
            menu.Pause();
        }
        else
        {
            isPause = false;
            Time.timeScale = 1f;
            audioSource.pitch = tempPitch;
        }
    }

    public void ChangeEmoji(int num, Sprite sprite)
    {
        if (isDead)
            return;

        spriteRenderers[num].sprite = sprite;

        if (spriteRenderers[num].size.x != 2)
            spriteRenderers[num].size = new Vector2(2f, 2f);
    }

    public void LoseLife(int life)
    {
        if (isDead)
            return;

        lives -= life;

        audioDamage.Play();

        if (lives == 0)
        {
            StopCoroutine("Phase2Action");
            StopCoroutine("Phase");
            StopCoroutine(BossAngry());
            isDead = true;
            shakeScreen.Shake(1f, 2f);
            GetComponent<SpriteRenderer>().sprite = bossSprites[3];

            transform.localPosition = Vector3.zero;
            animator.SetTrigger("Boss");
            audioSource.Stop();
            audioDamage.PlayOneShot(winClip);

            menu.Victory();

            return;
        }

        if (lives == livesPhaseBoss[phase + 1])
        {
            StopCoroutine(BossAngry());
            StopCoroutine(Phase());

            phase++;
            audioSource.pitch = 1f;
            GetComponent<SpriteRenderer>().sprite = bossSprites[phase];

            animator.SetTrigger("Boss");

            switch (phase)
            {
                case 0:
                    speedTimeSpawnFixP0 = speedTimeSpawnP0;
                    StartCoroutine(Phase());
                    StartCoroutine(BossAngry());
                    break;

                case 1:
                    shakeScreen.Shake(1f, 0.2f);
                    speedTimeSpawnFixP1 = speedTimeSpawnP1;
                    Phase1();
                    StartCoroutine(Phase());
                    StartCoroutine(BossAngry());
                    break;

                case 2:
                    shakeScreen.Shake(1f, 0.5f);
                    speedTimeSpawnFixP2 = speedTimeSpawnP2;
                    Phase2();
                    StartCoroutine(Phase());
                    StartCoroutine(BossAngry());
                    break;

                default:
                    break;
            }
        }
    }

    IEnumerator Phase()
    {
        while (lives > 0)
        {
            switch (phase)
            {
                case 0:
                    Phase0();
                    yield return new WaitForSeconds(speedTimeSpawnFixP0);
                    break;

                case 1:
                    yield return new WaitForSeconds(speedTimeSpawnFixP1);
                    Phase1();
                    break;

                case 2:
                    yield return new WaitForSeconds(speedTimeSpawnFixP2);
                    Phase2();
                    break;

                default:
                    break;
            }
        }
    }

    public void ResetBossAngry()
    {
        StopCoroutine(BossAngry());

        switch (phase)
        {
            case 0:
                speedTimeSpawnFixP0 = speedTimeSpawnP0;
                StartCoroutine(BossAngry());
                break;

            case 1:
                speedTimeSpawnFixP1 = speedTimeSpawnP1;
                StartCoroutine(BossAngry());
                break;

            case 2:
                speedTimeSpawnFixP2 = speedTimeSpawnP2;
                StartCoroutine(BossAngry());
                break;

            default:
                break;
        }
    }

    public void Phase0() // moving enemies
    {
        if (phase != 0)
            return;

        GameObject enemy = Instantiate(enemyPrefab, new Vector3(transform.position.x, transform.position.y - 5, 0f), Quaternion.identity);
        enemy.GetComponent<SpriteRenderer>().sprite = enemiesSprites[Random.Range(0, enemiesSprites.Count)];
        enemy.GetComponent<T9_MovingEnemy>().boss = this;
    }

    private void Phase1() // Fist
    {
        if (phase != 1)
            return;

        Vector3 spawnPoint = new Vector3(0f, 25f, 0f);
        spawnPoint.x = Random.Range(-28, 28);

        GameObject fist = Instantiate(FistP1, spawnPoint, Quaternion.identity);
        fist.transform.rotation = Quaternion.Euler(0f, 0f, 90f);

        StartCoroutine(Phase1Action(fist));
    }

    IEnumerator Phase1Action(GameObject fist)
    {
        Rigidbody2D fRb = fist.GetComponent<Rigidbody2D>();

        fRb.AddForce(new Vector2(0f, -speedFistP1));

        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(1f);

            if (fist == null)
                break;
        }

        if (fist != null)
            Destroy(fist);
    }

    private void Phase2() // 2x Fist
    {
        if (isDead || phase != 2)
            return;

        Vector3 spawnPoint = new Vector3(0f, 25f, 0f);

        spawnPoint.x = Random.Range(-28, 28);
        GameObject fist1 = Instantiate(FistP2, spawnPoint, Quaternion.Euler(0f, 0f, 90f));

        int sp = Random.Range(-28, 28);
        spawnPoint.x = sp != spawnPoint.x ? sp : Random.Range(-30, 30);
        GameObject fist2 = Instantiate(FistP2, spawnPoint, Quaternion.Euler(0f, 0f, 90f));

        StartCoroutine(Phase2Action(fist1, fist2));
    }

    IEnumerator Phase2Action(GameObject fist1, GameObject fist2)
    {
        Rigidbody2D fRb = fist1.GetComponent<Rigidbody2D>();
        fRb.AddForce(new Vector2(0f, -speedFistP2));

        fRb = fist2.GetComponent<Rigidbody2D>();
        fRb.AddForce(new Vector2(0f, -speedFistP2));

        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(1f);

            if (fist1 == null || fist2 == null)
                break;
        }

        if (fist1 != null || fist2 == null)
        {
            Destroy(fist1);
            Destroy(fist2);
        }
    }

    IEnumerator BossAngry()
    {
        switch (phase)
        {
            case 0:
                yield return new WaitForSeconds(decreaseTimeP0);

                if (speedTimeSpawnFixP0 > 2f)
                {
                    speedTimeSpawnFixP0 -= decreaseByP0;
                    
                }

                if (audioSource.pitch < 1.2f)
                    audioSource.pitch += decreaseByP0 / 25;

                if (lives > 0 && !isDead && (speedTimeSpawnFixP0 > 2f || audioSource.pitch < 1.2f))
                    StartCoroutine(BossAngry());
                break;

            case 1:
                yield return new WaitForSeconds(decreaseTimeP1);

                if (speedTimeSpawnFixP1 > 3f)
                {
                    speedTimeSpawnFixP1 -= decreaseByP1;
                    speedFistP1 += fist1SpeedIncreaseBy;
                }

                if (audioSource.pitch < 1.2f)
                    audioSource.pitch += decreaseByP1 / 25;

                if (lives > 0 && !isDead && (speedTimeSpawnFixP1 > 3f || audioSource.pitch < 1.2f))
                    StartCoroutine(BossAngry());
                break;

            case 2:
                yield return new WaitForSeconds(decreaseTimeP2);

                if (speedTimeSpawnFixP2 > 4f)
                {
                    speedTimeSpawnFixP2 -= decreaseByP2;
                    speedFistP2 += fist2SpeedIncreaseBy;
                }

                if (audioSource.pitch < 1.2f)
                    audioSource.pitch += decreaseByP2 / 25;

                if (lives > 0 && !isDead && (speedTimeSpawnFixP2 > 4f || audioSource.pitch < 1.2f))
                    StartCoroutine(BossAngry());
                break;

            default:
                break;
        }
    }
}