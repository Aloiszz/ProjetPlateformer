using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//using XInputDotNetPure;


public class DeathZone : MonoBehaviour
{
    public int respawn;
    public Animator anim;
    [SerializeField] CameraZoom Camera;
    
    private Transform playerSpawn;
    private Animator fadeSystem;
    public GameObject nuage;
    public Camera mainCamera;
    public static bool isDying;
    

    public Animator playerAnimator;
    private bool verif = false;
    
   /* PlayerIndex playerIndex;
    GamePadState state;
    GamePadState prevState;*/
    
    [Header("Vibration Motor")]
    public float leftMotor;
    public float rightMotor;
    public float duration;
    
    [Header("-------Sound------")] 
    public AudioSource source;
    public AudioClip Mort;

    private void Awake()
    {
        playerSpawn = GameObject.FindGameObjectWithTag("PlayerSpawn").transform;
        fadeSystem = GameObject.FindGameObjectWithTag("DeathFade").GetComponent<Animator>();
    }

    IEnumerator IsDying()
    {
        yield return new WaitForSeconds(0.1f);
        isDying = true;
        yield return new WaitForSeconds(2f);
        isDying = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(IsDying());
            if (isDying == false)
            {
                source.PlayOneShot(Mort);
                //Camera.isMoving = false;
                StartCoroutine(ReplacePlayer(collision));
                CharacterMovement.instance.canMove = false;
                CharacterMovement.instance.canJump = false;
                CharacterMovement.instance.speed = 0; 
            }
        }
    }
    

    public IEnumerator ReplacePlayer(Collider2D collision)
    {
        playerAnimator.SetTrigger("Die");
      //  StartCoroutine(VibrationTime());
        yield return new WaitForSeconds(0.6f);
        
        

        //FeuxDeCamp.instanceFeuxdeCamp.LeFeuxDeCamp();
        //FeuxDeCamp.instanceFeuxdeCamp.onoff = false;
        
        
        //FeuxDeCamp.instanceFeuxdeCamp.OnOff();
        FeuxDeCamp.instanceFeuxdeCamp.GoToCamp();
        
        fadeSystem.SetTrigger("FadeIn");
        
        yield return new WaitForSeconds(0.2f);
        playerAnimator.SetBool("IsFdC", true);
        yield return new WaitForSeconds(0.1f);
        playerAnimator.SetTrigger("SortieFdC");
        playerAnimator.SetBool("IsFdC", false);

        collision.transform.position = playerSpawn.position;
        nuage.transform.position = new Vector3(mainCamera.transform.position.x - 999, 0, 0);
        Camera.transform.position = new Vector3(playerSpawn.position.x, playerSpawn.position.y, -10);
        
        CharacterMovement.instance.speed = 0;
        CharacterMovement.instance.canMove = false;
        CharacterMovement.instance.canJump = false;
        
        anim.SetBool("isGrounded", true);
        
        yield return new WaitForSeconds(0.8f);
        CharacterMovement.instance.speed = 11;
        CharacterMovement.instance.canMove = true;
        CharacterMovement.instance.canJump = true;
        
        if (CharacterMovement.instance.facingRight == false)
        {
            CharacterMovement.instance.Flip();
        }
    }
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CharacterMovement.instance.rb.velocity = new Vector2(0,-0.5f);
        }
    }
    /*
    IEnumerator VibrationTime()
    {
        Debug.Log("hello world");
        GamePad.SetVibration(playerIndex, leftMotor, rightMotor);
        yield return new WaitForSeconds(duration);
        GamePad.SetVibration(playerIndex, 0, 0);
        Debug.Log("hello world dONE");
    }*/
}

