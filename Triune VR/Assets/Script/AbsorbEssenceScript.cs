using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbsorbEssenceScript : MonoBehaviour
{
    public GameObject leftController;
    public GameObject rightController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(leftController.transform.position, leftController.transform.forward, out hit, Mathf.Infinity))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            //Debug.Log("Did Hit");

            switch (hit.collider.tag)
            {
                case "WATER":
                    break;

                case "NATURE":
                    break;

                case "FIRE":
                    break;

                default:
                    break;
            }
        }
    }
}
