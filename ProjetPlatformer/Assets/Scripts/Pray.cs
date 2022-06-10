using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Pray : MonoBehaviour
{
    public bool isInRange = false;
    public bool onoff = false;
    
    public ParticleSystem psFleur;
    public GameObject Player;
    public Animator anim;
    
    
    [Header("Camera")]
    [SerializeField] CameraZoom Camera;
    public bool isCameraFix;
    public GameObject EmplacementCamera; 
    
    [Header("modification camera")]
    public float distanceTarget = 9.999f; 
    public float dezoomSpeed = 2f; 
    public float smoothSpeed = 2f;
    public float Timer = 0.8f;
    
    [Header("Camera DE Base")]
    public GameObject EmplacementCameraDeBase; 
    
    [Header("modification camera")]
    public float distanceTargetBase = 9.999f; 
    public float dezoomSpeedBase = 2f; 
    public float smoothSpeedBase = 2f;
    public float TimerBase = 0.8f;

    [Header("Audio Source")]
    public AudioSource audioData;


    [Header("Light")] 
    public List<Light2D> premierDieu;
    public List<Light2D> deuxiemeDieu;
    public List<Light2D> troisiemeDieu;
    public List<Light2D> haloLumière;
    
    [Header("Animation Curve")]
    public AnimationCurve premierDieuAnimation;
    public AnimationCurve deuxiemeDieuAnimation;
    public AnimationCurve troisiemeDieuAnimation;
    public AnimationCurve haloLumièreAnimation;
    
    private float graph, increment;
    private bool canRunGame;
    private bool stopWakeUp;
    
    private float graph2, increment2;
    private bool canRunGame2;
    private bool stopWakeUp2;
    
    private float graph3, increment3;
    private bool canRunGame3;
    private bool stopWakeUp3;

    private float graph4, increment4;
    private bool canRunGame4;
    private bool stopWakeUp4;
    

    [Header("NE PAS TOUCHER")] 
    public Transform playerMoveToPray;


    public void Update()
    {
        if (isInRange)
        {
            if (Input.GetButtonDown("GrabGamepad"))
            {
                onoff = !onoff;
                if (onoff)
                {
                    PrayForTheGods();
                }
                /*else
                {
                    LeaveTheGods();
                }*/
                
            }
        }
        
        
        if (canRunGame4)
        {
            for (int i = 0; i < haloLumière.Count; i++)
            {
                haloLumière[i].intensity = 1;
                increment4 += Time.deltaTime;
                graph4 = haloLumièreAnimation.Evaluate(increment4);
                haloLumière[i].intensity = graph4;
            }
            
        }
    }

    public void PrayForTheGods()
    {
        Player.transform.DOMove(playerMoveToPray.transform.position, 0.5f);
        
        if (CharacterMovement.instance.facingRight == false)
        {
            CharacterMovement.instance.Flip();
        }
        
        //psFleur.Play();
        SetPlayer(true);
        SetAnimator(true);

        StartCoroutine(PrayTheGodsCinematic());
        StartCoroutine(LightBackground());
        

        /*if (!onoff) // Quitter le lieux de prière 
        {
            LeaveTheGods();
        }*/
    }

    public void LeaveTheGods()
    {
        StartCoroutine(LeaveTheGodsCinematic());
        SetAnimator(false);

        Camera.smoothSpeed = dezoomSpeedBase;
        Camera.targetOrtho = distanceTargetBase;
        Camera.smoothSpeed = smoothSpeedBase;
        
        Camera.EmplacementCamera = EmplacementCamera.transform.position;
        Camera.transform.DOMove(EmplacementCameraDeBase.transform.position,Timer).SetEase(Ease.OutQuart);//OutQuart
        Camera.isMoving = true;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            isInRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            isInRange = false;
        }
    }
    
    public void SetPlayer(bool verif)
    {
        if (verif) // arriver dans le feux de camp
        {
            CharacterMovement.instance.canJump = false;
            CharacterMovement.instance.speed = 0;
            CharacterMovement.instance.canMove = false;
        }
        else // départ du feux de camp
        {
            CharacterMovement.instance.canJump = true;
            CharacterMovement.instance.speed = 11;
            CharacterMovement.instance.canMove = true;
        }
        
    }
    public void SetAnimator(bool verif)
    {
        if (verif) // arriver dans le feux de camp
        {
            anim.SetBool("isPraying" , true);
        }
        else // départ du feux de camp
        {
            anim.SetBool("isPraying" , false);
        }
    }



    IEnumerator PrayTheGodsCinematic()
    {
        Camera.smoothSpeed = dezoomSpeed;
        Camera.targetOrtho = distanceTarget;
        Camera.smoothSpeed = smoothSpeed;
        
        if (isCameraFix == true) 
        {
            Camera.EmplacementCamera = EmplacementCamera.transform.position;
            Camera.transform.DOMove(EmplacementCamera.transform.position,Timer).SetEase(Ease.OutQuart);
            Camera.isMoving = true;
            StartCoroutine(SleepCameraFixTrue());
                
        }
        
        yield return new WaitForSeconds(10);
        //yield return new WaitForSeconds(5);
        Camera.transform.DOKill();
        LeaveTheGods();
    }

    IEnumerator LeaveTheGodsCinematic()
    {
        yield return new WaitForSeconds(3);
        SetPlayer(false);
    }

    IEnumerator LightBackground()
    {
        yield return new WaitForSeconds(5);
        canRunGame4 = true;
    }

    IEnumerator SleepCameraFixTrue() // permet d'attendre 0.1 seconde
    {
        yield return new WaitForSeconds(0.3f);
        
    }
    
    IEnumerator SleepCameraFixFalse() // permet d'attendre 0.1 seconde
    {
        yield return new WaitForSeconds(0.15f);
        Camera.isMoving = false;
    }
}
