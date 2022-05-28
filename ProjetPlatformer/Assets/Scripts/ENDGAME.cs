using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ENDGAME : MonoBehaviour
{
    private bool inRange = false;
    private bool bouge = false;
    public GameObject Stel;
    public GameObject WaypointStel;
    
    public Animator anim;
    public GameObject Player;
    [SerializeField] CameraZoom Camera;
    
    [Header("modification camera Arriver")]
    public float distanceTargetArriver = 9.999f; // permet d'établir la distance entre target et camera, plus la valeur est grande plus l'objet est loin
    public float dezoomSpeedArriver = 2f; // permet d'ajuster sur la vitesse de la caméra pour dézoomer ou zoomer
    public Vector3 EmplacementCameraArriver = new Vector3(0,0,-10);
    
    [Header("UI")]
    public MenuManager mm;
    public Animator FeuxDeCampsAnim;
    public Animator parchAnim;
    public Image indicationRest;
    public Image indicationWakeUp;
    public bool activeTuto;
    public GameObject tutoFdC;
    
    [Header("NE PAS TOUCHER")] 
    public Transform playerMoveToFire;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            inRange = true;
        }
    }

    private void Update()
    {
        if (inRange)
        {
            if (Input.GetButtonDown("GrabGamepad"))
            {
                Player.transform.DOMove(playerMoveToFire.position,0.5f);
                Player.transform.parent = Stel.transform;
                Stel.transform.DOScale(new Vector3(0.2f, 0.2f, 0.2f), 0.1f);
                StartCoroutine(BougeMoiLeCu());
                StartCoroutine(Credit());
                Debug.Log("Ce fut une belle aventure... J'espère que ce jeu on s'en rapellera comme étant une source d'apprentissage majeur.");
                SetPlayer();
                SetAnimator();
                SetCamera();
            }
        }

        if (bouge)
        {
            Stel.transform.localScale = new Vector3(1, 1, 1);
            Stel.transform.Translate(Vector3.down * Time.deltaTime * 5);
        }
        
    }

    IEnumerator BougeMoiLeCu()
    {
        yield return new WaitForSeconds(2);
        //Stel.transform.DOMove(WaypointStel.transform.position, 10);
        bouge = true;

    }
    IEnumerator Credit()
    {
        yield return new WaitForSeconds(7);
        MenuManager.instance.OpenCreditMenu();
    }
    
    public void SetPlayer()
    {
        CharacterMovement.instance.canJump = false;
        CharacterMovement.instance.speed = 0;
        CharacterMovement.instance.canMove = false;
    }
    public void SetCamera()
    {
         Camera.isMoving = false;
         Camera.smoothSpeed = dezoomSpeedArriver;
         Camera.targetOrtho = distanceTargetArriver; 
         Camera.EmplacementCamera = EmplacementCameraArriver;
        
    }
    public void SetAnimator()
    {
        anim.SetTrigger("EntreeFdC");
        anim.SetBool("IsFdC", true);
        anim.SetBool("isGrounded", true);
        anim.ResetTrigger("SortieFdC");
        parchAnim.SetBool("FadeInParch",true);
        parchAnim.SetBool("FadeOutParch",false);
    }
}
