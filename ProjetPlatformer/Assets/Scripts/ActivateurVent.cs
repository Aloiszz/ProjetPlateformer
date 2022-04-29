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
            wind.SetActive(true);
        }
        else
        {
            wind.SetActive(false);
        }
    }
}
