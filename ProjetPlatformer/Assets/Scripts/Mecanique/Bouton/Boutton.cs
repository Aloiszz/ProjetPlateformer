using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Boutton : MonoBehaviour
{
    public bool BouttonOn = false;
    
    public GameObject porteAssociée;
    
    public float duréeTranslation;
    public Vector3 directionPorte;
    
    public bool porteOuverte = false;
    public bool porteFermée = true;
    public bool porteAction;
    public bool isAtRange;

    //private Tween tweener;
    //public GameObject mainCamera;
    //public bool cameraShake;

    public Animator animBoite;

    public Image indicationActivate;
    
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
            if (porteAction == false)
            {
                if (Input.GetButtonDown("GrabGamepad")) // si le joueur press la touche interaction
                {
                    BouttonOn = !BouttonOn;
                    
                }
            }
        }
        else
        {
            indicationActivate.enabled = false;
        }
        if (BouttonOn && porteFermée)
        {
            OuverturePorte();
            animBoite.SetBool("ChangeState", true);
            porteFermée = false;
            porteOuverte = true;
        }
        if (!BouttonOn && porteOuverte)
        {
            FermeturePorte();
            animBoite.SetBool("ChangeState", false);
            porteOuverte = false;
            porteFermée = true;
        }
    }

    void OuverturePorte()
    {
        porteAction = true;
        /*if (cameraShake)
        {
            //tweener = mainCamera.transform.DOShakePosition(duréeTranslation,0.2f,10,35,false,false); 
        }*/
        porteAssociée.transform.DOMove(porteAssociée.transform.position + directionPorte, duréeTranslation).OnComplete(
            () =>
            {
                porteAction = false;
            });

    }

    void FermeturePorte()
    {
        porteAction = true;
        /*if (cameraShake)
        {
            //tweener = mainCamera.transform.DOShakePosition(duréeTranslation,0.2f,10,35,false,false); 
        }*/
        porteAssociée.transform.DOMove(porteAssociée.transform.position - directionPorte, duréeTranslation).OnComplete(
            () =>
            {
                porteAction = false;
            });
    }
    
}
