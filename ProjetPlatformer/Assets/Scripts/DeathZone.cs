using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using XInputDotNetPure;


public class DeathZone : MonoBehaviour
{
    public int respawn;
    public Animator anim;
    [SerializeField] CameraZoom Camera;
    
    private Transform playerSpawn;
    private Animator fadeSystem;
    public GameObject nuage;
    public Camera mainCamera;
    

    public Animator playerAnimator;
    private bool verif = false;
    
    PlayerIndex playerIndex;
    GamePadState state;
    GamePadState prevState;
    
    [Header("Vibration Motor")]
    public float leftMotor;
    public float rightMotor;
    public float duration;

    private void Awake()
    {
        playerSpawn = GameObject.FindGameObjectWithTag("PlayerSpawn").transform;
        fadeSystem = GameObject.FindGameObjectWithTag("DeathFade").GetComponent<Animator>();
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player"))
        {
            //Camera.isMoving = false;
            StartCoroutine(ReplacePlayer(collision));
            CharacterMovement.instance.canMove = false;
            CharacterMovement.instance.canJump = false;
            CharacterMovement.instance.speed = 0;
        }
    }
    

    public IEnumerator ReplacePlayer(Collider2D collision)
    {
        playerAnimator.SetTrigger("Die");
        StartCoroutine(VibrationTime());
        yield return new WaitForSeconds(1);
        fadeSystem.SetTrigger("FadeIn");

        collision.transform.position = playerSpawn.position;
        nuage.transform.position = new Vector3(mainCamera.transform.position.x - 999, 0, 0);
        

        //FeuxDeCamp.instanceFeuxdeCamp.LeFeuxDeCamp();
        //FeuxDeCamp.instanceFeuxdeCamp.onoff = false;
        
        
        //FeuxDeCamp.instanceFeuxdeCamp.OnOff();
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
    
    IEnumerator VibrationTime()
    {
        GamePad.SetVibration(playerIndex, leftMotor, rightMotor);
        yield return new WaitForSeconds(duration);
        GamePad.SetVibration(playerIndex, 0, 0);
    }
}

