using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgroMonstre1 : MonoBehaviour
{

    public bool isAgro;
    public IAMonstre1 ia;
    
    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            isAgro = true;
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player" && ia.isCharging == false)
        {
            isAgro = false;
        }
    }
}
