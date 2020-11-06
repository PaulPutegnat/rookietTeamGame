﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerT9 : MonoBehaviour
{
     public GameObject emojiPrefab;
     public Vector2 secondsBetweenSpawnsMinMax;
     public float nextSpawnTime;

     public Vector2 spawnSizeMinMax;
     public float spawnAngleMax;

     Vector2 screenHalfSizeWorldUnits;

     // Start is called before the first frame update
     void Start()
     {
         screenHalfSizeWorldUnits = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
     }

     // Update is called once per frame
     void Update()
     {
         if (Time.time > nextSpawnTime)
         {
             float secondsBetweenSpawns = Mathf.Lerp(secondsBetweenSpawnsMinMax.y, secondsBetweenSpawnsMinMax.x, DifficultyT9.GetDifficultyPercent());
             nextSpawnTime = Time.time + secondsBetweenSpawns;

             float spawnAngle = Random.Range(-spawnAngleMax, spawnAngleMax);
             float spawnSize = Random.Range(spawnSizeMinMax.x, spawnSizeMinMax.y);
             Vector2 spawnPosition = new Vector2(Random.Range(-screenHalfSizeWorldUnits.x, screenHalfSizeWorldUnits.x), screenHalfSizeWorldUnits.y + spawnSize);
             GameObject newBlock = (GameObject)Instantiate(emojiPrefab, spawnPosition, Quaternion.Euler(Vector3.forward * spawnAngle));
             newBlock.transform.localScale = Vector2.one * spawnSize;
         }

        
     }
}
