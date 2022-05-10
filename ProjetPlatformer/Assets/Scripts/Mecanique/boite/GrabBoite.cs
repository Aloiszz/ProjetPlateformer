using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class GrabBoite : MonoBehaviour
{
    public bool boiteGrab;
    public GameObject player;
    
    private  KeyCode toucheGrab = KeyCode.UpArrow;
    public float forceJet;
    public float forcePose;
    
    [Header("Renseignement")]
    public Rigidbody2D rb;
    public BoxCollider2D coll;
    public Rigidbody2D rbPlayer;
    public CharacterMovement cm;
    public GameObject camera;
    public RangeBoite range;
    public RespawnBoite respawn;
    public RespawnBoite respawn2;
    public bool isRespawn;
    public bool lache2;
    
    [Header("UI")]
    public GameObject texteIndication;
    
   /* [Header("Animator")]
    public Animator anim;
    public Animator anim2;*/
    
    [Header("----------------------------------------------")]
    public Vector2 direction;
    public bool isNull = false;

    [Header("Joystick position")]
    public float joystickX;
    public float joystickY;

    [Header("Tracer de la courbe")]
    public GameObject PointPrefab;
    public GameObject[] Points;
    public int numberOfpoints;


    public static GrabBoite grabBoiteinstance;

    void Awake()
    {
        coll = GetComponent<BoxCollider2D>();
        if (grabBoiteinstance == null) grabBoiteinstance = this;
        //RemplirArray();
        texteIndication.SetActive(false);
    }

    void RemplirArray()
    {
        Points = new GameObject[numberOfpoints];
        for (int i = 0; i < numberOfpoints; i++)
        {
            Points[i] = Instantiate(PointPrefab, transform.position, quaternion.identity);
        }
    }

    void Update()
    {
        if (isRespawn)
        {
            if (respawn.lache || respawn2.lache)
            {
                lache2 = true;
            }
            else
            {
                lache2 = false;
            }
        }

        if (lache2)
        {
            rb.velocity = new Vector2(0, 0);
            transform.localRotation = new Quaternion(0, 0, 0, 0);
            boiteGrab = false;
        }
        // Si le perso peut prendre la boîte
        if (range.isAtRange == true)
        {
            LancerDeBoite();
        }
        
        if (boiteGrab)
        {
            texteIndication.SetActive(false);
            //coll.enabled = false;
            JoystickManager();
            for (int i = 0; i < Points.Length; i++)
            {
                Points[i].gameObject.SetActive(true);
            }
        }
        else
        {
            for (int i = 0; i < Points.Length; i++)
            {
                Points[i].gameObject.SetActive(false);
            }
            //coll.enabled = true;
        }
    }
    
    void LancerDeBoite()
    {
        if (Input.GetButtonDown("GrabGamepad")) 
        {
            boiteGrab = true;
           /* if(boiteGrab == true)
            {
                boiteGrab = false;
                if (cm.facingRight == true)
                {
                    rb.velocity = (new Vector2(forceJet + rbPlayer.velocity.x/2,0));
                }    
                else
                {
                    rb.velocity = (new Vector2(-forceJet + rbPlayer.velocity.x/2,0));
                }*/

                /*if (Input.GetKey(KeyCode.DownArrow))
                {
                    if (cm.facingRight == true)
                    {
                        rb.velocity = (new Vector2(forcePose,2.5f));
                    }    
                    else
                    {
                        rb.velocity = (new Vector2(-forcePose,2.5f));
                    }
                }
            }
            else
            {
                boiteGrab = true;
            }*/
        }
        if (Input.GetButtonDown("ThrowBox") && boiteGrab)
        {
            boiteGrab = false;
            Shoot();
        }

        /*if (Input.GetAxisRaw ("VerticalAxis") == 1 && boiteGrab)
        {
            boiteGrab = false;
            if (cm.facingRight == true)
            {
                rb.velocity = (new Vector2(forceJet + rbPlayer.velocity.x/2,0));
            }    
            else
            {
                rb.velocity = (new Vector2(-forceJet + rbPlayer.velocity.x/2,0));
            }
        }*/
        

        if (boiteGrab == true)
        {
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 1.22f,
                player.transform.position.z);
        } // Placement de la boite sur la tete
        
        if (range.isAtRange == true)
        {
            if (boiteGrab == true)
            {
                AnimInteractionBoite(true);
            }
            else
            {
                AnimInteractionBoite(false);
            }
    
        } // UI de la boite
        else
        {
            AnimInteractionBoite(true);
        } // UI de la boite
    }

    #region JoystickManager
    void JoystickManager()
    {
        joystickX = Input.GetAxisRaw("HorizontalAxis");
        joystickY = Input.GetAxisRaw("VerticalAxis");

        Vector2 MousePos = new Vector2(joystickX, -(joystickY)); //Debug.Log(Camera.main.ViewportToScreenPoint(Input.mousePosition));
        //float MousePos = Mathf.Atan2(joystickY, joystickX) * Mathf.Rad2Deg;

        //direction = transform.TransformDirection(Mathf.Abs(MousePos), 0, 0) ; //- bowPos
        direction = MousePos * rb.gravityScale;
        
        transform.right = direction;

        for (int i = 0; i < Points.Length; i++)
        {
            if (MousePos == new Vector2(0, 0))
            {
                Points[i].transform.DOMove(PointPositionNull(i * 0.1f), 0.2f);
                isNull = true;
            }
            else
            {
                Points[i].transform.DOMove(PointPosition(i * 0.1f), 0.2f);
                isNull = false;
            }
            
            //Destroy(Points[i].gameObject);
        }
    }
    
    Vector2 PointPosition(float t)
    {
        Vector2 currentPointPos = (Vector2) transform.position + (direction.normalized * forceJet * t) + 0.5f * Physics2D.gravity * (t*t);

        return currentPointPos;
    }
    
    Vector2 PointPositionNull(float t)
    {
        Vector2 currentPointPos = (Vector2) transform.position + (direction.normalized * 0 * t) + 0.5f * Physics2D.gravity * (t*t);

        return currentPointPos;
    }
    #endregion

    void Shoot()
    {
        if (isNull)
        {
            rb.velocity = transform.right * (0 + rbPlayer.velocity.x/2);
        }
        else
        {
            //rb.velocity = (new Vector2(forceJet + rbPlayer.velocity.x/2,0));
            rb.velocity = transform.right * (forceJet);
        }
    }
    
    
    void AnimInteractionBoite(bool verif)
    {
        if (verif)
        {
            
            
           /* anim.SetBool("FadeOutGrab", true);
            anim.SetBool("FadeInGrab", false);
                
            anim2.SetBool("FadeOutGrab2", true);
            anim2.SetBool("FadeInGrab2", false);*/
        }
        else
        {
            
           /* anim.SetBool("FadeOutGrab", false);
            anim.SetBool("FadeInGrab", true);
               
            anim2.SetBool("FadeOutGrab2", false);
            anim2.SetBool("FadeInGrab2", true);*/
        }
    }
    
}
