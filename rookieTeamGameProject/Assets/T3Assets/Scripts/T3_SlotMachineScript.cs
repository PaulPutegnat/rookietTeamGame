using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class T3_SlotMachineScript : MonoBehaviour
{

    private bool isTurning = false;

    public T3_FirstSlotMachine firstSlotMachine;
    public T3_SecondSlotMachine secondSlotMachine;
    public T3_ThirdSlotMachine thirdSlotMachine;

    public int timeBetweenTurning;

    [Header("T3_EnemySpawn Script")]
    public T3_EnemySpawn enemySpawn;

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(SlotMachine());
    }

    // Update is called once per frame
    void Update()
    {
        if (!isTurning)
        {
            StartCoroutine(SlotMachine());
            isTurning = true;
        }
    }


    IEnumerator SlotMachine()
    {
        WaitForSeconds waitFor = new WaitForSeconds(timeBetweenTurning);
        WaitForSeconds pause = new WaitForSeconds(.1f);
        Sprite firstSlot = null;
        Sprite secondSlot = null;
        Sprite thirdSlot = null;

        yield return waitFor;

        for (int i = 0; i < 5; i++)
        {
            firstSlot = firstSlotMachine.RandomizeSprite();
            secondSlot = secondSlotMachine.RandomizeSprite();
            thirdSlot = thirdSlotMachine.RandomizeSprite();
            yield return pause;
        }

        if (firstSlot.name == "Bonus" && secondSlot.name == "Bonus" && thirdSlot.name == "Bonus")
        {
            enemySpawn.SpawnSpecialBonusEnemies();
        }
        
        if (firstSlot.name == "Malus" && secondSlot.name == "Malus" && thirdSlot.name == "Malus")
        {
            enemySpawn.SpawnSpecialMalusEnemies();
        }

        isTurning = false;
    }
}
