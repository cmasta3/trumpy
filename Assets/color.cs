using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class color : MonoBehaviour
{
    private void OnMouseDown(){
    	GetComponent<SpriteRenderer>().color = Color.red;
    }
    
    private void OnMouseUp(){
    	GetComponent<SpriteRenderer>().color = Color.white;
    }
}
