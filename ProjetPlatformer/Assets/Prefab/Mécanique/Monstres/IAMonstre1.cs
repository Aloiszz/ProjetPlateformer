using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class IAMonstre1 : MonoBehaviour
{

    public AgroMonstre1 agroscript;
    public float speed;
    public Transform target;
    public bool exclamationDone;
    public bool isCharging;
    private Vector2 direction;
    public Rigidbody2D rb;


    void Update()
    {
        if (agroscript.isAgro == true)
        {
            if (exclamationDone == false && isCharging == false)
            {
                transform.DOMoveY(transform.position.y + 0.8f, 0.3f).OnComplete(() =>
                    transform.DOMoveY(transform.position.y - 0.8f, 0.3f));
                        exclamationDone = true;
            }
        }

        if (agroscript.isAgro == false)
        {
            exclamationDone = false;
        }

        if (exclamationDone)
        {
            StartCoroutine(Charge());
        }
        
    }

    IEnumerator Charge()
    {
        yield return new WaitForSeconds(2.5f);
        isCharging = true;

        rb.velocity = new Vector3(-target.position.x, 0, 0);
        //transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.position.x, transform.position.y, transform.position.z) , speed*Time.deltaTime);
    }

}


     




