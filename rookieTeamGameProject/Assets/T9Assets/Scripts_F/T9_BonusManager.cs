using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T9_BonusManager : MonoBehaviour
{
    [SerializeField] private GameObject bonusPrefab;
    [Space]
    [SerializeField] private List<Vector3> spawnPositions;
    [SerializeField] private List<Sprite> sprites;
    [SerializeField] private Vector2 timeInterval;

    private T9_Bonus bonus = null;
    bool isWorking = false;

    private void Start()
    {
        if (bonus == null && !isWorking)
            StartCoroutine("NewBonus");
    }


    private void Update()
    {
        if (bonus == null && !isWorking)
        {
            StartCoroutine("NewBonus");
        }
    }

    IEnumerator NewBonus()
    {
        float timeWait = Random.Range(timeInterval.x, timeInterval.y);
        isWorking = true;

        yield return new WaitForSeconds(timeWait);

        int bonusInt = Random.Range(0, 3);

        yield return new WaitForSeconds(0.1f);

        int pos = Random.Range(0, spawnPositions.Count);

        GameObject nBonus = Instantiate(bonusPrefab, spawnPositions[pos], Quaternion.identity);
        bonus = nBonus.GetComponent<T9_Bonus>();
        bonus.Initialize(bonusInt, sprites[bonusInt]);

        isWorking = false;
    }
}
