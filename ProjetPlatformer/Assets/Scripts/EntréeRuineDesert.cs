using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EntréeRuineDesert : MonoBehaviour
{
    public GameObject plateforme;
    public Tilemap TilemapFadeOut;
    public Animator anim;
    public Animator animPlayer;
    public ParticleSystem particulesBrisePlateforme;
    private Tween tweener;
    public GameObject MainCamera;

    public CharacterMovement player;
    
    [Header("Camera")] public CameraZoom Camera;
    public bool isCameraFix; // a cocher si l'on veut que la camera ne bouge plus 
    public Vector3 EmplacementCamera = new Vector3(5,0,-10); /* permet d'établir une nouvelle position pour la camera (déplacement), Attention: l'emplacement est un peu bugger
    on établie le nouvel emplacement en fonction de l'emplacement du trigger et non celui du localScale de l'éditeur */

    //public float EmplacementCameraX;
    //public float EmplacementCameraY;
    
    [Header("modification camera")]
    public float distanceTarget = 9.999f; // permet d'établir la distance entre target et camera, plus la valeur est grande plus l'objet est loin
    public float dezoomSpeed = 2f; // permet d'ajuster sur la vitesse de la caméra pour dézoomer ou zoomer
    public float smoothSpeed = 2f;


    private void OnTriggerEnter2D(Collider2D other)
    {
        StartCoroutine(BriserPlateforme());
    }

    IEnumerator BriserPlateforme()
    {
        CharacterMovement.instance.canMove = false;
        CharacterMovement.instance.canJump = false;
        CharacterMovement.instance.speed = 0;
        animPlayer.Rebind();
        animPlayer.Play("Player_Idle");
        tweener = MainCamera.transform.DOShakePosition(2,0.14f,10,40,false,false);
        Camera.smoothSpeed = dezoomSpeed;
        Camera.targetOrtho = 5;
        Camera.smoothSpeed = smoothSpeed;
        Camera.EmplacementCamera = EmplacementCamera;
        EmplacementCamera = new Vector3(0, 0, -10);
        Camera.EmplacementCamera = EmplacementCamera;
        yield return new WaitForSeconds(2f);
        anim.SetBool("IsFadeOut",true);
        Camera.smoothSpeed = smoothSpeed;
        yield return new WaitForSeconds(0.7f);
        plateforme.SetActive(false);
        particulesBrisePlateforme.Play();
        Camera.smoothSpeed = 999;
        yield return new WaitForSeconds(0.5f);
        animPlayer.Play("Player_Jump_LandingHard");
        yield return new WaitForSeconds(1f);
        CharacterMovement.instance.canMove = true;
        CharacterMovement.instance.canJump = true;
        CharacterMovement.instance.speed = 11;
        

    }
}
