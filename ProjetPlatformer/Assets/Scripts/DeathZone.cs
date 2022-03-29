using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DeathZone : MonoBehaviour
{
    public int respawn;
    public Animator anim;
    [SerializeField] CameraZoom Camera;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Camera.isMoving = false;
        
        //FeuxDeCamp.instanceFeuxdeCamp.LeFeuxDeCamp();

        //GameObject.FindGameObjectWithTag("Player").transform.position =CharacterMovement.lastCheckPointPos;
        //GameObject.FindGameObjectWithTag("MainCamera").transform.position = CameraZoom.lastCheckPointPosCamera;

        if (other.CompareTag("Player"))
         {
             //SceneManager.LoadScene(respawn);
             SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
             //PlayerPrefs.GetInt("checkpoint", 2);
             Debug.Log("hello");
         }
    }
}

