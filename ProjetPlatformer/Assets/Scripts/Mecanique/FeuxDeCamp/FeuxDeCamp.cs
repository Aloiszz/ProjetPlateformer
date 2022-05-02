using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.UI;
using XInputDotNetPure;

public class FeuxDeCamp : MonoBehaviour
{
    public bool isInRange = false;
    public bool onoff = false;
    public bool canReturn = false;
    public bool canLeave = false;
    
    //public bool isInFdC;
    private BoxCollider2D coll;
    public ParticleSystem ps;
    public Animator anim;
    public GameObject Player;
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
    
    PlayerIndex playerIndex;
    GamePadState state;
    GamePadState prevState;
    private bool doOnce;
    
    [Header("Vibration Motor")]
    public float leftMotor;
    public float rightMotor;
    public float duration;

    [Header("NE PAS TOUCHER")] 
    public Transform playerMoveToFire;
    


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
            
            if (!canReturn)
            {
                EnterCamp();
                Debug.Log("Enter");
            }
            if (canReturn)
            {
                StopAllCoroutines();
                ReEnterCamp();
                Debug.Log("Lautre");
            }
        }
    }

    public void EnterCamp()
    {
        Player.transform.DOMove(playerMoveToFire.position,0.5f);
        MenuManager.instance.isInFeuxDeCamp = true;
        indicationRest.enabled = false;
        indicationWakeUp.enabled = true;
        OnOff(); // On
        if (!doOnce)
        {
            StartCoroutine(VibrationTime());
            doOnce = true;
        }
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
        
        if(!onoff)
        {
            LeaveCamp();
        }
    }

    public void ReEnterCamp()
    {
        Player.transform.DOMove(playerMoveToFire.position,0.5f);
        MenuManager.instance.isInFeuxDeCamp = true;
        indicationRest.enabled = false;
        indicationWakeUp.enabled = true;
        
        OnOff();
        
        if (CharacterMovement.instance.facingRight == false)
        {
            CharacterMovement.instance.Flip();
        }

        if (!onoff)
        {
            SetPlayer(true);
            SetCamera(true);
            SetAnimator(true);
        }
        else
        {
            stopWakeUp = true;
            indicationWakeUp.enabled = false;
            indicationRest.enabled = true;
            SetPlayer(false);
            SetCamera(false);
            SetAnimator(false);
            MenuManager.instance.isInFeuxDeCamp = false;
        }

        playerSpawn.position = transform.position;
        
    }
    public void LeaveCamp()
    {
        //OnOff(); //A remettre pour revenir comme avant // On
        onoff = true;
        stopWakeUp = true;
        indicationWakeUp.enabled = false;
        indicationRest.enabled = true;
        SetPlayer(false);
        SetCamera(false);
        SetAnimator(false);
        MenuManager.instance.isInFeuxDeCamp = false;
        StartCoroutine(CanReturn());
    }
    public void GoToCamp()
    {
        
        /*if (!onoff)//A remettre pour revenir comme avant (onoff)
        {
            Debug.Log("Hello their");
            OnOff();
        }*/
        //Debug.Log(onoff);
        
        /*SetPlayer(true);
        SetCamera(true);
        SetAnimator(true);
        canReturn = false;*/

        SetPlayer(false);
        SetCamera(true);
        anim.SetTrigger("SortieFdC");
        StartCoroutine(CanLeave());


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
    
    IEnumerator VibrationTime()
    {
        yield return new WaitForSeconds(duration+0.6f);
        GamePad.SetVibration(playerIndex, leftMotor, rightMotor);
        yield return new WaitForSeconds(duration);
        GamePad.SetVibration(playerIndex, 0, 0);
    }
    
    IEnumerator CanReturn()
    {
        yield return new WaitForSeconds(0.6f);
        canReturn = true;
    }

    IEnumerator CanLeave()
    {
        yield return new WaitForSeconds(0.2f);
        anim.SetBool("IsFdC", false);
    }

    IEnumerator LeaveCamera()
    {
        yield return new WaitForSeconds(0.4f);
        SetCamera(false);
    }
}
