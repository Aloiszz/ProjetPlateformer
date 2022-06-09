using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentAscendant : MonoBehaviour
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
    public static VentAscendant instance;
    
    public AudioSource VentNormaux;
    
    
    private void Awake()
    {
        rb = Character.GetComponent<Rigidbody2D>();
        if (instance == null) instance = this;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        isWindy = true;
        anim.SetBool("isDoubleJumping",false);
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Respawn")
        {
            VentNormaux.Play();  
        }
        
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (isWindy)
            {

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
    
}
