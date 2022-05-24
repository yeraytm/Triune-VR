using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public enum EnemyType
    {
        FIRE,
        WATER,
        NATURE
    }

    public EnemyType type;
    // Start is called before the first frame update
    void Start()
    {
        switch (type)
        {
            case EnemyType.FIRE: 
                gameObject.tag = "FIRE"; 
                break;

            case EnemyType.WATER:
                gameObject.tag = "WATER";
                break;

            case EnemyType.NATURE:
                gameObject.tag = "NATURE";
                break;
        }
    }

    // Update is called once per frame
    void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "FIRE_B":
                switch (type)
                {
                    case EnemyType.FIRE:
                        break;

                    case EnemyType.WATER:
                        break;

                    case EnemyType.NATURE:
                        Destroy(gameObject);
                        break;
                }
                break;

            case "WATER_B":
                switch (type)
                {
                    case EnemyType.FIRE:
                        Destroy(gameObject);
                        break;

                    case EnemyType.WATER:
                        break;

                    case EnemyType.NATURE:
                        break;
                }
                break;

            case "NATURE_B":
                switch (type)
                {
                    case EnemyType.FIRE:
                        break;

                    case EnemyType.WATER:
                        Destroy(gameObject);
                        break;

                    case EnemyType.NATURE:
                        break;
                }
                break;
        }
    }
}
