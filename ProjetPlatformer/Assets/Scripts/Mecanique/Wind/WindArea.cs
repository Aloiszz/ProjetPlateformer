using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindArea : MonoBehaviour
{
    private bool isWindy = false;
    public float WindForce_X = 0f;
    public float WindForceNull_X = 0f;
    public float WindForce_Y = 0f;
    public float WindForceNull_Y = 0f;
    
    public float timeWaitForWind = 3f;
    
    public CharacterMovement Character;
    public GrabBoîte Boite;
    

    private Rigidbody2D rb;
    private Rigidbody2D rbBoite;

    public GameObject particulesVent;
    public Animator anim;
    public bool Tempête;
    
    private void Awake()
    {
        rb = Character.GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        isWindy = true;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (isWindy)
            {
                
                rb.AddForce(new Vector2(WindForceNull_X, WindForceNull_Y));
            }
            else
            {
                rb.AddForce(new Vector2(WindForce_X, WindForce_Y));
            }
            StartCoroutine(WaitForWind()); 
        }
        
        if (other.tag == "Respawn")
        {
            if (isWindy)
            {
                rbBoite.AddForce(new Vector2(WindForceNull_X, WindForceNull_Y));
            }
            else
            {
                rbBoite.AddForce(new Vector2(WindForce_X, WindForce_Y));
            }
            StartCoroutine(WaitForWind()); 
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        isWindy = false;
        anim.SetBool("IsTempete", false);
        //rb.AddForce(new Vector2(WindForce, 0));
    }

    IEnumerator WaitForWind()
    {
        while (isWindy)
        {
            if (Tempête)
            {
                anim.SetBool("IsTempete", false);
                particulesVent.SetActive(false);
            }
            yield return new WaitForSeconds(timeWaitForWind);
            isWindy = false;
            
            if (Tempête)
            {
                particulesVent.SetActive(true);
                
            }
            
            yield return new WaitForSeconds(timeWaitForWind);
            isWindy = true;
        }

        if (!isWindy)
        {
            if (Tempête)
            {
                anim.SetBool("IsTempete", true); 
                
            }
        }
    }
}