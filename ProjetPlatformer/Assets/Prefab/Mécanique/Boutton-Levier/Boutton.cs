using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Boutton : MonoBehaviour
{

    
    public bool BouttonOn;
    public KeyCode bouttonInteraction = KeyCode.UpArrow;
    public RangeBoutton range;
    public GameObject porteAssociée;
    public float duréeTranslation;
    public Vector3 directionPorte;
    public bool porteOuverte;
    public bool porteFermée = true;


    void Update()
    {
        if (range.isAtRange == true) // si le joueur est assez proche
        {
            if (Input.GetKeyDown(bouttonInteraction)) // si le joueur press la touche interaction
            {
                if (BouttonOn == true) // on ferme le boutton
                {
                    Debug.Log("fermeture");
                    BouttonOn = false;
                }
                
                if (BouttonOn == false) // ou on l'active
                {
                    BouttonOn = true;
                }
            }
        }

        if (BouttonOn)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.green;
        }
        
        if (BouttonOn == false)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.red; // on change la couleur du sprite
        }
        
        if (!BouttonOn && porteFermée)
        {
            OuverturePorte();
            porteFermée = false;
            porteOuverte = true;
        }
        
        if (BouttonOn && porteOuverte)
        {
            FermeturePorte();
            porteOuverte = false;
            porteFermée = true;
        }
    }

    void OuverturePorte()
    {
        porteAssociée.transform.DOMove(porteAssociée.transform.position + directionPorte, duréeTranslation);
    }

    void FermeturePorte()
    {
        porteAssociée.transform.DOMove(porteAssociée.transform.position - directionPorte, duréeTranslation);
    }
    
}
