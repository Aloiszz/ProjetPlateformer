using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Parchemin : MonoBehaviour
{
    public ParcheminManager pm;
    public ParticleSystem particulesParchemin;
    public ParticleSystem particulesParchemin2;

    private Collider2D coll;
    
    void Start()
    {
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {   
       // pm.getParchemin1 = true;
       particulesParchemin2.Play();
        particulesParchemin.Play();
        
        gameObject.transform.DOScale(new Vector3(0, 0, 0), 0.5f);
        coll.enabled = false;
    }
}
