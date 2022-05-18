using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using XInputDotNetPure;

public class FinDeNiveau : MonoBehaviour
{
    
    PlayerIndex playerIndex;
    GamePadState state;
    GamePadState prevState;
    private bool doOnce;
    
    public GameObject MainCamera;
    public GameObject Barre2;
    public GameObject Barre1;
    public GameObject Player;
    public GameObject emptyCinématique;
    public float DistanceBarres;
    public float DistanceBarres2;
    public Animator animPlayer;
    
    [Header("Vibration Motor")]
    public float leftMotor;
    public float rightMotor;
    public float duration;
    
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
        if (other.tag == "Player")
        {
            StartCoroutine(CinématiqueFindeNiveau());
        }
    }

    IEnumerator CinématiqueFindeNiveau()
    {
        CharacterMovement.instance.canMove = false;
        CharacterMovement.instance.canJump = false;
        CharacterMovement.instance.speed = 0;
        float newPosPage1 = Barre1.transform.position.y - DistanceBarres;
        float newPosPage2 = Barre2.transform.position.y - DistanceBarres2;
        Barre1.transform.DOMove(new Vector3(Barre1.transform.position.x,-newPosPage1,Barre1.transform.position.z), 1.5f);
        Barre2.transform.DOMove(new Vector3(Barre2.transform.position.x,newPosPage2,Barre2.transform.position.z), 1.5f);
        animPlayer.Rebind();
        animPlayer.SetBool("IsWalking", true);
        animPlayer.Play("Player_Walk",-1,0f);
        CharacterMovement.instance.animator.SetBool("IsWalking",true);
        Camera.smoothSpeed = dezoomSpeed;
        Camera.targetOrtho = 5;
        Camera.smoothSpeed = smoothSpeed;
        Camera.EmplacementCamera = EmplacementCamera;
        EmplacementCamera = new Vector3(0, 0, -10);
        Camera.EmplacementCamera = EmplacementCamera;
        Player.transform.DOMoveX(emptyCinématique.transform.position.x, 5);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(1);
        GamePad.SetVibration(playerIndex, 0, 0);
    }
}
