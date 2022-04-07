using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlatformAppearJump : MonoBehaviour
{
    public bool isVisible;

    private SpriteRenderer renderer;
    private Collider2D coll;
    

    private void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        coll = GetComponent<Collider2D>();
        
        if (isVisible == false)
        {
            renderer.enabled = false;
            coll.enabled = false;
        }
        else
        {
            renderer.enabled = true;
            coll.enabled = true;
        }
    }
    
    private void Update()
    {
        if (CharacterMovement.instance.isJumpingSingle == true)
        {
            if(isVisible)
            {
                // faire le doScale
                isVisible = false;
                renderer.enabled = false;
                coll.enabled = false;
            }
            else
            {
                isVisible = true;
                renderer.enabled = true;
                coll.enabled = true;
            }
        }
    }
}

