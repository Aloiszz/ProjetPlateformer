using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PontQuiSecroulle : MonoBehaviour
{
    public bool isNotSimulated;


    public TriggerPontQuiSeBrise trigger;
    
    private Rigidbody2D rb;
    private HingeJoint2D hingeJoint;

   // public GameObject mainCamera;
  //  private Tween tweener;
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
          //  tweener = mainCamera.transform.DOShakePosition(1.5f,5,1,35,false);
            Debug.Log("ICI");
            hingeJoint.enabled = true;
            rb.gravityScale = 1;
        }
    }
}
