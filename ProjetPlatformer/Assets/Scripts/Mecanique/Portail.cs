using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portail : MonoBehaviour
{
    public GameObject deuxiemePortail;
    public GameObject player;

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        StartCoroutine(TimeToAccessLocation());


    }

    IEnumerator TimeToAccessLocation()
    {
        yield return new WaitForSeconds(0.2f);
        player.transform.position = deuxiemePortail.transform.position;
    }
}
