using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SpawnPlatform : MonoBehaviour
{
    public GameObject nouvellePlatformTrigger;
    public GameObject nouvellePlatform;
    public bool isNotVisble;

    //public Animator animSpawn;

    private void Awake()
    {
        if (isNotVisble)
        {
            isNotVisble = GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        nouvellePlatformTrigger.SetActive(true);
        //platformActuel.transform.DOScale(2, 2);
        //platformActuel.GetComponent<SpriteRenderer>().color;
        
        //animSpawn.SetTrigger("Spawn");
    }
}
 