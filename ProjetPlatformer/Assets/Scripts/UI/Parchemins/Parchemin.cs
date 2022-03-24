using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parchemin : MonoBehaviour
{
    public ParcheminManager pm;
    public ParticleSystem particulesParchemin;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
            pm.getParchemin1 = true;
            particulesParchemin.Play(true);
            gameObject.SetActive(false);
        
    }
}
