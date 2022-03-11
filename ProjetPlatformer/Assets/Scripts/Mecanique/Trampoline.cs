using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    public Rigidbody2D rb;
    public float forceX;
    public float forceBonus;
    private KeyCode saut = KeyCode.Space;
    private bool Jumps;
    private bool sautVrai;
    public CameraShake cameraShake;
    public float forceShake;
    public float forceShakeBonus;


    void Update()
    {
        if (Input.GetKeyDown(saut) && sautVrai)
        {
            Jumps = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Jumps == false)
            {
                StartCoroutine(cameraShake.Shake(0.1f, forceShake));
                rb.velocity = new Vector2(0,forceX);
                
            }
            else
            {
                StartCoroutine(cameraShake.Shake(0.1f, forceShakeBonus));
                rb.velocity = new Vector2(0,forceBonus); }
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
