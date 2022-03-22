using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using DG.Tweening;
using UnityEngine;

public class PlaqueDePression : MonoBehaviour
{
    private float timer;
    public float DistancePorteMax;
    public float speedPorte;
    public GameObject porteAssociée;
    public GameObject porteAssociée2;
    public GameObject porteAssociée3;
    private bool boolStop = false;
    public bool plusieursPortes;

    private void Update()
    {
        if (boolStop == true)
        {
            OuverturePorte();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Respawn")
        {
            OuverturePorte(); 
        }
    }

    private void OuverturePorte()
    {
        transform.DOMove(transform.position + new Vector3(0,-0.1f,0), 1);
        boolStop = true;
        timer += Time.deltaTime;
        if (timer <= DistancePorteMax)
        {
            porteAssociée.transform.position = Vector3.MoveTowards(porteAssociée.transform.position, porteAssociée.transform.position + Vector3.up,
                speedPorte * Time.deltaTime);

            if (plusieursPortes)
            {
                porteAssociée2.transform.position = Vector3.MoveTowards(porteAssociée2.transform.position, porteAssociée2.transform.position + Vector3.up,
                    speedPorte * Time.deltaTime);
                
                porteAssociée3.transform.position = Vector3.MoveTowards(porteAssociée3.transform.position, porteAssociée3.transform.position + Vector3.up,
                    speedPorte * Time.deltaTime);
            }

            
        }

        if (timer >= DistancePorteMax)
        {
            boolStop = false;
        }
    }
    
}
