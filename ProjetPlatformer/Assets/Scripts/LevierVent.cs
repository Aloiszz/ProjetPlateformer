using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

using UnityEngine.UI;

public class LevierVent : MonoBehaviour
{
    public bool BouttonOn = false;
    public LevierVent2 AutreLevier;
    public Animator anim;
    public GameObject VentAssocié1;
    public GameObject VentAssocié2;
    public GameObject VentAssocié3;
    public GameObject VentSupprimé1;
    public GameObject VentSupprimé2;
    public GameObject VentSupprimé3;
    public UnityEngine.Rendering.Universal.Light2D light;
    
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
        if (BouttonOn == false)
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
            if (!BouttonOn)
            {
                indicationActivate.enabled = true; 
            }
            else
            {
                indicationActivate.enabled = false;
            }
            if (Input.GetButtonDown("GrabGamepad") && BouttonOn == false)
            {
                ActivateWind();
                BouttonOn = true;
                AutreLevier.BouttonOn2 = false;
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
