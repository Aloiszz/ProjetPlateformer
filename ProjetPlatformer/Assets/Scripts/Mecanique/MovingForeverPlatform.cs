using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingForeverPlatform : MonoBehaviour
{

    private Rigidbody2D rb;
    public Rigidbody2D rbPlayer;
    public float DeplacementY;
    public float DeplacementX;
    public CharacterMovement cm;
    public bool PlayerFollow; 
    
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(DeplacementX, DeplacementY);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player") || PlayerFollow)
        {
            rbPlayer.velocity = new Vector2(DeplacementX, DeplacementY);
        }
    }
}
