using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ruche : MonoBehaviour
{

    public KeyCode Interaction;
    public bool IsReloaded = true;
    public RangeRuche range;
    public GameObject goutteMiel;
    private float timerReload;
    public float timeForReload;

    private void Update()
    {

        if (range.IsAtRange == false)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.green;
        }
        
        if (range.IsAtRange)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
            if (Input.GetKeyDown(Interaction) && IsReloaded)
            {
                Instantiate(goutteMiel, transform.position, transform.rotation);
                IsReloaded = false;
            }
        }

        if (IsReloaded == false)
        {
            timerReload += Time.deltaTime;
            if (timerReload >= timeForReload)
            {
                IsReloaded = true;
                timerReload = 0;
            }
        }
        
    }
}
