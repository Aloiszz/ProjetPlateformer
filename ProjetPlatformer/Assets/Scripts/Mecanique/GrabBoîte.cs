using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GrabBoîte : MonoBehaviour
{

    public bool boiteGrab;
    public GameObject player;
    public  KeyCode toucheGrab = KeyCode.UpArrow;
    public float forceJet;
    public Rigidbody2D rb;
    public CharacterMovement cm;
    public RangeBoite range;



    void Update()
    {

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
                        if (cm.rb.velocity.x >= cm.speed - 1)
                        {
                            rb.velocity = (new Vector2(forceJet + cm.speed,0));
                        }
                        else
                        {
                            rb.velocity = (new Vector2(forceJet,0));
                        }
                    }
                    else
                    {
                        if (cm.rb.velocity.x <= -(cm.speed - 1))
                        {
                            rb.velocity = (new Vector2(-forceJet - cm.speed,0));
                        }
                        else
                        {
                            rb.velocity = (new Vector2(-forceJet,0));
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
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 1.1f ,
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
