using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PorteRuines : MonoBehaviour
{
    
    public GameObject porteAssociée;
    private bool boolStop;
    private float timer;
    public float DistancePorteMax;
    public float speedPorte;
    public GameObject mainCamera;
    public GameObject particulesAssociées;
    private Tween tweener;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (boolStop == true)
        {
            OuverturePorte();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            OuverturePorte();
        }
    }
    
    private void OuverturePorte()
    {
        boolStop = true;
        
        if (timer <= DistancePorteMax)
        {
            timer += Time.deltaTime;
            porteAssociée.transform.position = Vector3.MoveTowards(porteAssociée.transform.position, porteAssociée.transform.position + Vector3.up,
                speedPorte * Time.deltaTime);
            
            tweener = mainCamera.transform.DOShakePosition(DistancePorteMax,3,1,15,false);

           // particulesAssociées.SetActive(true);
        }

        if (timer >= DistancePorteMax)
        {
            boolStop = false;
        //    particulesAssociées.SetActive(false);
        }
    }
}
