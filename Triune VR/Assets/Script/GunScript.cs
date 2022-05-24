using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public enum State
    {
        EMPTY,
        FIRE,
        WATER,
        NATURE
    }

    //Public
    [Header("Gun Positioning")]
    public Transform follower;
    public Vector3 offset;

    [Header("Gun Textures")]
    public Texture2D emptyTexture;
    public Texture2D fireTexture;
    public Texture2D waterTexture;
    public Texture2D natureTexture;

    [Header("Bullet")]
    public GameObject firePrefab;
    public GameObject waterPrefab;
    public GameObject naturePrefab;
    public float force = 12;

    [Header("Gun State")]
    public State state = State.EMPTY;

    // Private
    private MeshRenderer meshRender;
    private bool charged = false;

    // Functions
    void Start()
    {
        transform.SetPositionAndRotation(follower.position, follower.rotation);
        transform.Translate(offset);

        meshRender = gameObject.GetComponent<MeshRenderer>();

        ChangeGunState(state);
    }

    void Update()
    {
        transform.SetPositionAndRotation(follower.position, follower.rotation);
        transform.Translate(offset);

        if (Input.GetKey("0")) ChangeGunState(State.EMPTY);
        if (Input.GetKey("1")) ChangeGunState(State.FIRE);
        if (Input.GetKey("2")) ChangeGunState(State.WATER);
        if (Input.GetKey("3")) ChangeGunState(State.NATURE);
        if (charged && Input.GetKey("return")) Shot(state);
    }

    void ChangeGunState(State s)
    {
        switch (s)
        {
            case State.EMPTY:
                meshRender.material.mainTexture = emptyTexture;
                charged = false;
                break;
            case State.FIRE:
                meshRender.material.mainTexture = fireTexture;
                charged = true;
                break;
            case State.WATER:
                meshRender.material.mainTexture = waterTexture;
                charged = true;
                break;
            case State.NATURE:
                meshRender.material.mainTexture = natureTexture;
                charged = true;
                break;
        }

        state = s;
    }

    void Shot(State s)
    {
        Vector3 bulletPosition = new Vector3(transform.position.x + 2, transform.position.y + 0.25f, transform.position.z);

        GameObject bulletInstance = null;

        switch (s)
        {
            case State.FIRE:
                bulletInstance = Instantiate(firePrefab, bulletPosition, transform.rotation);
                break;
            case State.WATER:
                bulletInstance = Instantiate(waterPrefab, bulletPosition, transform.rotation);
                break;
            case State.NATURE:
                bulletInstance = Instantiate(naturePrefab, bulletPosition, transform.rotation);
                break;
            default:
                Debug.Log("Error: An empty shot occured");
                break;
        }

        Rigidbody rB = bulletInstance.GetComponent<Rigidbody>();
        rB.AddForce(transform.forward * force * 200);

        ChangeGunState(State.EMPTY);
    }
}
