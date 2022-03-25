using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class BoutonTimer : MonoBehaviour
{
     public bool BouttonOn = false;
    public GameObject porteAssociée;
    public float duréeTranslation;
    public float duréeFermeture;
    public Vector3 directionPorte;
    public  bool porteOuverte = false;
    public  bool porteFermée = true;
    public bool porteEnAction;
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
        
        if (BouttonOn == true) // on ferme le boutton
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.green;
        }
                
        if (BouttonOn == false) // ou on l'active
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.red; // on change la couleur du sprite
        }

        if (porteEnAction == false)
        {
            if (isAtRange == true) // si le joueur est assez proche
            {
                if (Input.GetButtonDown("GrabGamepad")) // si le joueur press la touche interaction
                {
                    BouttonOn = !BouttonOn;
                }
            } 
        }
        
        if (BouttonOn && porteFermée)
        {
            OuverturePorte();
            porteFermée = false;
            porteOuverte = true;
        }
        
        
       /* if (!BouttonOn && porteOuverte)
        {
          //  FermeturePorte();
            porteOuverte = false;
            porteFermée = true;
        }*/

    }

    void OuverturePorte()
    {
        porteEnAction = true;
        porteAssociée.transform.DOMove(porteAssociée.transform.position + directionPorte, duréeTranslation).OnComplete(
            () =>
                porteAssociée.transform.DOMove(porteAssociée.transform.position - directionPorte, duréeFermeture)
                    .OnComplete((() => porteFermée = true)).OnComplete((() => porteEnAction = false)));
        BouttonOn = false;
    }
}
