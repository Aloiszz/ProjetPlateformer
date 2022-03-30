using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPontQuiSeBrise : MonoBehaviour
{
    public bool isTriggered;


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isTriggered = true;
        }
        
    }
}
