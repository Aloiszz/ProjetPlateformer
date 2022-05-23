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
    public GameObject Barre2;
    public GameObject Barre1;
    public float DistanceBarres;
    public float DistanceBarres2;

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
        float newPosPage1 = Barre1.transform.position.y - DistanceBarres;
        float newPosPage2 = Barre2.transform.position.y - DistanceBarres2;
        yield return new WaitForSeconds(0.8f);
        Barre1.transform.DOMove(new Vector3(Barre1.transform.position.x,-newPosPage1,Barre1.transform.position.z), 1.5f);
        Barre2.transform.DOMove(new Vector3(Barre2.transform.position.x,newPosPage2,Barre2.transform.position.z), 1.5f);
        tweener = MainCamera.transform.DOShakePosition(2,0.1f,20,40,false,false);
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
        Camera.smoothSpeed = 10;
        yield return new WaitForSeconds(0.5f);
        animPlayer.Play("Player_Jump_LandingHard");
        yield return new WaitForSeconds(1f);
        float newPosPage3 = Barre1.transform.position.y + DistanceBarres;
        float newPosPage4 = Barre2.transform.position.y + DistanceBarres2;
        Barre1.transform.DOMove(new Vector3(Barre1.transform.position.x,newPosPage3,Barre1.transform.position.z), 1.5f);
        Barre2.transform.DOMove(new Vector3(Barre2.transform.position.x,newPosPage4,Barre2.transform.position.z), 1.5f);
        CharacterMovement.instance.canMove = true;
        CharacterMovement.instance.canJump = true;
        CharacterMovement.instance.speed = 11;
        

    }
}
