using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public float maxX = 7f;
    public float prob = 0.7f;
    public float delay = 0.5f; //delay between checks in seconds

    float refTime;
    float x;
    float y;
    float randT;
    float thresh; //actual likelihood of spawning a tomato per check
    float tMod; //score modifier to thresh
    float diff;

    Vector2 pos;
    Vector2 _initPos;

    public GameObject tomatoFab;
    public GameObject tomato;

    void Start()
    {
        refTime = Time.time;
        _initPos = transform.position;
        y = _initPos.y;
    }

    void Update()
    {
        if (Global.active)
        {
            if (timeCheck(delay))
            {
                if (randoCheck())
                {
                    moveSpawner();
                    spawnIt();
                    //StartCoroutine(TerstNet());
                }
            }
        }
    }

    bool randoCheck()
    {
        randT = Random.value;
        //Debug.Log("Rando: " + randT);
        tMod = prob + (float)Global.score/100;
        if(randT < tMod)
            return true;
        return false;
    }

	void moveSpawner()
    {
        transform.position = new Vector2(Random.Range(maxX, -maxX), _initPos.y);
        //Debug.Log("X pos: " + transform.position.x + " Y pos: " + transform.position.y);
    }

    void spawnIt()
    {
        //Debug.Log("Toms: " + Global.toms);
        tomato = Instantiate(tomatoFab, transform);
        Global.toms++;
        transform.DetachChildren();
        //Debug.Log("Toms: " + Global.toms);
    }

    bool timeCheck(float d)
    {
        diff = Time.time - refTime;

        d -= (float)Global.score / 100;

        if (d < 0.1)
            d = 0.1f;

        if (diff > d)
        {
            refTime = Time.time;
            return true;
        }
        return false;

    }

    IEnumerator TerstNet()
    {
        for(int i = 0; i < 2; i++)
        {
            transform.position = new Vector2(i, 3);
            tomato = Instantiate(tomatoFab, transform);
            Global.toms++;
            transform.DetachChildren();
            yield return new WaitForSeconds(0.5f);
        }
    }
}
