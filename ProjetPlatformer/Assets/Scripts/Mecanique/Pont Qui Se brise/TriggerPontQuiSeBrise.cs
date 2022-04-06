using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class TriggerPontQuiSeBrise : MonoBehaviour
{
    public bool isTriggered;

    public GameObject mainCamera;
    public Tween tweener;
    public float strengh;
    public int vibration;
    public float randomness;


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isTriggered = true;
            tweener = mainCamera.transform.DOShakePosition(8.4f,strengh,vibration,randomness,false,false);
        }
        
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isTriggered = false;
        }
        
    }
}
