 using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MovingPlatform : MonoBehaviour
{
    public bool isMovingAlone = false;
    public bool isMovingWithThePlayer = false;
    public bool isMovingWithTrigger = false;

    [Header("Position de départ et fin des platformes")]
    public GameObject EndValueX;
    public GameObject StartValueX;
    
    private float endValueX;
    private float startValueX;

    public float timeToArrive;

    private void Awake()
    {
        if (isMovingAlone == true)
        {
            endValueX = EndValueX.transform.position.y;
            gameObject.transform.DOMoveY(endValueX, timeToArrive);
        }
    }

    public void Salope()
    {
        if(isMovingWithTrigger == true )
        {
            endValueX = EndValueX.transform.position.y;
            //gameObject.transform.DOMove(position, timeToArrive);
            gameObject.transform.DOMoveY(endValueX, timeToArrive);
        }
    }


    private void OnTriggerStay2D(Collider2D other)
    {
        if (isMovingWithThePlayer == true)
        {
            endValueX = EndValueX.transform.position.x;
            gameObject.transform.DOMoveX(endValueX, timeToArrive);
        }
    }
    
    private void OnTriggerExit2D(Collider2D other) // quand la platforme revien
    {
        if (isMovingWithThePlayer == true)
        {
            startValueX = StartValueX.transform.position.x;
            gameObject.transform.DOMoveX(startValueX, timeToArrive);
        }
    }
}
