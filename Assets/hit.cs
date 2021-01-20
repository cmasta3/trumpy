using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hit : MonoBehaviour
{
    private SpriteRenderer sptRender;
    public Sprite splatSpt;
    AudioSource splat;
    public float scaleChg = 0.3f;
    Collider2D colliBuddz;
    string collision;

    void Start()
    {
        splat = GetComponent<AudioSource>();
        sptRender = gameObject.GetComponent<SpriteRenderer>();
        colliBuddz = gameObject.GetComponent<CircleCollider2D>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        //Debug.Log("hit");
        collision = col.gameObject.name;
        if (!collision.Contains("tomato"))
        {
            sptRender.sprite = splatSpt;
            splat.Play();
            colliBuddz.enabled = !colliBuddz.enabled;
            StartCoroutine(Splat());
        }
    }

    IEnumerator Splat()
    {
        
        for (float i = 0; i <= scaleChg; i += 0.1f)
        {
            transform.localScale += new Vector3(i, i, i);
            Color c = sptRender.color;
            c.a -= scaleChg;
            sptRender.color = c;
            yield return new WaitForSeconds(0.05f);
        }
        if(Global.active)
            Global.score++;
        Destroy(gameObject);
        Global.toms--;
    }
}
