using System;
using System.Collections;
using System.Collections.Generic;
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
    
    void Start()
    {
        targetOrtho = Camera.main.orthographicSize;
    }

    void Update()
    {
        Camera.main.orthographicSize = Mathf.MoveTowards(Camera.main.orthographicSize, targetOrtho, smoothSpeed * Time.deltaTime);
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
    }
    
    private void FixedUpdate()
    {
        Follow();
    }

    public void Follow()
    {
        if (isMoving == false) // permet que la camera suive le joueur
        {
            Vector3 targetPosition = targetPlayer.position + EmplacementCamera ;
            Vector3 smoothedposition = Vector3.Lerp(transform.position, targetPosition, smoothFactor * Time.fixedDeltaTime);
            transform.position = smoothedposition;
        }
        else // permet que la camera ne bouge plus 
        {
            Vector3 targetPosition = targetEmplacementCamera.position + EmplacementCamera;
            Vector3 smoothedposition = Vector3.Lerp(transform.position, targetPosition, smoothFactor * Time.fixedDeltaTime * 1500f);
            transform.position = smoothedposition;
        }
    }

    IEnumerator TimeWaitForMovement()
    {
        yield return new WaitForSeconds(timeWaitForMovement);
        Camera.main.orthographicSize = Mathf.MoveTowards(Camera.main.orthographicSize, targetOrthoFix, smoothSpeedFix * Time.deltaTime);
    }
}
