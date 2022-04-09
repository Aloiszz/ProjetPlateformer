using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

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

    private Tween tweener;
    public GameObject mainCamera;
    public bool cameraShake;

    public Animator animBoite;
    
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
            if (porteAction == false)
            {
                if (Input.GetButtonDown("GrabGamepad")) // si le joueur press la touche interaction
                {
                    BouttonOn = !BouttonOn;
                    if (BouttonOn == true) // on ferme le boutton
                    {
                        //gameObject.GetComponent<SpriteRenderer>().color = Color.green;
                    }
                
                    if (BouttonOn == false) // ou on l'active
                    {
                        //gameObject.GetComponent<SpriteRenderer>().color = Color.red; // on change la couleur du sprite
                    }
                }
            }
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
        if (cameraShake)
        {
            tweener = mainCamera.transform.DOShakePosition(duréeTranslation,0.2f,10,35,false,false); 
        }
        porteAssociée.transform.DOMove(porteAssociée.transform.position + directionPorte, duréeTranslation).OnComplete(
            () =>
            {
                porteAction = false;
            });

    }

    void FermeturePorte()
    {
        porteAction = true;
        if (cameraShake)
        {
            tweener = mainCamera.transform.DOShakePosition(duréeTranslation,0.2f,10,35,false,false); 
        }
        porteAssociée.transform.DOMove(porteAssociée.transform.position - directionPorte, duréeTranslation).OnComplete(
            () =>
            {
                porteAction = false;
            });
    }
    
}
