using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PontQuiSecroulle : MonoBehaviour
{
    public bool isNotSimulated;


    public TriggerPontQuiSeBrise trigger;
    
    public Rigidbody2D rb;
    public HingeJoint2D hingeJoint;
    
    public static PontQuiSecroulle instancePont;

    // public GameObject mainCamera;
  //  private Tween tweener;
    private void Awake()
    {
        if (instancePont == null) instancePont = this;
        
        rb = GetComponent<Rigidbody2D>();
        hingeJoint = GetComponent<HingeJoint2D>();
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        gameObject.GetComponent<PontQuiSecroulle>().enabled = true;
        
        hingeJoint.enabled = false;
        rb.gravityScale = 0;
        if (isNotSimulated)
        {
            
        }
    }

    private void Update()
    {
        if (trigger.isTriggered == true)
        {
          //  tweener = mainCamera.transform.DOShakePosition(1.5f,5,1,35,false);
            hingeJoint.enabled = true;
            rb.gravityScale = 1;
            rb.simulated = true;
            rb.angularVelocity = 0f;
        }
    }
}
