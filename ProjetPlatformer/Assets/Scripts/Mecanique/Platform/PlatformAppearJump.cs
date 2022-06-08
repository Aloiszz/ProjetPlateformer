using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlatformAppearJump : MonoBehaviour
{
    public bool isVisible;
    public Animator AnimatorPlatform;

    private SpriteRenderer renderer;
    private Collider2D coll;

    public AudioSource AudioData;

    private void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
        coll = GetComponent<Collider2D>();
        
        if (isVisible == false)
        {
            renderer.enabled = false;
            coll.enabled = false;
            AnimatorPlatform.SetBool("isVisible", false);
        }
        else
        {
            renderer.enabled = true;
            coll.enabled = true;
            AnimatorPlatform.SetBool("isVisible", true);
        }
    }
    
    private void Update()
    {
        if (CharacterMovement.instance.isJumpingSingle == true)
        {
            if(isVisible)
            {
                isVisible = false;
                AnimatorPlatform.SetBool("isVisible", isVisible);
                //gameObject.transform.DOScale(new Vector3(0, 0, 0), 0.1f);
                //renderer.enabled = false;
                coll.enabled = false;
            }
            else
            {
                isVisible = true;
                AnimatorPlatform.SetBool("isVisible", isVisible);
                //gameObject.transform.DOScale(new Vector3(1, 1, 0), 0.1f);
                renderer.enabled = true;
                coll.enabled = true;
                AudioData.Play();
            }
        }
    }
}

