using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZoom : MonoBehaviour
{   
    [Header("Camera")]
    [SerializeField] private CameraZoom Camera;
    public bool setCameraPosition = false;
    public Vector3 EmplacementCamera = new Vector3(43,5,-10);
    public bool isCameraFix;
    
    [Header("modification camera")]
    public float targetOrtho = 9.999f; // valeur de base de la camera a 9.999f
    public float smoothSpeed =2f; //normalement 2
    public float minOrtho = 1.0f;
    public float maxOrtho = 20.0f;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Camera.smoothSpeed = smoothSpeed;
        Camera.targetOrtho = targetOrtho;
        
        if (setCameraPosition == true)
        {
            Camera.EmplacementCamera = EmplacementCamera;
            if (isCameraFix == true)
            {
                StartCoroutine(Sleep());
            }
        }
        if (isCameraFix == false)
        {
            Camera.isMoving = false;
            Camera.EmplacementCamera = EmplacementCamera;
        }
    }

    IEnumerator Sleep()
    {
        yield return new WaitForSeconds(0.1f);
        Camera.isMoving = true;
    }
}