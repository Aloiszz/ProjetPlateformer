using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

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
    public Animator animPlayer;
   

    private void Awake()
    {
        if (instance == null) instance = this;
    }
    
    
   

    void Update()
    {
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
            transform.position = targetPlayer.position + EmplacementCamera + new Vector3(50,50,0);
        }
        else
        {
            Follow();
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
        }
    }

    IEnumerator SmoothCameraIntro()
    {
        smoothSpeed = 0.5f;
        animPlayer.Play("Idle Feu de camp");
        animPlayer.SetTrigger("Sortie FdC");
        yield return new WaitForSeconds(10.5f);
        animPlayer.ResetTrigger("Sortie FdC");
        animPlayer.SetTrigger("Sortie FdC");
        animPlayer.SetBool("IsFdC", false);
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
