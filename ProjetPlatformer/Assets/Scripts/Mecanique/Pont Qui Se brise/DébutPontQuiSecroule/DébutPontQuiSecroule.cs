using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DébutPontQuiSecroule : MonoBehaviour
{
    public bool isNotSimulated;
    public TriggerPontQuiSecroule trigger;
    
    
    public Rigidbody2D rb;
    public HingeJoint2D hingeJoint;
    
    public static DébutPontQuiSecroule instancePont;
    
    public ParticleSystem particules;
    public GameObject particulesPoint;
    
    private void Awake()
    {
        if (instancePont == null) instancePont = this;
        
        rb = GetComponent<Rigidbody2D>();
        hingeJoint = GetComponent<HingeJoint2D>();
        gameObject.GetComponent<PolygonCollider2D>().enabled = true;
        gameObject.GetComponent<DébutPontQuiSecroule>().enabled = true;
        
        hingeJoint.enabled = false;
        rb.gravityScale = 0;
    }

    private void Update()
    {
        if (trigger.isTriggered == true)
        {
            hingeJoint.enabled = true;
            rb.gravityScale = 1;
            rb.simulated = true;
            rb.angularVelocity = 0f;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag != "Player")
        {
            
            ParticleSystem dustWalk = Instantiate(particules, particulesPoint.transform.position, particulesPoint.transform.rotation);
            particules.Play();
        }
    }
}
