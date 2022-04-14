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
    public bool StopCamera;

    private void Awake()
    {
        if (instance == null) instance = this;
    }
    
    
    void Start()
    {
        targetOrtho = Camera.main.orthographicSize;
        transform.position = targetPlayer.position + EmplacementCamera + new Vector3(0,20,0);
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
    
  /*  private void FixedUpdate()
    {
        if(menu.isPlaying)
        {
            StartCoroutine(StartCamera());

            if (StopCamera)
            {
                Follow();
                StopCoroutine(StartCamera());
            }
        }

    }

    IEnumerator StartCamera()
    {
        if (menu.isPlaying)
        {
            Debug.Log("oui");
            Vector3 targetPosition = targetPlayer.position + EmplacementCamera - new Vector3(0,-10,0);
            Vector3 smoothedposition = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.fixedDeltaTime);
            transform.position = smoothedposition;
            StopCamera = true;
            Follow();
            yield return this;
        }
    }*/

  private void FixedUpdate()
  {
      Follow();
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
