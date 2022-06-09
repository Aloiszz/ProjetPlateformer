using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Runtime.Serialization.Json;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class GlobalLightEntreRuine : MonoBehaviour
{
    public Light2D globalLight;
    public bool isActive = false;


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            isActive = true;
        }
    }
    
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            isActive = false;
        }
    }
    
    private void Update()
    {
        if (isActive)
        {
            if (globalLight.intensity <= 1.5f && globalLight.intensity >= 0f)
            {
                Debug.Log("True");
                globalLight.intensity -= 0.4f;
            }
        }
        
    }
}
