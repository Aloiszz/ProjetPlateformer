using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class AnimationIconeParch : MonoBehaviour
{
    public bool NewParchemin;
    public Animator anim;
    
    private void Update()
    {
        anim = gameObject.GetComponent<Animator>();
        
        if (NewParchemin)
        {
            anim.SetBool("NewParch", true);
        }
        else
        {
            anim.SetBool("NewParch", false);
        }
    }
    
}
