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
    public bool saFaitDeLaLumière = false;

    [Header("Position de départ et fin des platformes")]
    public GameObject EndValueX;
    public GameObject StartValueX;
    
    private float endValueX;
    private float startValueX;
    public bool floating;
    private bool endMove;

    public float timeToArrive;
    
    private float y0;
    private Vector2 temp;
    public float amplitudeFloating;
    public float vitesseFloating;
    
    [Header("Animation Curve")]
    public AnimationCurve CourbeDeFlamme;
    public UnityEngine.Rendering.Universal.Light2D Flamme;
    private float graph, increment;
    private bool canRunGame = false;
    private bool stopWakeUp;

    private void Awake()
    {
        if (isMovingAlone == true)
        {
            endValueX = EndValueX.transform.position.y;
            gameObject.transform.DOMoveY(endValueX, timeToArrive);
        }
    }

    private void Update()
    {
        if (floating)
        {
            if (endMove)
            {
               // floatingScript.enabled = true;
                temp = transform.position;
                y0 = transform.position.y;
                temp.y = y0 + amplitudeFloating *Mathf.Sin(vitesseFloating*Time.time);
                transform.position = temp;
            }
        }
        
        if (canRunGame)
        {
            if (Flamme is null || CourbeDeFlamme is null) return;
            Flamme.intensity = 2;
            increment += Time.deltaTime;
            graph = CourbeDeFlamme.Evaluate(increment);
            Flamme.intensity = graph;
        }
        else
        {
            if (Flamme is null || CourbeDeFlamme is null) return;
            Flamme.intensity = graph;
            increment = 0;
            graph = CourbeDeFlamme.Evaluate(increment);
            Flamme.intensity = graph;
        }
    }

    public void Salope()
    {
        if(isMovingWithTrigger == true )
        {
            endValueX = EndValueX.transform.position.y;
            //gameObject.transform.DOMove(position, timeToArrive);
            gameObject.transform.DOMoveY(endValueX, timeToArrive).OnComplete(() => endMove = true);
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (saFaitDeLaLumière)
        {
            canRunGame = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) // quand la platforme revien
    {
        if (isMovingWithThePlayer == true)
        {
            startValueX = StartValueX.transform.position.x;
            gameObject.transform.DOMoveX(startValueX, timeToArrive);
        }
        if (saFaitDeLaLumière)
        {
            StartCoroutine(WaitForTheLight());
        }
    }

    IEnumerator WaitForTheLight()
    {
        yield return new WaitForSeconds(1f);
        canRunGame = false;
    }
}
