using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float lifeTimeSeconds = 3;
    // Start is called before the first frame update

    void Start()
    {
        Destroy(gameObject, lifeTimeSeconds);
    }

    // Update is called once per frame
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collision: " + collision.gameObject.name);
        if (collision.gameObject.tag == "Enemy")
            Destroy(gameObject);
    }
}
