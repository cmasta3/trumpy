using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthBar : MonoBehaviour
{

    private SpriteRenderer sptRdr;
    public Sprite full;
    public Sprite oneHit;
    public Sprite twoHit;
    public Sprite dead;

    void Start()
    {
        sptRdr = gameObject.GetComponent<SpriteRenderer>();
        sptRdr.sprite = full;
    }

    void Update()
    {
        if (Global.health <= 0 && Global.active)
        {
            sptRdr.sprite = dead;
        }
        else
        {
            if (Global.health >= 3)
            {
                sptRdr.sprite = full;
            }
            else
            {
                switch (Global.health)
                {
                    case 2:
                        sptRdr.sprite = oneHit;
                        break;
                    case 1:
                        sptRdr.sprite = twoHit;
                        break;
                    case 0:
                        sptRdr.sprite = dead;
                        break;
                }
            }
        }
    }
}
