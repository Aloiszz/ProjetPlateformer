using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Animation;
using UnityEngine;

public class FeuxDeCamp : MonoBehaviour
{
    public bool isInRange = false;
    public bool rightToPass = false;
    public bool onoff = false;
    private Collider2D coll;

    public ParticleSystem ps;
    public Animator anim;

    [SerializeField] CameraZoom Camera;

    [Header("modification camera Arriver")]
    public float distanceTargetArriver = 9.999f; // permet d'établir la distance entre target et camera, plus la valeur est grande plus l'objet est loin
    public float dezoomSpeedArriver = 2f; // permet d'ajuster sur la vitesse de la caméra pour dézoomer ou zoomer
    public Vector3 EmplacementCameraArriver = new Vector3(0,0,-10);
    
    [Header("modification camera Depart")]
    public float distanceTargetDepart = 9.999f; // permet d'établir la distance entre target et camera, plus la valeur est grande plus l'objet est loin
    public float dezoomSpeedDepart = 2f; // permet d'ajuster sur la vitesse de la caméra pour dézoomer ou zoomer
    public Vector3 EmplacementCameraDepart = new Vector3(5,0,-10);

    public static FeuxDeCamp instanceFeuxdeCamp;
    private Transform playerSpawn;


    private void Awake()
    {
        if (instanceFeuxdeCamp == null) instanceFeuxdeCamp = this;
        playerSpawn = GameObject.FindGameObjectWithTag("PlayerSpawn").transform;
    }

    private void Start()
    {
        coll = GetComponent<Collider2D>();
    }

    void Update()
    {
        if (isInRange == true && Input.GetButtonDown("GrabGamepad"))
        {
            LeFeuxDeCamp();
        }
    }
    
    public void LeFeuxDeCamp()
    {
        onoff = !onoff; // toggles onoff 
            
        if (onoff) // Arriver sur le feux de camps 
        {
            Camera.isMoving = false;
            CharacterMovement.instance.canJump = false;
            CharacterMovement.instance.speed = 0;
            CharacterMovement.instance.canMove = false;
            Camera.smoothSpeed = dezoomSpeedArriver;
            Camera.targetOrtho = distanceTargetArriver; 
            Camera.EmplacementCamera = EmplacementCameraArriver;
            
            anim.SetBool("isGrounded", true);
                
            ps.Play(); // allumer le feu !!!

            playerSpawn.position = transform.position;

            //PlayerPrefs.SetInt("checkpoint", 2);// enregistrer ton checkpoint !! 
            //PlayerPrefs.GetInt("checkpoint", 2); // récuperer la sauvegarde
        }
        else // Départ du feux de camps 
        {
            CharacterMovement.instance.canJump = true;
            CharacterMovement.instance.speed = 11;
            CharacterMovement.instance.canMove = true;
            Camera.smoothSpeed = dezoomSpeedDepart;
            Camera.targetOrtho = distanceTargetDepart; 
            Camera.EmplacementCamera = EmplacementCameraDepart;

            //coll.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            isInRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            isInRange = false;
        }
    }
}
