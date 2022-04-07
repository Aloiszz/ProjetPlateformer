using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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
    public RangeBoite range;
    public RespawnBoite respawn;
    public bool isRespawn;

    public static GrabBoite grabBoiteinstance;
    
    void Awake()
    {
        if (grabBoiteinstance == null) grabBoiteinstance = this;
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
        
        
        // Si le perso peut prendre la boîte
        if (range.isAtRange == true)
        {
            // On illumine le contour
        //    SpriteRendererboite.sprite = boiteIlluminée; 
        if (Input.GetButtonDown("GrabGamepad") /*|| Input.GetButtonDown("toucheGrab")*/) // integrer la touche au clavier
            {
                if(boiteGrab == true)
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

                    if (Input.GetKey(KeyCode.DownArrow))     /*|| Input.GetButton(KeyCode.Joystick4Button12)*/
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
        }
        else
        {
       //    SpriteRendererboite.sprite = boitePasIlluminée; 
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
                gameObject.GetComponent<SpriteRenderer>().color = Color.gray;
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer> ().color = Color.green;
            }
    
        }

        if (range.isAtRange == false)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.gray;
        }
    }
}
