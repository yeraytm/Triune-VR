using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGeneration : MonoBehaviour
{
    public Transform[] spawnPos;
    public GameObject[] spawnee;
    private int generationCounter;
    private int randMax = 500;
    private float diff = 0.0f;
    // Update is called once per frame
    void Update()
    {
        generationCounter++;
        if (generationCounter > randMax)
        {
            switch (diff)
            {
                case 0.0f:
                    Debug.Log("Rand Max: " + randMax);
                    randMax = Random.Range(1500, 2000);
                    break;
                case 1.0f:
                    Debug.Log("Rand Max: " + randMax);

                    randMax = Random.Range(1000, 1500);

                    break;
                case 2.0f:
                    Debug.Log("Rand Max: " + randMax);

                    randMax = Random.Range(500, 1000);

                    break;
            }
            generationCounter = 0;
            int randEnemy = Random.Range(0, 3);
            int randPos = Random.Range(0, 10);
            Instantiate(spawnee[randEnemy], spawnPos[randPos].position, spawnPos[randPos].rotation);
        }
    }

    public void ChangeDifficulty(float difficulty)
    {
        Debug.Log("Difficulty: " + difficulty);

        diff = difficulty;

    }
}
