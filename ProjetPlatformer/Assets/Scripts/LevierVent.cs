using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class LevierVent : MonoBehaviour
{
     public bool BouttonOn = false;
    
    public GameObject VentAssocié1;
    public GameObject VentAssocié2;
    public GameObject VentAssocié3;
    public GameObject VentSupprimé1;
    public GameObject VentSupprimé2;
    public GameObject VentSupprimé3;
    
    public bool isAtRange;

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
        if (isAtRange == true) // si le joueur est assez proche
        {
            indicationActivate.enabled = true;
            if (Input.GetButtonDown("GrabGamepad")) // si le joueur press la touche interaction
                {
                    VentAssocié1.SetActive(true);
                    VentAssocié2.SetActive(true);
                    VentAssocié3.SetActive(true);
            
                    VentSupprimé1.SetActive(false);
                    VentSupprimé2.SetActive(false);
                    VentSupprimé3.SetActive(false);
                }
        }
        else
        {
            indicationActivate.enabled = false;
        }

    }
}
