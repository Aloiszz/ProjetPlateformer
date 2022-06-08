using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;

public class Plume : MonoBehaviour
{
    public float timeToRespawn = 3f;
    private SpriteRenderer renderer;
    private Collider2D coll;


    private void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        coll = GetComponent<Collider2D>();
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            CharacterMovement.instance.extrajumps += 1;
            StartCoroutine(TimeToRespawn());
        }
    }

    IEnumerator TimeToRespawn()
    {
        renderer.enabled = false;
        coll.enabled = false;
        yield return new WaitForSeconds(timeToRespawn);
        renderer.enabled = true;
        coll.enabled = true;
    }
}
