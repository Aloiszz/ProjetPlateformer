using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZonePiliers : MonoBehaviour
{
    [Header ("Porte")]
    public float timer;
    public float DistancePorteMax;
    public float speedPorte;
    public GameObject porteAssociée;
    private bool boolStop = false;
    
    public FermetureSalle2 codeTrigger;
    public GameObject trigger;

    private void Update()
    {
        if (boolStop == true)
        {
            OuverturePorte();
        }
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            codeTrigger.activationFrappe = false;
            gameObject.SetActive(true);
            OuverturePorte();
            codeTrigger.index = 0;
            trigger.transform.position -= new Vector3(60, 0, 0);
        }
    }
    

    private void OuverturePorte()
    {
        boolStop = true;
        timer += Time.deltaTime;
        if (timer <= DistancePorteMax)
        {
            porteAssociée.transform.position = Vector3.MoveTowards(porteAssociée.transform.position, porteAssociée.transform.position + Vector3.up,
                speedPorte * Time.deltaTime);
        }
        else if (timer >= DistancePorteMax)
        {
            timer = 0;
            boolStop = false;
        }
    }
}
