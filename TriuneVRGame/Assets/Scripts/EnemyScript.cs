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

    private int lifes = 1;

    public int lifeLimit = 3;
    public EnemyType type;
    public Vector3 scaleIncrease = new Vector3( 1.0f, 1.0f, 1.0f );

    // Update is called once per frame
    void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "FIRE_B":
                switch (type)
                {
                    case EnemyType.FIRE:
                        Boost();
                        break;

                    case EnemyType.WATER:
                        SpeedUp();
                        break;

                    case EnemyType.NATURE:
                        Damage();
                        break;
                }
                break;

            case "WATER_B":
                switch (type)
                {
                    case EnemyType.FIRE:
                        Damage();
                        break;

                    case EnemyType.WATER:
                        Boost();
                        break;

                    case EnemyType.NATURE:
                        SpeedUp();
                        break;
                }
                break;

            case "NATURE_B":
                switch (type)
                {
                    case EnemyType.FIRE:
                        SpeedUp();
                        break;

                    case EnemyType.WATER:
                        Damage();
                        break;

                    case EnemyType.NATURE:
                        Boost();
                        break;
                }
                break;
        }
    }

    void Damage()
    {
        lifes -= 1;

        if (lifes == 0) Destroy(gameObject);

        transform.localScale -= scaleIncrease;
    }

    void Boost()
    {
        if (lifes >= lifeLimit)
        {
            lifes = 3;
            return;
        }

        lifes += 1;

        transform.localScale += scaleIncrease;
    }

    void SpeedUp()
    {

    }
}
