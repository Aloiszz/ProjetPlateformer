using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    [Header("Camera")]
    public Transform targetPlayer;
    public Transform targetEmplacementCamera;
    public Vector3 EmplacementCamera;
    [Range(0,50)] public float smoothFactor;
    [SerializeField] public bool isMoving;
    
    [Header("modification camera")]
    public float targetOrtho;// valeur de base de la camera a 9.999f
    public float smoothSpeed = 2.0f;
    public float minOrtho = 1.0f;
    public float maxOrtho = 20.0f;
    
    void Start()
    {
        targetOrtho = Camera.main.orthographicSize;
    }

    void Update()
    {
        Camera.main.orthographicSize = Mathf.MoveTowards(Camera.main.orthographicSize, targetOrtho, smoothSpeed * Time.deltaTime);
    }
    
    private void FixedUpdate()
    {
        Follow();
    }

    public void Follow()
    {
        
        if (isMoving == false)
        {
            Vector3 targetPosition = targetPlayer.position + EmplacementCamera;
            Vector3 smoothedposition = Vector3.Lerp(transform.position, targetPosition, smoothFactor * Time.fixedDeltaTime);
            transform.position = targetPosition;
        }
        else
        {
            Vector3 targetPosition = targetEmplacementCamera.position + EmplacementCamera;
            Vector3 smoothedposition = Vector3.Lerp(transform.position, targetPosition, smoothFactor * Time.fixedDeltaTime);
            transform.position = targetPosition;
        }
    }
}
