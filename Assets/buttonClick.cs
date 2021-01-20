using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonClick : MonoBehaviour
{
    public GameObject sgGUI;
    public GameObject button;
    public GameObject trump;

    public float b = 0.3f; // button scale increase when pressed

    void OnButtonPress()
    {
        button.transform.localScale += new Vector3(b, b, b);
        trump.GetComponent<SpriteRenderer>().color = Color.white;
        sgGUI.SetActive(false);
        StartGame();
    }

    void StartGame()
    {
        //yield return new WaitForSeconds(0.1f);
        button.transform.localScale -= new Vector3(b, b, b);
        Global.score = 0;
        Global.toms = 0;
        Global.health = 3;
        Global.active = true;
        Global.startAud = true;
    }
}
