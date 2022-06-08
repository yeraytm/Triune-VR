using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbsorbEssenceScript : MonoBehaviour
{
    [Header("Absorver Positioning")]
    //public Transform follower;
    public Vector3 positionOffset;
    public Vector3 rotationOffset;
    private GunScript shooter;

    // Start is called before the first frame update
    void Start()
    {
        //transform.SetPositionAndRotation(follower.position, follower.rotation);
        transform.Translate(positionOffset);
        transform.Rotate(rotationOffset);

        shooter = GameObject.Find("Essence Shooter").GetComponent<GunScript>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.SetPositionAndRotation(follower.position, follower.rotation);
        transform.Translate(positionOffset);
        transform.Rotate(rotationOffset);

        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (/*Input.GetKeyDown("return") && */Physics.Raycast(transform.position + positionOffset, transform.forward + positionOffset, out hit, Mathf.Infinity))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);

            switch (hit.collider.tag)
            {
                case "WATER":
                    shooter.ChangeGunState(State.WATER);
                    break;

                case "NATURE":
                    shooter.ChangeGunState(State.NATURE);
                    break;

                case "FIRE":
                    shooter.ChangeGunState(State.FIRE);
                    break;

                default:
                    break;
            }
        }
    }
}
