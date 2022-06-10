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

    public TriggerApparitionBackgroundTempête Trigger;

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
            if (globalLight.intensity >= 0f)
            {
                globalLight.intensity -= 0.4f;
            }
        }
        else
        {
            if (globalLight.intensity <= 1)
            {
                globalLight.intensity += 0.4f * Time.deltaTime;
                if (Trigger.startSound)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
