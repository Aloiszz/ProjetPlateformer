using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DeathZone : MonoBehaviour
{
    public int respawn;
    public Animator anim;
    [SerializeField] CameraZoom Camera;

    [Header("modification camera Arriver")]
    public float distanceTargetArriver = 7f; // permet d'établir la distance entre target et camera, plus la valeur est grande plus l'objet est loin
    public float dezoomSpeedArriver = 2f; // permet d'ajuster sur la vitesse de la caméra pour dézoomer ou zoomer
    public Vector3 EmplacementCameraArriver = new Vector3(0,0,-10);
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        //FeuxDeCamp.instanceFeuxdeCamp.rightToPass = true;
        Camera.isMoving = false;
        
        //FeuxDeCamp.instanceFeuxdeCamp.LeFeuxDeCamp();
        
        GameObject.FindGameObjectWithTag("Player").transform.position =CharacterMovement.instance.lastCheckPointPos;
        GameObject.FindGameObjectWithTag("MainCamera").transform.position = CameraZoom.instance.lastCheckPointPosCamera;




        /*if (other.CompareTag("Player"))
         {
             SceneManager.LoadScene(respawn);
             //PlayerPrefs.GetInt("checkpoint", 2);
             Debug.Log("hello");
         }*/
    }
}

