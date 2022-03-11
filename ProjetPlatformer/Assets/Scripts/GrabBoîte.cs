using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabBoîte : MonoBehaviour
{

    public bool boiteGrab;
    public bool isAtRange;
    public GameObject player;
    public  KeyCode toucheGrab;
    public float forceJet;
    public Rigidbody2D rb;
    public CharacterMovement cm;
//    public Material material;


    void Update()
    {

        // Si le perso peut prendre la boîte
        if (isAtRange == true)
        {
            // On illumine le contour
        //    SpriteRendererboite.sprite = boiteIlluminée; 
        if (Input.GetKeyDown(toucheGrab))
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
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 1.1f,
                player.transform.position.z);
        }

        if (isAtRange == true)
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

        if (isAtRange == false)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.gray;
        }

        
        
    }

    // On check à quel moment le player est à porté de prendre la boîte
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            isAtRange = true;
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            isAtRange = false;
        }
    }
}
