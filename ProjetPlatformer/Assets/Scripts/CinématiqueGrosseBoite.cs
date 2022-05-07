using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

public class CinématiqueGrosseBoite : MonoBehaviour
{
    
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
        if (other.tag == "GrosseBoîte")
        {
            StartCoroutine(Cinématique());
        }
    }


    IEnumerator Cinématique()
    {
        CharacterMovement.instance.canMove = false;
        CharacterMovement.instance.canJump = false;
        CharacterMovement.instance.speed = 0;
        yield return new WaitForSeconds(0.3f);
        Camera.smoothSpeed = dezoomSpeed;
        Camera.targetOrtho = distanceTarget;
        Camera.smoothSpeed = smoothSpeed;
        Camera.EmplacementCamera = EmplacementCamera;
        yield return new WaitForSeconds(3f);
        EmplacementCamera = new Vector3(10, -12, -10);
        distanceTarget = 16;
        Camera.targetOrtho = distanceTarget;
        Camera.EmplacementCamera = EmplacementCamera;
        yield return new WaitForSeconds(1.5f);
        CharacterMovement.instance.canMove = true;
        CharacterMovement.instance.canJump = true;
        CharacterMovement.instance.speed = 11;
    }
}
