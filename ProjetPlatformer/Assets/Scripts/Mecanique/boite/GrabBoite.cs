using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;


public class GrabBoite : MonoBehaviour
{
    public bool boiteGrab;
    public GameObject player;
    
    private  KeyCode toucheGrab = KeyCode.UpArrow;
    public float forceJet;
    public float forcePose;
    
    public Rigidbody2D rb;
    public Rigidbody2D rbPlayer;
    
    public CharacterMovement cm;
    public GameObject camera;
    
    public RangeBoite range;
    public RespawnBoite respawn;
    public bool isRespawn;
    
    public GameObject texteIndication;
    
    public Animator anim;
    public Animator anim2;

    public static GrabBoite grabBoiteinstance;

    public GameObject pointPrefab;
    public GameObject[] points;
    public int numberOfPoints;
    private Vector2 Direction;
    
    void Awake()
    {
        if (grabBoiteinstance == null) grabBoiteinstance = this;
        points = new GameObject[numberOfPoints];

        for (int i = 0; i < numberOfPoints; i++)
        {
            points[i] = Instantiate(pointPrefab, transform.position, quaternion.identity);
        }
    }
    
    void Update()
    {
        if (isRespawn)
        {
            if (respawn.lache)
            {
                boiteGrab = false;
            }
        }

        for (int i = 0; i < points.Length; i++)
        {
            points[i].transform.position = PointPosition(i * 0.1f);
        }
        
        // Si le perso peut prendre la boîte
        if (range.isAtRange == true)
        {
            if (Input.GetButtonDown("GrabGamepad")) 
            {
                if(boiteGrab == true)
                {
                    boiteGrab = false;

                    if (Input.GetKey(KeyCode.DownArrow))
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
                }
            }
            
            
            if (Input.GetAxisRaw ("VerticalAxis") == 1 && boiteGrab)
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
            }
        

            if (boiteGrab == true)
            {
                transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 1.1f,
                    player.transform.position.z);
            }

            if (range.isAtRange == true)
            {
                if (boiteGrab == true)
                {
                    anim.SetBool("FadeOutGrab", true);
                    anim.SetBool("FadeInGrab", false);
                    
                    anim2.SetBool("FadeOutGrab2", true);
                    anim2.SetBool("FadeInGrab2", false);
                }
                else
                {
                    anim.SetBool("FadeOutGrab", false);
                    anim.SetBool("FadeInGrab", true);
                    
                    anim2.SetBool("FadeOutGrab2", false);
                    anim2.SetBool("FadeInGrab2", true);
                }
        
            }

            if (range.isAtRange == false)
            {
                anim.SetBool("FadeOutGrab", true);
                anim.SetBool("FadeInGrab", false);
                
                anim2.SetBool("FadeOutGrab2", true);
                anim2.SetBool("FadeInGrab2", false);
            }
        }

        Vector2 PointPosition(float t)
        {
            Vector2 currentPointPos = (Vector2)transform.position + (Direction.normalized * forceJet * t) + 
                                      0.5f * Physics2D.gravity * (t*t);

            return currentPointPos;
        }
}
    
}
