using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbsorbEssenceScript : MonoBehaviour
{
    [Header("Absorver Positioning")]
    public Transform cannon;
    private GunScript shooter;

    // Start is called before the first frame update
    void Start()
    {
        shooter = GameObject.Find("Essence Shooter").GetComponent<GunScript>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Absorb()
    {
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (/*Input.GetKeyDown("return") && */Physics.Raycast(cannon.position, cannon.forward, out hit, Mathf.Infinity))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);

            bool hitTrigger = true;
            State state = State.EMPTY;

            switch (hit.collider.tag)
            {
                case "WATER":
                    shooter.ChangeGunState(State.WATER);
                    state = State.WATER;
                    break;

                case "NATURE":
                    shooter.ChangeGunState(State.NATURE);
                    state = State.NATURE;
                    break;

                case "FIRE":
                    shooter.ChangeGunState(State.FIRE);
                    state = State.FIRE;
                    break;

                default:
                    hitTrigger = false;
                    break;
            }

            if (hitTrigger)
            {
                GameObject triggerGroup = hit.collider.gameObject/*trigger*/.transform.parent.gameObject/*element trigger grup*/.transform.parent.gameObject/*Trigger grup*/;
                StartCoroutine(triggerGroup.GetComponent<EssenceSpawnScript>().Respawn(hit.transform, state));
            }
        }
    }
}
