using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGeneration : MonoBehaviour
{
    public Transform[] spawnPos;
    public GameObject[] spawnee;
    private int generationCounter;

    // Update is called once per frame
    void Update()
    {
        generationCounter++;
        int randMax = Random.Range(500, 1500);
        if (generationCounter > randMax)
        {
            generationCounter = 0;
            int randEnemy = Random.Range(0, 3);
            int randPos = Random.Range(0, 10);
            Instantiate(spawnee[randEnemy], spawnPos[randPos].position, spawnPos[randPos].rotation);
        }
    }
}
