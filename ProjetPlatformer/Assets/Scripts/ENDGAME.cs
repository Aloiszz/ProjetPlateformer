 using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ENDGAME : MonoBehaviour
{
    private bool inRange = false;
    private bool bouge = false;
    private bool portedetesmorts;
    private float timerGauche;
    private float timerDroit;
    private bool doOnce = false;
    
    public GameObject Stel;
    public GameObject WaypointStel;
    public float speedStel;
    public GameObject[] portesdeDroite;
    public int porteDroiteActuelle;
    public GameObject[] portesdeGauche;
    public int porteGaucheActuelle;
   

    public Animator anim;
    public GameObject Player;
    [SerializeField] CameraZoom Camera;
    
    [Header("modification camera Arriver")]
    public float distanceTargetArriver = 9.999f; // permet d'établir la distance entre target et camera, plus la valeur est grande plus l'objet est loin
    public float dezoomSpeedArriver = 2f; // permet d'ajuster sur la vitesse de la caméra pour dézoomer ou zoomer
    public Vector3 EmplacementCameraArriver = new Vector3(0,0,-10);
    
    [Header("UI")]
    public Image indicationRest;
   
    
    [Header("NE PAS TOUCHER")] 
    public Transform playerMoveToFire;

    void Start()
    {
        indicationRest.enabled = false;
        portesdeDroite = GameObject.FindGameObjectsWithTag("portesDroites");
        portesdeGauche = GameObject.FindGameObjectsWithTag("portesGauches");
        Array.Sort(portesdeDroite, (a,b) => a.name.CompareTo(b.name));
        Array.Sort(portesdeGauche, (a,b) => a.name.CompareTo(b.name));
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            inRange = true;
            indicationRest.enabled = true;
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            indicationRest.enabled = false;
        }
    }
    
    private void Update()
    {
        if (inRange)
        {
            if (Input.GetButtonDown("GrabGamepad"))
            {
                if (doOnce == false)
                {
                    indicationRest.enabled = false;
                    Player.transform.DOMove(playerMoveToFire.position + new Vector3(0,0.85f,0),0.5f);
                    StartCoroutine(BougeMoiLeCu());
                    StartCoroutine(Credit());
                    Debug.Log("Ce fut une belle aventure... J'espère que ce jeu on s'en rapellera comme étant une source d'apprentissage majeur.");
                    SetPlayer();
                    SetAnimator();
                    StartCoroutine(SetCamera());
                    portesdeDroite.Reverse();
                    portesdeGauche.Reverse();
                    StartCoroutine(ActivationActivationPortes());
                    doOnce = true;
                }
                
            }
        }
       

        IEnumerator ActivationActivationPortes()
        {
            yield return new WaitForSeconds(7f);
            portedetesmorts = true;
        }
        
        if (portedetesmorts)
        {
            OuverturePorteDroite();
            OuverturePorteGauche();
        }
        
        if (bouge)
        {
            Stel.transform.position = Vector3.MoveTowards(Stel.transform.position, WaypointStel.transform.position,
                speedStel * Time.deltaTime); 
        }
        
    }

    void OuverturePorteDroite()
    {
        if (porteDroiteActuelle >= portesdeDroite.Length)
        {
            return;
        }
        
        timerDroit += Time.deltaTime;
        portesdeDroite[porteDroiteActuelle].transform.DOMove(portesdeDroite[porteDroiteActuelle].transform.position + new Vector3(10, 0, 0),2);
        
        if (timerDroit >= 0.53f)
        {
            timerDroit = 0;
            porteDroiteActuelle++;
        }
    }
    
    void OuverturePorteGauche()
    {
        if (porteGaucheActuelle >= portesdeGauche.Length)
        {
            return;
        }
        
        timerGauche += Time.deltaTime;
        portesdeGauche[porteGaucheActuelle].transform.DOMove(portesdeGauche[porteGaucheActuelle].transform.position + new Vector3(-10, 0, 0),2);
        
        if (timerGauche >= 0.53f)
        {
            timerGauche = 0;
            porteGaucheActuelle++;
        }
    }
        
        
    IEnumerator BougeMoiLeCu()
    {
        yield return new WaitForSeconds(7);
        bouge = true;

    }
    IEnumerator Credit()
    {
        yield return new WaitForSeconds(19);
        MenuManager.instance.OpendCreditFin();
    }
    
    public void SetPlayer()
    {
        CharacterMovement.instance.blockCinematiques = false;
        CharacterMovement.instance.canJump = false;
        CharacterMovement.instance.speed = 0;
        CharacterMovement.instance.canMove = false;
    }
    IEnumerator SetCamera()
    {
         Camera.isMoving = false;
         Camera.smoothSpeed = dezoomSpeedArriver;
         Camera.targetOrtho = distanceTargetArriver; 
         Camera.EmplacementCamera = EmplacementCameraArriver;
         yield return new WaitForSeconds(5);
         Camera.smoothSpeed = 15;
         Camera.targetOrtho = 7;
         Camera.EmplacementCamera = new Vector3(0, -3.5f, -20);

    }
    public void SetAnimator()
    {
        anim.SetTrigger("EntreeFdC");
        anim.SetBool("IsFdC", true);
        anim.SetBool("isGrounded", true);
        anim.ResetTrigger("SortieFdC");
    }
}
