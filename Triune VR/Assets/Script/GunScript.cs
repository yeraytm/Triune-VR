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

    public Transform follower;

    public Texture2D emptyTexture;
    public Texture2D fireTexture;
    public Texture2D waterTexture;
    public Texture2D natureTexture;

    private MeshRenderer meshRender;

    public Vector3 offset;

    public State state = State.EMPTY;

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
    }

    void ChangeGunState(State s)
    {
        switch (s)
        {
            case State.EMPTY:
                meshRender.material.mainTexture = emptyTexture;
                break;
            case State.FIRE:
                meshRender.material.mainTexture = fireTexture;
                break;
            case State.WATER:
                meshRender.material.mainTexture = waterTexture;
                break;
            case State.NATURE:
                meshRender.material.mainTexture = natureTexture;
                break;
        }

        state = s;
    }
}
