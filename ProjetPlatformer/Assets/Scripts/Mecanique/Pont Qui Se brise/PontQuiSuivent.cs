using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

public class PontQuiSuivent : MonoBehaviour
{
    
    public TriggerPontQuiSeBrise trigger;
    

    public Rigidbody2D rb;
    public HingeJoint2D hingeJoint;
    
    public static PontQuiSuivent instancePontQuiSuivent;

    // public GameObject mainCamera;
    //  private Tween tweener;
    private void Awake()
    {
        if (instancePontQuiSuivent == null) instancePontQuiSuivent = this;
        
        rb = GetComponent<Rigidbody2D>();
        hingeJoint = GetComponent<HingeJoint2D>();
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        gameObject.GetComponent<PontQuiSuivent>().enabled = true;
        
        hingeJoint.enabled = false;
        rb.gravityScale = 0;
    }

    private void Update()
    {
        if (trigger.isTriggered == true)
        {
            //  tweener = mainCamera.transform.DOShakePosition(1.5f,5,1,35,false);
            hingeJoint.enabled = true;
            rb.gravityScale = 1;
            rb.simulated = true;
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;
        }
    }
}
