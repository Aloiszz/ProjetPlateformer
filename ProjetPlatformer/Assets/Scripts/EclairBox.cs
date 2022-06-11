using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EclairBox : MonoBehaviour
{
    public bool isInStorm = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isInStorm = true;
        }
    }
}
