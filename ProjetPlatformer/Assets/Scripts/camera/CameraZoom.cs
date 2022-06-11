using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraZoom : MonoBehaviour
{

    [Header("Camera")]
    public Transform targetPlayer;
    private Transform targetEmplacementCamera;
    private bool StopSmoothChange;

    public Vector3 EmplacementCamera = new Vector3(5,0,-10);
    
    [Header("SmoothCamera")]
    [Range(0,50)] public float smoothFactor;
    [SerializeField] public bool isMoving;
    
    [Header("modification camera en mouvement")]
    public float targetOrtho;// valeur de base de la camera a 9.999f
    public float smoothSpeed = 2.0f;
    
    [Header("modification camera a l'arret")]
    public float targetOrthoFix;// valeur de base de la camera a 9.999f
    public float smoothSpeedFix = 2.0f;
    public float timeWaitForMovement = 2f;
    
    public static CameraZoom instance;
    public MenuManager menu;
    public bool CinematiqueIntro;
    public bool CinematiqueIntroRuines;
    public Animator animPlayer;

    public GameObject Waypoint1;
    public GameObject Waypoint2;

    public bool DoOnce;
    
    private void Awake()
    {
        if (instance == null) instance = this;

        if (SceneManager.GetActiveScene().name == "LD Ruines 3")
        {
            if (CinematiqueIntroRuines )
            {
                
                StartCoroutine(WaitCinématique());
            }
        }
    }
    

    IEnumerator WaitCinématique()
    {
        DoOnce = false;
        CharacterMovement.instance.canMove = false;
        CharacterMovement.instance.canJump = false;
        CharacterMovement.instance.speed = 0;
        CharacterMovement.instance.gravityScale = 5;
        isMoving = true;
        animPlayer.Play("Player_Jump_LandingHard");
        yield return new WaitForSeconds(2f);
        isMoving = false;
        Follow();
        CharacterMovement.instance.canMove = true;
        CharacterMovement.instance.canJump = true;
        CharacterMovement.instance.speed = 11;
        CharacterMovement.instance.gravityScale = 9;
    }
    
   

    void Update()
    {
        if (DoOnce = false)
        {
            Follow();
        }
        
        //Camera.main.orthographicSize = Mathf.MoveTowards(Camera.main.orthographicSize, targetOrtho, smoothSpeed * Time.deltaTime);
        Camera.main.DOOrthoSize(targetOrtho, smoothSpeed);
       
        /*if (CharacterMovement.instance.rb.velocity.x <= 5 && CharacterMovement.instance.rb.velocity.x >= -5 )
        {
            if (isMoving == false)
            {
                Debug.Log("Hello");
                StartCoroutine(TimeWaitForMovement());
            }
        }
        else
        {
            Camera.main.orthographicSize = Mathf.MoveTowards(Camera.main.orthographicSize, targetOrtho, smoothSpeed * Time.deltaTime);
        }*/

        /*if (CharacterMovement.instance.rb.velocity.y < -45)
        {
            smoothSpeed = 5;
        }
        else
        {
            smoothSpeed = 2;
        }*/
    }
    
    //------- Déplacement camera au lancement -------------
    
    
    
    void Start()
    {
        menu = GameObject.Find("Canvas (Menu)").GetComponent<MenuManager>();
        
        if (CinematiqueIntro)
        {
            targetOrtho = Camera.main.orthographicSize;
            transform.position = targetPlayer.position + EmplacementCamera + new Vector3(50,25,0);
        }
        else
        {
            if (CinematiqueIntroRuines)
            {
                Follow();
            }
           
        }
    }
    private void FixedUpdate()
    {
        if(menu.isPlaying)
        {
                Follow();
                if (StopSmoothChange == false && CinematiqueIntro)
                {
                    StartCoroutine(SmoothCameraIntro());
                }

                if (StopSmoothChange)
                {
                    StopAllCoroutines();
                }
        }
    }

    IEnumerator SmoothCameraIntro()
    {
        smoothSpeed = 0.5f;
        animPlayer.SetBool("IsWalking", false);
        animPlayer.SetTrigger("EntreeFdC");
        animPlayer.SetBool("IsFdC", true);
        animPlayer.Play("Idle Feu de camp");
        targetOrtho = 6;
        //.SetTrigger("SortieFdC");
        yield return new WaitForSeconds(10.5f);
        targetOrtho = 7;
        animPlayer.ResetTrigger("EntreeFdC");
        animPlayer.SetBool("IsFdC", false);
        animPlayer.SetTrigger("SortieFdC");
        yield return new WaitForSeconds(0.1f);
        smoothSpeed = 2;
        StopSmoothChange = true;
    }
    

    public void Follow()
    {
        
        if (isMoving == false) // permet que la camera suive le joueur
        {
            Vector3 targetPosition = targetPlayer.position + EmplacementCamera;
            Vector3 smoothedposition = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.fixedDeltaTime); // remettre smoothFactor sur smooth speed
            transform.position = smoothedposition;
            //transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
        else // permet que la camera ne bouge plus 
        {
            Vector3 targetPosition = targetEmplacementCamera.position + EmplacementCamera;
            Vector3 smoothedposition = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.fixedDeltaTime *1500f); // remettre smoothFactor sur smooth speed
            transform.position = smoothedposition;
            //transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
    }

    IEnumerator TimeWaitForMovement()
    {
        yield return new WaitForSeconds(timeWaitForMovement);
        Camera.main.orthographicSize = Mathf.MoveTowards(Camera.main.orthographicSize, targetOrthoFix, smoothSpeedFix * Time.deltaTime);
    }
}
