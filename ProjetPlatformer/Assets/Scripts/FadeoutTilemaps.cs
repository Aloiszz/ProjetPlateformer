using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Tilemaps;

public class FadeoutTilemaps : MonoBehaviour
{
    public Animator anim;
 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            anim.SetBool("FadeOut", true);
            anim.SetBool("FadeIn", false);
            Debug.Log("oui");
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            anim.SetBool("FadeIn", true);
            anim.SetBool("FadeOut", false);
        }
    }
}
