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

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(saut) && sautVrai)
        {
            Jumps = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (Jumps == false)
        {
            Debug.Log("ouystyty");
           rb.velocity = new Vector2(0,forceX);
        }
        else
        {
            rb.velocity = new Vector2(0,forceBonus); }
       
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
