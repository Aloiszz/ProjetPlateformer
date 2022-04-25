using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.UI;

public class FeuxDeCamp : MonoBehaviour
{
    public bool isInRange = false;
    public bool onoff = false;
    //public bool isInFdC;
    private BoxCollider2D coll;

    public ParticleSystem ps;
    public Animator anim;
    

    [SerializeField] CameraZoom Camera;

    [Header("modification camera Arriver")]
    public float distanceTargetArriver = 9.999f; // permet d'établir la distance entre target et camera, plus la valeur est grande plus l'objet est loin
    public float dezoomSpeedArriver = 2f; // permet d'ajuster sur la vitesse de la caméra pour dézoomer ou zoomer
    public Vector3 EmplacementCameraArriver = new Vector3(0,0,-10);
    
    [Header("modification camera Depart")]
    public float distanceTargetDepart = 9.999f; // permet d'établir la distance entre target et camera, plus la valeur est grande plus l'objet est loin
    public float dezoomSpeedDepart = 2f; // permet d'ajuster sur la vitesse de la caméra pour dézoomer ou zoomer
    public Vector3 EmplacementCameraDepart = new Vector3(5,0,-10);

    public static FeuxDeCamp instanceFeuxdeCamp;
    private Transform playerSpawn;

    [Header("Animation Curve")]
    public AnimationCurve CourbeDeFlamme;
    public Light2D Flamme;
    private float graph, increment;
    private bool canRunGame;

    [Header("UI")] 
    private bool stopWakeUp;
    public MenuManager mm;
    public Animator FeuxDeCampsAnim;
    public Animator parchAnim;
    public Image indicationRest;
    public Image indicationWakeUp;


    private void Awake()
    {
        if (instanceFeuxdeCamp == null) instanceFeuxdeCamp = this;
        playerSpawn = GameObject.FindGameObjectWithTag("PlayerSpawn").transform;
        Flamme.intensity = 0;
    }

    private void Start()
    {
        indicationRest.enabled = false;
        indicationWakeUp.enabled = false;
        coll = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (canRunGame)
        {
            Flamme.intensity = 1;
            increment += Time.deltaTime;
            graph = CourbeDeFlamme.Evaluate(increment);
            Flamme.intensity = graph;
        }

        if (mm.MenuParcheminOuvert)
        {
            indicationWakeUp.enabled = false;
        }
        
        if (!onoff)
        {
            indicationWakeUp.enabled = false;
        }
        
        if (!mm.MenuParcheminOuvert && stopWakeUp)
        {
            indicationWakeUp.enabled = false;
        }
        
        
        if (isInRange == true && Input.GetButtonDown("GrabGamepad"))
        {
            EnterCamp();
            
        }
    }

    public void EnterCamp()
    {
        indicationRest.enabled = false;
        indicationWakeUp.enabled = true;
        Debug.Log("enter camp");
        OnOff();
        
        if (onoff)
        {
            Debug.Log("Input Enter");
            canRunGame = true;
            FeuxDeCampsAnim.SetBool("isFire", true);
            if (CharacterMovement.instance.facingRight == false)
            {
                CharacterMovement.instance.Flip();
            }

            SetPlayer(true);
            SetCamera(true);
            SetAnimator(true);

            ps.Play(); // allumer le feu !!!
            playerSpawn.position = transform.position;
        }
        else
        {
            Debug.Log("Input Leave");
            LeaveCamp(); 
            OnOff();
        }
    }
    public void LeaveCamp()
    {
        stopWakeUp = true;
        indicationWakeUp.enabled = false;
        indicationRest.enabled = true;
        SetPlayer(false);
        SetCamera(false);
        SetAnimator(false);
    }
    public void GoToCamp()
    {
        if (onoff)
        {
            //OnOff();
        }
        //Debug.Log(onoff);
        
        SetPlayer(true);
        SetCamera(true);
        SetAnimator(true);
        
        /*if (onoff)
        {
            LeaveCamp(); 
            SetPlayer(false);
            SetCamera(false);
            SetAnimator(false);
        }*/
    }
    
    /*public void LeFeuxDeCamp()
    { 
        onoff = !onoff;// toggles onoff 
            
        if (onoff) // Arriver sur le feux de camps 
        {
            if (CharacterMovement.instance.facingRight == false)
            {
                CharacterMovement.instance.Flip();
            }

            SetPlayer(true);
            SetCamera(true);
            SetAnimator(true);

            ps.Play(); // allumer le feu !!!
            playerSpawn.position = transform.position;

            //PlayerPrefs.SetInt("checkpoint", 2);// enregistrer ton checkpoint !! 
            //PlayerPrefs.GetInt("checkpoint", 2); // récuperer la sauvegarde
        }
        
        else // Départ du feux de camps 
        {
            SetPlayer(false);
            SetCamera(false);
            SetAnimator(false);
        }
    }*/
    
    public void OnOff()
    {
        onoff = !onoff;
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
    public void SetCamera(bool verif)
    {
        if (verif) // arriver dans le feux de camp
        {
            Camera.isMoving = false;
            Camera.smoothSpeed = dezoomSpeedArriver;
            Camera.targetOrtho = distanceTargetArriver; 
            Camera.EmplacementCamera = EmplacementCameraArriver;
        }
        else // départ du feux de camp
        {
            Camera.smoothSpeed = dezoomSpeedDepart;
            Camera.targetOrtho = distanceTargetDepart; 
            Camera.EmplacementCamera = EmplacementCameraDepart;
        }
        
    }
    public void SetAnimator(bool verif)
    {
        if (verif) // arriver dans le feux de camp
        {
            
            anim.SetTrigger("EntreeFdC");
            anim.SetBool("IsFdC", true);
            anim.SetBool("isGrounded", true);
            anim.ResetTrigger("SortieFdC");
            parchAnim.SetBool("FadeInParch",true);
            parchAnim.SetBool("FadeOutParch",false);
        }
        else // départ du feux de camp
        {
            anim.SetBool("IsFdC", false);
            anim.SetTrigger("SortieFdC");
            anim.ResetTrigger("EntreeFdC");
            parchAnim.SetBool("FadeInParch",false);
            parchAnim.SetBool("FadeOutParch",true);
        }
        
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            isInRange = true;
            if (!onoff)
            {
                indicationRest.enabled = true; 
            }
        }
        else
        {
            indicationRest.enabled = false;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            indicationRest.enabled = false;
            isInRange = false;
        }
    }
}
