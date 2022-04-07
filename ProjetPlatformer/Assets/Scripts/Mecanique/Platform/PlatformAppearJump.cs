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
            //renderer.enabled = false;
            coll.enabled = false;
        }
        else
        {
            //renderer.enabled = true;
            coll.enabled = true;
        }
    }
    
    private void Update()
    {
        if (CharacterMovement.instance.isJumpingSingle == true)
        {
            if(isVisible)
            {
                isVisible = false;
                gameObject.transform.DOScale(new Vector3(0, 0, 0), 0.1f);
                //renderer.enabled = false;
                coll.enabled = false;
            }
            else
            {
                isVisible = true;
                gameObject.transform.DOScale(new Vector3(1, 1, 0), 0.1f);
                //renderer.enabled = true;
                coll.enabled = true;
            }
        }
    }
}

