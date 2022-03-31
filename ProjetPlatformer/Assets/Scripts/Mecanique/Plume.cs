using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.Mathematics;
using UnityEditor.Sprites;
using UnityEngine;

public class Plume : MonoBehaviour
{
    public float timeToRespawn = 3f;
    private SpriteRenderer renderer;
    private Collider2D coll;
    public Animator anim;

    private void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        coll = GetComponent<Collider2D>();
    }

    private void Update()
    {
        transform.DOMove(transform.position + new Vector3(0, 0.9f, 0), 2)
            .OnComplete((() =>
                transform.DOMove(transform.position - new Vector3(0, 0.9f, 0), 2)
                    .OnComplete((() => transform.DOMove(transform.position + new Vector3(0, 0.9f, 0), 2)))));

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            CharacterMovement.instance.extrajumps += 1;
            StartCoroutine(TimeToRespawn());
            anim.SetBool("isDoubleJumping", false);
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
