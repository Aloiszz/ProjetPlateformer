using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class DeathZone : MonoBehaviour
{
    public int respawn;
    public Animator anim;
    [SerializeField] CameraZoom Camera;
    
    private Transform playerSpawn;
    private Animator fadeSystem;

    public Animator playerAnimator;

    private bool verif = false;

    private void Awake()
    {
        playerSpawn = GameObject.FindGameObjectWithTag("PlayerSpawn").transform;
        fadeSystem = GameObject.FindGameObjectWithTag("DeathFade").GetComponent<Animator>();
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player"))
        {
            Camera.isMoving = false;
            StartCoroutine(ReplacePlayer(collision));
        }
    }

    private void Update()
    {
        
    }

    public IEnumerator ReplacePlayer(Collider2D collision)
    {
        playerAnimator.SetTrigger("Die");
        yield return new WaitForSeconds(1);
        fadeSystem.SetTrigger("FadeIn");

        collision.transform.position = playerSpawn.position;
        //FeuxDeCamp.instanceFeuxdeCamp.LeFeuxDeCamp();
        //FeuxDeCamp.instanceFeuxdeCamp.onoff = false;
        
        FeuxDeCamp.instanceFeuxdeCamp.OnOff();
        FeuxDeCamp.instanceFeuxdeCamp.GoToCamp();
        


        playerAnimator.SetBool("IsFdC", true);
        
        yield return new WaitForSeconds(0.2f);
        anim.SetBool("isGrounded", true);
        
        if (CharacterMovement.instance.facingRight == false)
        {
            CharacterMovement.instance.Flip();
        }
    }
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CharacterMovement.instance.rb.velocity = Vector2.down;
        }
    }
}

