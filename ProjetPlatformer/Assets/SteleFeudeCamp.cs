using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteleFeudeCamp : MonoBehaviour
{
    public Material shader;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("oui"); 
            shader.SetColor("_Color", new Color(255,255,255,255));
        }
        
    }
}
