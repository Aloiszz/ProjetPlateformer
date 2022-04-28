using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class FermetureSalle : MonoBehaviour
{
    public float timer;
    public float DistancePorteMax;
    public float speedPorte;
    public GameObject porteAssociée;
    public GameObject porteAssociée2;
    public GameObject porteAssociée3;
    private bool boolStop = false;
    public bool plusieursPortes;
    private Tween tweener;
    public GameObject particulesAssociées;
    public bool particules;
    public GameObject vent;
    public GameObject player;
    
    [SerializeField] CameraZoom Camera;
    
    [Header("Camera")]
    public bool isCameraFix; // a cocher si l'on veut que la camera ne bouge plus 
    public Vector3 EmplacementCamera = new Vector3(5,0,-10); /* permet d'établir une nouvelle position pour la camera (déplacement), Attention: l'emplacement est un peu bugger
    on établie le nouvel emplacement en fonction de l'emplacement du trigger et non celui du localScale de l'éditeur */

    //public float EmplacementCameraX;
    //public float EmplacementCameraY;
    
    [Header("modification camera")]
    public float distanceTarget = 9.999f; // permet d'établir la distance entre target et camera, plus la valeur est grande plus l'objet est loin
    public float dezoomSpeed = 2f; // permet d'ajuster sur la vitesse de la caméra pour dézoomer ou zoomer
    public float smoothSpeed = 2f;
    
    
    private void Update()
    {
        if (boolStop == true)
        {
            FermeturePorte();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            FermeturePorte(); 
            vent.SetActive(false);
            Cinematique();
        }
    }

    private void Cinematique()
    {
        StartCoroutine(CinematiqueCam());
    }

    IEnumerator CinematiqueCam()
    {
        CharacterMovement.instance.canMove = false;
        CharacterMovement.instance.canJump = false;
        CharacterMovement.instance.speed = 0;
        yield return new WaitForSeconds(2f);
        Camera.smoothSpeed = dezoomSpeed;
        Camera.targetOrtho = distanceTarget;
        Camera.smoothSpeed = smoothSpeed;
        Camera.EmplacementCamera = EmplacementCamera;
        yield return new WaitForSeconds(4f);
        EmplacementCamera = new Vector3(0, 2, -10);
        distanceTarget = 11;
        Camera.targetOrtho = distanceTarget;
        Camera.EmplacementCamera = EmplacementCamera;
        yield return new WaitForSeconds(1.5f);
        CharacterMovement.instance.canMove = true;
        CharacterMovement.instance.canJump = true;
        CharacterMovement.instance.speed = 11;
        gameObject.SetActive(false);
    }
    
    private void FermeturePorte()
    {
        boolStop = true;
        timer += Time.deltaTime;
        if (timer <= DistancePorteMax)
        {
            porteAssociée.transform.position = Vector3.MoveTowards(porteAssociée.transform.position, porteAssociée.transform.position + Vector3.left,
                speedPorte * Time.deltaTime);
            
            if (particules)
            {
                particulesAssociées.SetActive(true);
            }
            
            if (plusieursPortes)
            {
                porteAssociée2.transform.position = Vector3.MoveTowards(porteAssociée2.transform.position, porteAssociée2.transform.position + Vector3.left,
                    speedPorte * Time.deltaTime);
                
                porteAssociée3.transform.position = Vector3.MoveTowards(porteAssociée3.transform.position, porteAssociée3.transform.position + Vector3.left,
                    speedPorte * Time.deltaTime);
            }
        }
    }
    
}


