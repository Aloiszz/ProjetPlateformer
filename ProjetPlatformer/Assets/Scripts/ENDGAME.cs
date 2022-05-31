 using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
 using System.Runtime.Remoting.Messaging;
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
    public float speedStel;
    public int porteDroiteActuelle;
    public int porteGaucheActuelle;
    
    
    [Header ("GameObjects")] 
    public GameObject Player;
    public GameObject[] portesdeGauche;
    public GameObject[] portesdeDroite;
    public GameObject Stel;
    public GameObject WaypointStel;
    public GameObject Escaliers1;
    public GameObject Escaliers2;
    public GameObject FondFadeOut1;
    public GameObject FondFadeOut2;
    public GameObject AvantPlanG;
    public GameObject AvantPlanD;
    public GameObject SolCentreG;
    public GameObject SolCentreD;
    
   
    [Header ("Autre")] 
    public Animator anim;
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
                    StartCoroutine(OuvertureHaut());
                    StartCoroutine(ActivationActivationPortes());
                    doOnce = true;
                }
                
            }
        }


        IEnumerator OuvertureHaut()
        {
            yield return new WaitForSeconds(4.5f);
              for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
                // set color with i as alpha
                FondFadeOut1.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, i);
                FondFadeOut2.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, i);
                AvantPlanG.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, i);
                AvantPlanD.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, i);
                yield return null;
            }
              
            SolCentreD.transform.DOMove(SolCentreD.transform.position + new Vector3(3, 0),2);
            SolCentreG.transform.DOMove(SolCentreG.transform.position + new Vector3(-3, 0),2);
            Escaliers1.transform.DOMove(Escaliers1.transform.position + new Vector3(-3, 0),2);
            Escaliers2.transform.DOMove(Escaliers2.transform.position + new Vector3(3, 0),2);
        }

        IEnumerator ActivationActivationPortes()
        {
            yield return new WaitForSeconds(7.5f);
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
        portesdeDroite[porteDroiteActuelle].transform.DOMove(portesdeDroite[porteDroiteActuelle].transform.position + new Vector3(5, 0, 0),5);
        
        if (timerDroit >= 1f)
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
        portesdeGauche[porteGaucheActuelle].transform.DOMove(portesdeGauche[porteGaucheActuelle].transform.position + new Vector3(-5, 0, 0),5);
        
        if (timerGauche >= 1f)
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
