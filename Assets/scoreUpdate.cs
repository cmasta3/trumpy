using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Global {
    public static int score;
    public static int toms;
    public static int health;
    public static bool active;

    public static bool startAud;
    public static bool endAud;
    public static bool soundByte;

    public static int highScore;
    public static int lastScore;
}

public class scoreUpdate : MonoBehaviour
{
    public int startHealth = 3;

    public GameObject trump;
    public Text gameScore;
    public Text hScore;
    public Text pScore;
    public GameObject sgGUI;

    void Start()
    {
        Global.active = false;
        gameScore = GetComponent<Text>();
        Global.score = 0;
        Global.health = startHealth;
        Global.toms = 0;
    }

    void Update()
    {
        gameScore.text = "Score: " + Global.score.ToString() + "\nHow many Toms? : " + Global.toms.ToString();
        if(Global.health <= 0 && Global.active)
        {
            Global.active = false;
            StartCoroutine(Lose());
        }

        if ((Global.score%100) == 0 && Global.score != 0)
            Global.soundByte = true;

    }

    void reset()
    {
        sgGUI.SetActive(true);
        hScore.text = "High Score: " + Global.highScore;
        pScore.text = "Previous Score:" + Global.lastScore;
        Global.endAud = true;
    }

    IEnumerator Lose()
    {
        
        trump.GetComponent<SpriteRenderer>().color = Color.red;
        Global.lastScore = Global.score;
        if (Global.score > Global.highScore)
            Global.highScore = Global.score;
        yield return new WaitForSeconds(1f);
        reset();
    }
    
}
