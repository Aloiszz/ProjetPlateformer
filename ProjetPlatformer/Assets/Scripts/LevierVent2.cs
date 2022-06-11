using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.UI;

public class LevierVent2 : MonoBehaviour
{
    public bool BouttonOn2;
    public LevierVent AutreLevier;
    public Animator anim;
    public GameObject VentAssocié1;
    public GameObject VentAssocié2;
    public GameObject VentAssocié3;
    public GameObject VentSupprimé1;
    public GameObject VentSupprimé2;
    public GameObject VentSupprimé3;
    public Light2D light;

    public AudioSource source;
    
    public bool isAtRange;
    
    public Sprite LevierDroit;
    public Sprite LevierGauche;

    //private Tween tweener;
    //public GameObject mainCamera;
    //public bool cameraShake;
    

    public Image indicationActivate;

    private void Start()
    {
     
        VentSupprimé1.SetActive(false);
        VentSupprimé2.SetActive(false);
        VentSupprimé3.SetActive(false);
        
        VentAssocié1.SetActive(false);
        VentAssocié2.SetActive(false);
        VentAssocié3.SetActive(false);
    }

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

    void Update()
    {

        if (BouttonOn2 == false)
        {
            anim.SetBool("ChangeState",true);
            light.color = Color.green;
        }
        else
        {
            anim.SetBool("ChangeState",false);
            light.color = Color.red;
        }
        
        if (isAtRange == true) // si le joueur est assez proche
        {
            if (!BouttonOn2)
            {
                indicationActivate.enabled = true; 
            }
            else
            {
                indicationActivate.enabled = false;
            }
           
            if (Input.GetButtonDown("GrabGamepad") && BouttonOn2 == false)
            {
                source.Play();
                ActivateWind();
                BouttonOn2 = true;
                AutreLevier.BouttonOn = false;
            }

        }
        else
        {
            indicationActivate.enabled = false;
        }
    }

    public void ActivateWind()
    {
        VentSupprimé1.SetActive(false);
        VentSupprimé2.SetActive(false);
        VentSupprimé3.SetActive(false);
        
        VentAssocié1.SetActive(true);
        VentAssocié2.SetActive(true);
        VentAssocié3.SetActive(true);  
    }
}
