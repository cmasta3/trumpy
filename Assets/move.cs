using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class move : MonoBehaviour
{
	public int moveSpd = 10;
    //public int rotSpd = 5;
    Vector2 _initPos;
    //Quaternion _initRot;
    AudioSource aud;
    SpriteRenderer sptRender;
    string collided;

    public AudioClip start;
    public AudioClip end;
    public AudioClip beep;
    public AudioClip sb1;
    public AudioClip sb2;
    public AudioClip sb3;
    public AudioClip sb4;
    public AudioClip sb5;
    public AudioClip sb6;

    float rand;

    Vector2 mousePos;

    void Awake()
    {
        _initPos = transform.position;
        //_initRot = transform.rotation;
        aud = GetComponent<AudioSource>();
        sptRender = GetComponent<SpriteRenderer>();
    }

    void Update()
    {

        if (Input.GetMouseButton(0))
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if(mousePos.x > transform.position.x)
                transform.Translate(Vector2.right * moveSpd * Time.deltaTime);
            if(mousePos.x < transform.position.x)
                transform.Translate(Vector2.left * moveSpd * Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.RightArrow))
            	transform.Translate(Vector2.right*moveSpd*Time.deltaTime);
        if(Input.GetKey(KeyCode.LeftArrow))
        	    transform.Translate(Vector2.left*moveSpd*Time.deltaTime);

        //transform.rotation = Quaternion.Slerp(transform.rotation, _initRot, rotSpd * Time.deltaTime);

      if(transform.position.y < -5)
        {
            transform.position = _initPos;
            aud.clip = beep;
            aud.Play();
            if (Global.active)
                Global.health--;
        }

        if (Global.startAud)
        {
            aud.volume = 0.5f;
            aud.clip = start;
            aud.Play();
            Global.startAud = false;
        }

        if (Global.endAud)
        {
            aud.volume = 0.5f;
            aud.clip = end;
            aud.Play();
            Debug.Log("audio");
            Global.endAud = false;
        }

        if (Global.soundByte)
        {
            rand = Random.value;
            if(rand >= 0 && rand < 0.15)
            {
                aud.volume = 0.5f;
                aud.clip = sb1;
                aud.Play();
                Global.soundByte = false;
            }
            if(rand >= 0.15 && rand < 0.30)
            {
                aud.volume = 1.0f;
                aud.clip = sb2;
                aud.Play();
                Global.soundByte = false;
            }
            if(rand >= 0.30 && rand < 0.45)
            {
                aud.volume = 0.5f;
                aud.clip = sb3;
                aud.Play();
                Global.soundByte = false;
            }
            if (rand >= 0.45 && rand < 0.60)
            {
                aud.volume = 0.5f;
                aud.clip = sb4;
                aud.Play();
                Global.soundByte = false;
            }
            if (rand >= 0.60 && rand < 0.75)
            {
                aud.volume = 0.5f;
                aud.clip = sb5;
                aud.Play();
                Global.soundByte = false;
            }
            if (rand >= 0.75 && rand < 0.90)
            {
                aud.volume = 0.5f;
                aud.clip = sb6;
                aud.Play();
                Global.soundByte = false;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        collided = col.gameObject.name;
        Debug.Log("collided: " + collided);
        if (collided.Contains("tomato"))
        {
            StartCoroutine(Splat());
            aud.volume = 0.05f;
            aud.clip = beep;
            aud.Play();
            Global.health--;
        }
    }

    IEnumerator Splat()
    {
        sptRender.color = Color.red;
        yield return new WaitForSeconds(0.5f);
        sptRender.color = Color.white;
    }
}