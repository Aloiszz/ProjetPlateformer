using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMovingPlatform : MonoBehaviour
{
    
    public List<MovingPlatform> movingPlatform;
    //private MovingPlatform movingPlatform;

    private int limit = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (limit <= 0)
        {
            limit++;
            for (int i = 0; i < movingPlatform.Count; i++)
            {
                movingPlatform[i].Salope();
            }
        }
    }
}
