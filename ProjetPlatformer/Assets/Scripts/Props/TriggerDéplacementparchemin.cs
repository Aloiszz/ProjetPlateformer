using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEditor;

public class TriggerDéplacementparchemin : MonoBehaviour
{
    public bool isTriggered;
    public GameObject Parchemin;
    public GameObject ParcheminSpot;
    public float durationToArrive;
    
    private int limit = 0;


    private void OnTriggerEnter2D(Collider2D other)
    {
        isTriggered = true;
        
        if (limit <= 0)
        {
            limit++;
            
            Parchemin.transform.DOMove(ParcheminSpot.transform.position, durationToArrive).SetEase(Ease.OutCubic);
             
        }
    }
    
}
