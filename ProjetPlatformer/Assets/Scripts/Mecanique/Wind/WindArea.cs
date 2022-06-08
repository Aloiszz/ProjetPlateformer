using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;


public class WindArea : MonoBehaviour
{
    public bool isWindy = false;
    public float WindForce_X = 0f;
    public float WindForceNull_X = 0f;
    public float WindForce_Y = 0f;
    public float WindForceNull_Y = 0f;
    
    public float timeWaitForWind = 3f;
    
    public CharacterMovement Character;
    public GrabBoite scriptBoite;

    private Rigidbody2D rb;
    public Rigidbody2D rbBoite;

    public GameObject particulesVent;
    public GameObject particulesVent2;
    public Animator anim;
    public bool Tempête;

    public bool letsHaveTempete = false;
    public List<GameObject> listEffetVent;
    public static WindArea instance;

    public GameObject effetPoussière;
    public Animator animTempete;
    public bool indicationTempeteState = false;
    public EffetVent effetVent;

    public EffetPoussière effet;

    public UnityEngine.Rendering.Universal.Light2D globalLight;
    

    private void Awake()
    {
        rb = Character.GetComponent<Rigidbody2D>();
        if (instance == null) instance = this;
    }
    
    private void Update()
    {
        if (globalLight is null) return;
        if (!isWindy && letsHaveTempete)
        {
            if (globalLight.intensity >= 0.3f)
            {
                globalLight.intensity -= 0.4f * Time.deltaTime;
            }
        }
        else
        {
            if (globalLight.intensity <= 1f)
            {
                globalLight.intensity += 0.4f * Time.deltaTime;
            }
        }
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        letsHaveTempete = true;
        isWindy = true;
        anim.SetBool("isDoubleJumping",false);
        StartCoroutine(WaitforWindEffetc());
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (isWindy)
            {
                animTempete.SetBool("CanEnd", true);
                animTempete.SetBool("CanBegin", false);
                indicationTempeteState = false;
                effet.fadeAway = false;
                
                if (Tempête)
                {
                    if (Character.isGrounded)
                    {
                        rb.AddForce(new Vector2(WindForceNull_X, WindForceNull_Y));
                    }
                    else
                    {
                        rb.AddForce(new Vector2(WindForceNull_X*2, WindForceNull_Y*2));
                    }
                }
                else
                {
                    rb.AddForce(new Vector2(WindForceNull_X, WindForceNull_Y));
                }
            }
            else
            {
                animTempete.SetBool("CanBegin", true);
                animTempete.SetBool("CanEnd", false);
                indicationTempeteState = true;
                effet.fadeAway = true;
                
                if (Tempête)
                {
                    if (Character.isGrounded)
                    {
                        rb.AddForce(new Vector2(WindForce_X, WindForce_Y));
                    }
                    else
                    {
                        rb.AddForce(new Vector2(WindForce_X*2, WindForce_Y*2));
                    }
                }
                else
                {
                    rb.AddForce(new Vector2(WindForceNull_X, WindForceNull_Y));
                }
                
            }
            StartCoroutine(WaitForWind()); 
            StartCoroutine(WaitForLittleWind()); 
        }
        
        if (other.tag == "Respawn")
        {
            if (scriptBoite.boiteGrab == false)
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
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        letsHaveTempete = false;
        isWindy = false;
        if (Tempête)
        {
            anim.SetBool("IsTempete", false);
            anim.SetBool("WalkTempete",false);
        }
        //rb.AddForce(new Vector2(WindForce, 0));
    }

    public IEnumerator WaitForWind()
    {
        while (isWindy)
        {
            if (Tempête)
            {
                anim.SetBool("IsTempete", false);
                anim.SetBool("WalkTempete",false);
                //particulesVent.SetActive(false);
            }
            yield return new WaitForSeconds(timeWaitForWind);
            isWindy = false;
            
            if (Tempête)
            {
                //particulesVent2.SetActive(false);
                //particulesVent.SetActive(true);
            }
            
            yield return new WaitForSeconds(timeWaitForWind);
            isWindy = true;
        }

        if (!isWindy)
        {
            if (Tempête)
            {
                anim.SetBool("IsTempete", true);
                if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1)
                {
                    anim.SetBool("WalkTempete",true);
                }
                else
                {
                    anim.SetBool("WalkTempete",false);
                }
            }
        }
    }


    IEnumerator WaitForLittleWind()
    {
        //particulesVent2.SetActive(true);
        yield return new WaitForSeconds(timeWaitForWind - 2);
    }

    public IEnumerator WaitforWindEffetc()
    {
       
        animTempete.SetBool("CanBegin", true);
        yield return new WaitForSeconds(timeWaitForWind);
        for (int i = 0; i < listEffetVent.Count; i++)
        {
            listEffetVent[i].SetActive(true);
        }
    }
}