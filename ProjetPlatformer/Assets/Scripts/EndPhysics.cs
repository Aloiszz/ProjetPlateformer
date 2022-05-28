using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class EndPhysics : MonoBehaviour
{
    private bool inRange = false;
    public GameObject Player;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            inRange = true;
        }
    }

    private void Update()
    {
        if (inRange)
        {
            CharacterMovement.instance.rb.velocity = new Vector2(0 , -5);
            
        }
    }
}
