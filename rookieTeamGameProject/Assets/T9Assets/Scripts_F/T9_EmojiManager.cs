using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class T9_EmojiManager : MonoBehaviour
{
    [SerializeField] private List<Sprite> emojieSprites = null;
    [SerializeField] private List<T9_PressurePlate> pressurePlates = null;

    [SerializeField] private T9_Boss boss = null;

    [SerializeField] private float rollTime = 2f;

    public List<int> combinaison = new List<int>();

    private int playerPlateNum = 0;
    private List<int> playerCombinaison = new List<int>();

    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            combinaison.Add(i);
            playerCombinaison.Add(i);
        }

        StartCoroutine("RollCombinaison");
    }

    void Update()
    {
        
    }

    private void ChangeCombinaison()
    {
        List<int> allNums = new List<int>();
        bool initializePlate = !(pressurePlates[0].plateNum == 0);

        for (int i = 0; i < emojieSprites.Count; i++)
            allNums.Add(i);

        List<int> pressurePlatesNum = new List<int>();

        for (int i = 0; i < 3; i++)
        {
            pressurePlatesNum.Add(Random.Range(0, pressurePlates.Count));
        }

        for (int i = 0; i < pressurePlates.Count; i++)
        {
            if (initializePlate)
            {
                pressurePlates[i].plateNum = i;
                pressurePlates[i].emojiManager = this;
            }

            int emojiNum = Random.Range(0, allNums.Count);

            if (i == pressurePlatesNum[0])
            {
                combinaison[0] = pressurePlatesNum[0];
                boss.ChangeEmoji(0, emojieSprites[allNums[emojiNum]]);
            }
            if (i == pressurePlatesNum[1])
            {
                combinaison[1] = pressurePlatesNum[1];
                boss.ChangeEmoji(1, emojieSprites[allNums[emojiNum]]);
            }
            if (i == pressurePlatesNum[2])
            {
                combinaison[2] = pressurePlatesNum[2];
                boss.ChangeEmoji(2, emojieSprites[allNums[emojiNum]]);
            }

            pressurePlates[i].ChangeEmoji(emojieSprites[allNums[emojiNum]]);
            allNums.RemoveAt(emojiNum);
        }
    }

    private void Roll(int emoji)
    {
        for (int i = 0; i < pressurePlates.Count; i++)
        {
            int emNull = emoji + i;

            if (emoji + i > emojieSprites.Count - 1)
                emNull = emoji - 1;

            pressurePlates[i].ChangeEmoji(emojieSprites[emNull]);
        }
    }

    IEnumerator RollCombinaison()
    {
        int x = 0;
        for (float i = 0f; i < rollTime; i += rollTime / 10f)
        {
            //Roll(x);

            yield return new WaitForSeconds(rollTime / 10f);

            if (x < emojieSprites.Count - 1)
                x++;
            else
                x = 0;
        }

        ChangeCombinaison();
    }

    public void PlateHit(int num)
    {
        if (boss.isDead)
            return;

        if (num == combinaison[playerPlateNum])
        {
            boss.spriteRenderers[playerPlateNum].gameObject.SetActive(false);
            playerPlateNum++;
        }
        else
        {
            for (int i = 0; i < playerPlateNum; i++)
            {
                boss.spriteRenderers[i].gameObject.SetActive(true);
            }

            playerPlateNum = 0;
        }

        if (playerPlateNum == 3)
        {
            playerPlateNum = 0;
            boss.LoseLife(1);

            if (boss.isDead)
                return;

            for (int i = 0; i < 3; i++)
            {
                boss.spriteRenderers[i].gameObject.SetActive(true);
            }

            if (!boss.isDead)
                ChangeCombinaison();
        }
    }
}
