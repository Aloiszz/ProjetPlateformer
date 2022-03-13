using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SpawnPlatform : MonoBehaviour
{
    [Tooltip("ici renseigner les trigger des platformes que vous voullez faire apparaitre")] 
    public List<GameObject> makeAppearPlatform; 

    public bool isNotVisble;

    private void Awake()
    {
        if (isNotVisble)
        {
            isNotVisble = GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        for (int i = 0; i < makeAppearPlatform.Count; i++)
        {
            makeAppearPlatform[i].SetActive(true);
        }
    }
}
 