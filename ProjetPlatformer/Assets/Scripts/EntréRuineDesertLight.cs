using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class EntréRuineDesertLight : MonoBehaviour
{
    
    public Light2D globalLight;
    public bool isInRange;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            isInRange = false;
        }
    }

    private void Update()
    {
        if (isInRange)
        {
            globalLight.intensity = 0;
            /*if (globalLight.intensity >= 0f)
            {
                globalLight.intensity -= 0.4f * Time.deltaTime;
            }*/
        }
        else
        {
            if (globalLight.intensity <= 1f)
            {
                globalLight.intensity += 0.4f * Time.deltaTime;
            }
        }
    }
}
