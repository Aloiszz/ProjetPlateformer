using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RalentissementMonstres : MonoBehaviour
{
    public Rigidbody2D rb;
    public bool monstreSlowed;
    public float slowValue;
    public float timeSlowed;
    private float timerSlowed;
    

    void OnCollisionEnter2D (Collision2D other)
    {
        if (other.gameObject.tag == "Goutte") 
        {
        monstreSlowed = true; 
        }
    }

    private void Update()
    {
        if (monstreSlowed) 
        {
        rb.velocity = rb.velocity * slowValue; 
        timerSlowed += Time.deltaTime;
            if (timerSlowed >= timeSlowed)
            {
                monstreSlowed = false;
                timerSlowed = 0;
            }
        }
    }
}
