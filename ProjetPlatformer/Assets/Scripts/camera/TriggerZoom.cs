using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZoom : MonoBehaviour
{   
    [SerializeField] CameraZoom Camera;
    
    [Header("Camera")]
    public bool isCameraFix; // a cocher si l'on veut que la camera ne bouge plus 
    public Vector3 EmplacementCamera = new Vector3(5,0,-10); /* permet d'établir une nouvelle position pour la camera (déplacement), Attention: l'emplacement est un peu bugger
    on établie le nouvel emplacement en fonction de l'emplacement du trigger et non celui du localScale de l'éditeur */

    //public float EmplacementCameraX;
    //public float EmplacementCameraY;
    
    [Header("modification camera")]
    public float distanceTarget = 9.999f; // permet d'établir la distance entre target et camera, plus la valeur est grande plus l'objet est loin
    public float smoothSpeed = 2f; // permet d'ajuster sur la vitesse de la caméra pour dézoomer ou zoomer
    
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player"){
            Camera.smoothSpeed = smoothSpeed;
            Camera.targetOrtho = distanceTarget; 
        
            if (isCameraFix == true) // a valider si on veut que la camera soit fixe, qu'elle ne suivent plus le joueur
            {
                //Camera.EmplacementCamera = new Vector3(EmplacementCameraX, EmplacementCameraY, -10f);
                Camera.EmplacementCamera = EmplacementCamera;
                StartCoroutine(SleepCameraFixTrue());
            }
            else
            {
                Camera.EmplacementCamera = EmplacementCamera;
                //Camera.targetEmplacementCamera = EmplacementCamera;
                StartCoroutine(SleepCameraFixFalse());
            }
        }
    }

    IEnumerator SleepCameraFixTrue() // permet d'attendre 0.1 seconde
    {
        yield return new WaitForSeconds(0.3f);
        Camera.isMoving = true;
    }
    
    IEnumerator SleepCameraFixFalse() // permet d'attendre 0.1 seconde
    {
        yield return new WaitForSeconds(0.15f);
        Camera.isMoving = false;
    }
}