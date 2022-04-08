using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
 

public class tutoPlanage : MonoBehaviour
{
    public Animator animTuto;
    public Animator animTuto2;
    public bool fadeIn;



    private void OnTriggerEnter2D(Collider2D other)
    {
        if(fadeIn)
        {
            animTuto.SetBool("FadeIn", true);
            animTuto.SetBool("FadeOut", false);
            
            animTuto2.SetBool("FadeIn2", true);
            animTuto2.SetBool("FadeOut2", false);
        }
        else
        {
            animTuto.SetBool("FadeOut", true);
            animTuto.SetBool("FadeIn", false);
            
            animTuto2.SetBool("FadeOut2", true);
            animTuto2.SetBool("FadeIn2", false);
        }
    }
}
    
   
