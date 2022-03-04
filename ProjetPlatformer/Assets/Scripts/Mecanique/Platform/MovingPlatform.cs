using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MovingPlatform : MonoBehaviour
{
    public bool isMovingAlone = false;
    public bool isMovingBecause = false;

    private void Awake()
    {
        if (isMovingAlone == true)
        {
            gameObject.transform.DOMoveX(20, 10);
        }
    }
}
