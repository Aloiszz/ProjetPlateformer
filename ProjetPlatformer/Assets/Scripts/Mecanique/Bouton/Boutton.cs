using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Boutton : MonoBehaviour
{
    public bool BouttonOn = false;
    public GameObject porteAssociée;
    public GameObject porteAssociée2;
    public float duréeTranslation;
    public Vector3 directionPorte;
    public static bool porteOuverte = false;
    public static bool porteFermée = true;
    public static bool porteOuverte2 = false;
    public static bool porteFermée2 = true;
    public bool isAtRange;

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
            if (Input.GetButtonDown("GrabGamepad")) // si le joueur press la touche interaction
            {
                BouttonOn = !BouttonOn;
                if (BouttonOn == true) // on ferme le boutton
                {
                    gameObject.GetComponent<SpriteRenderer>().color = Color.green;
                }
                
                if (BouttonOn == false) // ou on l'active
                {
                    gameObject.GetComponent<SpriteRenderer>().color = Color.red; // on change la couleur du sprite
                }
            }
        }
        if (BouttonOn && porteFermée)
        {
            OuverturePorte();
            porteFermée = false;
            porteOuverte = true;
        }
        
        if (BouttonOn && porteFermée2)
        {
            OuverturePorte2();
            porteFermée2 = false;
            porteOuverte2 = true;
        }
        
        if (!BouttonOn && porteOuverte)
        {
            FermeturePorte();
            porteOuverte = false;
            porteFermée = true;
        }
        
        if (!BouttonOn && porteOuverte2)
        {
            FermeturePorte2();
            porteOuverte2 = false;
            porteFermée2 = true;
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
    
    void OuverturePorte2()
    {
        porteAssociée2.transform.DOMove(porteAssociée2.transform.position + directionPorte, duréeTranslation);
    }

    void FermeturePorte2()
    {
        porteAssociée2.transform.DOMove(porteAssociée2.transform.position - directionPorte, duréeTranslation);
    }
    
}
