using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DeathZone : MonoBehaviour
{
    public int respawn;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject.FindGameObjectWithTag("Player").transform.position =CharacterMovement.instance.lastCheckPointPos;
        GameObject.FindGameObjectWithTag("MainCamera").transform.position = CameraZoom.instance.lastCheckPointPosCamera;
        
        CharacterMovement.instance.canJump = false;
        CharacterMovement.instance.speed = 0;
        CharacterMovement.instance.canMove = false;

        /*if (other.CompareTag("Player"))
         {
             SceneManager.LoadScene(respawn);
             //PlayerPrefs.GetInt("checkpoint", 2);
             Debug.Log("hello");
         }*/
    }
}

