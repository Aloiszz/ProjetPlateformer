using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Tilemaps;

public class FadeoutTilemaps : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            GetComponent<TilemapRenderer>().material.DOFade(0, 1);
            Debug.Log("hello");
        }
        
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            GetComponent<TilemapRenderer>().material.DOFade(255, 1);
        }
        
    }
}
