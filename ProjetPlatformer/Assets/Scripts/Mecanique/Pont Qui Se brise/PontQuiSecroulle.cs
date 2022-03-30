using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PontQuiSecroulle : MonoBehaviour
{
    public bool isNotSimulated;


    public TriggerPontQuiSeBrise trigger;
    
    private Rigidbody2D rb;
    private HingeJoint2D hingeJoint;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        hingeJoint = GetComponent<HingeJoint2D>();
        
        if (isNotSimulated)
        {
            hingeJoint.enabled = false;
            rb.gravityScale = 0;
        }
    }

    private void Update()
    {
        if (trigger.isTriggered == true)
        {
            Debug.Log("ICI");
            hingeJoint.enabled = true;
            rb.gravityScale = 1;
        }
    }
}
