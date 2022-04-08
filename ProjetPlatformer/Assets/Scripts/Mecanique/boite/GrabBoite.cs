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
    public GameObject camera;
    public RangeBoite range;
    public RespawnBoite respawn;
    public bool isRespawn;
    public GameObject texteIndication;

    public static GrabBoite grabBoiteinstance;
    
    void Awake()
    {
        if (grabBoiteinstance == null) grabBoiteinstance = this;
    }
    
    void Update()
    {

        texteIndication.transform.position = new Vector3(camera.transform.position.x,camera.transform.position.y - 7.5f,camera.transform.position.z + 30);
        
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
        if (Input.GetButtonDown("GrabGamepad")) 
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
                    
                    if (Input.GetAxisRaw ("Vertical") == -1)
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
                texteIndication.SetActive(false);
            }
            else
            {
                texteIndication.SetActive(true);
                gameObject.GetComponent<SpriteRenderer> ().color = Color.green;
            }
    
        }

        if (range.isAtRange == false)
        {
            texteIndication.SetActive(false);
            gameObject.GetComponent<SpriteRenderer>().color = Color.gray;
        }
    }
}
