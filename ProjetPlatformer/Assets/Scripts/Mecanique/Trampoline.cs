using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Trampoline : MonoBehaviour
{
    public Rigidbody2D rb;
    public Rigidbody2D rbBoite;
    public float forceX;
    public float forceBoite;
    public float forceBonus;
    private KeyCode saut = KeyCode.Space;
    private bool Jumps;
    private bool sautVrai;
    public float forceShake;
    public float forceShakeBonus;
    public GameObject mainCamera;
    public Tweener tweener;
    public CharacterMovement cm;


   /* void Update()
    {
        if (Input.GetKeyDown(saut) && sautVrai)
        {
            Jumps = true;
        }
    }*/

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Jumps == false)
            {
                //      StartCoroutine(cameraShake.Shake(0.1f, forceShake));
                rb.velocity = new Vector2(0,forceX);
                tweener = mainCamera.transform.DOShakePosition(0.1f,forceShake,2,30,false,false);
                if (cm.extrajumps == 0)
                {
                    cm.extrajumps += cm.extraJumpsValue;
                }
                
            }
            else
            {
             //   StartCoroutine(cameraShake.Shake(0.1f, forceShakeBonus));
                rb.velocity = new Vector2(0,forceBonus); 
                tweener = mainCamera.transform.DOShakePosition(0.1f,forceShakeBonus,2,30,false,false);
            }
        }

        if (other.gameObject.CompareTag("Respawn"))
        {
            rbBoite.velocity = new Vector2(0,forceBoite);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        sautVrai = true;
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        Jumps = false;
        sautVrai = false;
    }
    
}
