using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TpPlateforme : MonoBehaviour
{
    public float valeurTP;
    
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        other.transform.position += new Vector3(0,valeurTP,0);
    }
}
