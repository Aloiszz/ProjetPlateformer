using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PorteRuines : MonoBehaviour
{
    
    public GameObject porteAssociée;
    private bool boolStop;
    public float timer;
    public float DistancePorteMax;
    public float speedPorte;
    public GameObject mainCamera;
    public GameObject particulesAssociées;
    public Tween tweener;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            if (boolStop == false)
            {
                OuverturePorte();
                Debug.Log("ssamef");
            }
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
            
            tweener = mainCamera.transform.DOShakePosition(DistancePorteMax,5,1,20,false);

           // particulesAssociées.SetActive(true);
        }

        if (timer >= DistancePorteMax)
        {
            boolStop = false;
        //    particulesAssociées.SetActive(false);
        }
    }
}
