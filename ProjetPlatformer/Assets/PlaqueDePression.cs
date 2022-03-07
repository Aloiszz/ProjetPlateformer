using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class PlaqueDePression : MonoBehaviour
{
    public float timer;
    public float timerMax;
    public float speedPorte;
    public GameObject porteAssociée;
    private bool boolStop = false;

    private void Update()
    {
        if (boolStop == true)
        {
            OuverturePorte();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        OuverturePorte();
    }

    private void OuverturePorte()
    {
        boolStop = true;
        Debug.Log("zar");
        timer += Time.deltaTime;
        if (timer <= timerMax)
        {
            porteAssociée.transform.position = Vector3.MoveTowards(porteAssociée.transform.position, Vector3.up,
                speedPorte * Time.deltaTime);
           
        }

        if (timer >= timerMax)
        {
            boolStop = false;
        }
    }
    
}
