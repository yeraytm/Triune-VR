using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State
{
    EMPTY,
    FIRE,
    WATER,
    NATURE
}

public class GunScript : MonoBehaviour
{
    //Public
    [Header("Gun Parameters")]
    public float speed = 40;
    public Transform barrel;
    //public AudioSource audioSource;
    //public AudioClip audioClip;

    [Header("Gun Textures")]
    public Texture2D emptyTexture;
    public Texture2D fireTexture;
    public Texture2D waterTexture;
    public Texture2D natureTexture;

    [Header("Bullet")]
    public GameObject firePrefab;
    public GameObject waterPrefab;
    public GameObject naturePrefab;

    [Header("Gun State")]
    public State state = State.EMPTY;

    // Private
    private MeshRenderer meshRender;
    private bool charged = false;

    // Functions
    void Start()
    {
        meshRender = gameObject.GetComponent<MeshRenderer>();

        ChangeGunState(state);
    }

    void Update()
    {
        //if (Input.GetKey("0")) ChangeGunState(State.EMPTY);
        //if (Input.GetKey("1")) ChangeGunState(State.FIRE);
        //if (Input.GetKey("2")) ChangeGunState(State.WATER);
        //if (Input.GetKey("3")) ChangeGunState(State.NATURE);
        //if (charged && Input.GetKey("return")) Shot(state);
        Debug.Log(speed);
        Debug.Log(barrel.forward);
    }

    public void ChangeGunState(State s)
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

    public void Shot()
    {
        GameObject spawnedBullet = null;

        switch (state)
        {
            case State.FIRE:
                spawnedBullet = Instantiate(firePrefab, barrel.position, barrel.rotation);
                break;
            case State.WATER:
                spawnedBullet = Instantiate(waterPrefab, barrel.position, barrel.rotation);
                break;
            case State.NATURE:
                spawnedBullet = Instantiate(naturePrefab, barrel.position, barrel.rotation);
                break;
            default:
                Debug.Log("Error: An empty shot occured");
                break;
        }

        if (state != State.EMPTY)
        {
            spawnedBullet.GetComponent<Rigidbody>().velocity = speed * barrel.forward;
            //audioSource.PlayOneShot(audioClip);
            Destroy(spawnedBullet, 3);
            //ChangeGunState(State.EMPTY);
        }
    }
}
