using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Parchemin : MonoBehaviour
{
    public ParcheminManager2 pm;
    public ParticleSystem particulesParchemin;

    public AudioSource AudioData;
   

    private Collider2D coll;
    
    void Start()
    {
        coll = GetComponent<BoxCollider2D>();
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            AudioData.Play();
            //particulesParchemin2.Play();
            particulesParchemin.Play();
        
            gameObject.transform.DOScale(new Vector3(0, 0, 0), 0.5f);
            gameObject.transform.DORotate(new Vector3(0, 0, -180), 0.8f);
            //gameObject.transform.DOMove()
            coll.enabled = false;
            
            pm.AddParchemin();
        }
       
    }
}
