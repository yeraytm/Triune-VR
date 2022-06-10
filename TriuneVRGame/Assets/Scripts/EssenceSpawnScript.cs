using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EssenceSpawnScript : MonoBehaviour
{
    public float spawningTime = 5.0f;

    class EssenceSource
    {
        public EssenceSource()
        {
            this.source = null;
            this.active = false;
        }

        public EssenceSource(GameObject source, bool active, State type)
        {
            this.source = source;
            this.active = active;
            this.type = type;
        }

        public void Active(bool act)
        {
            source.SetActive(act);
            active = act;
        }

        public GameObject source = null;
        public bool active = false;
        public State type = State.EMPTY;
    }

    List<EssenceSource> waterTriggers = new List<EssenceSource>();
    List<EssenceSource> fireTriggers = new List<EssenceSource>();
    List<EssenceSource> natureTriggers = new List<EssenceSource>();

    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform t in transform.Find("Water Trigger").transform)
        {
            t.gameObject.SetActive(false);
            waterTriggers.Add(new EssenceSource(t.gameObject, false, State.WATER));
        }
        foreach (Transform t in transform.Find("Fire Trigger").transform)
        {
            t.gameObject.SetActive(false);
            fireTriggers.Add(new EssenceSource(t.gameObject, false, State.FIRE));
        }
        foreach (Transform t in transform.Find("Nature Trigger").transform)
        {
            t.gameObject.SetActive(false);
            natureTriggers.Add(new EssenceSource(t.gameObject, false, State.NATURE));
        }

        Spawn(State.WATER);
        Spawn(State.WATER);
        Spawn(State.NATURE);
        Spawn(State.NATURE);
        Spawn(State.FIRE);
        Spawn(State.FIRE);
    }

    void Spawn(State state)
    {
        bool end = true;
        EssenceSource source = new EssenceSource();

        switch (state)
        {
            case State.WATER:
                while (end)
                {
                    source = waterTriggers[Random.Range(0, 6)];
                    end = source.active;
                }
                break;

            case State.FIRE:
                while (end)
                {
                    source = fireTriggers[Random.Range(0, 6)];
                    end = source.active;
                }
                break;

            case State.NATURE:
                while (end)
                {
                    source = natureTriggers[Random.Range(0, 6)];
                    end = source.active;
                }
                break;

            default:
                return;
        }

        source.Active(true);
    }

    void Dispawn(Transform transf, State state)
    {
        switch (state)
        {
            case State.WATER:
                foreach (EssenceSource eS in waterTriggers)
                {
                    if (eS.source.transform == transf)
                    {
                        eS.Active(false);
                        break;
                    }
                }
                break;

            case State.FIRE:
                foreach (EssenceSource eS in fireTriggers)
                {
                    if (eS.source.transform == transf)
                    {
                        eS.Active(false);
                        break;
                    }
                }
                break;

            case State.NATURE:
                foreach (EssenceSource eS in natureTriggers)
                {
                    if (eS.source.transform == transf)
                    {
                        eS.Active(false);
                        break;
                    }
                }
                break;

            default:
                break;

        }
    }

    public IEnumerator Respawn(Transform transf, State state)
    {
        Dispawn(transf, state);

        yield return new WaitForSeconds(spawningTime);

        Spawn(state);
    }
}