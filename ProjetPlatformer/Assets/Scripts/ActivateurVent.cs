using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

public class ActivateurVent : MonoBehaviour
{
    public GameObject wind;
    public bool activateur;
   


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (activateur == true)
        {
            StartCoroutine(waitWind());
        }
        else
        {
            wind.SetActive(false);
        }
    }

    IEnumerator waitWind()
    {
        yield return new WaitForSeconds(0.01f);
        wind.SetActive(true);
    }
}
