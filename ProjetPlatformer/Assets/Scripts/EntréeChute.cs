using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class EntréeChute : MonoBehaviour
{

    public ParticleSystem particuesEntree;
    public GameObject mainCamera;
    public Tween tweener;

    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("GrosseBoîte"))
        {
            tweener = mainCamera.transform.DOShakePosition(1.5f,10,10,35,true);
            particuesEntree.Play();
            Destroy(gameObject);
        }
    }
}
