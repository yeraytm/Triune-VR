using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

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

    public Animator animator;
    private GameObject fighter;
    private NavMeshAgent navMeshAgent;
    private bool attacking = false;
    private int attackCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        fighter = GameObject.FindWithTag("Player");

        navMeshAgent = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
        navMeshAgent.destination = fighter.transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        float distance = Vector3.Distance(gameObject.transform.position, fighter.transform.position);
        if (distance < 5 && !attacking)
        {
            attacking = true;
            navMeshAgent.speed = 0;
            animator.SetBool("Walk Forward", false);
            animator.Play("Idle");
        }

        if (attacking)
        {
            attackCounter++;
            int randMax = Random.Range(500, 1000);
            if (attackCounter > randMax)
            {
                attackCounter = 0;
                animator.SetTrigger("PunchTrigger");
            }
        }
    }

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