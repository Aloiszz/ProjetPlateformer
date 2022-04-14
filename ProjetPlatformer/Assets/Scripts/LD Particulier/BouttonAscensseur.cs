using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class BouttonAscensseur : MonoBehaviour
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
    public Vector3 originalPosition = new Vector3(70.74f,-90.43f,300);
    public GameObject mainCamera;
    public bool cameraShake;

    public DeathZone deathZone;
    
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
                        gameObject.GetComponent<SpriteRenderer>().color = Color.green;
                    }
                
                    if (BouttonOn == false) // ou on l'active
                    {
                        gameObject.GetComponent<SpriteRenderer>().color = Color.red; // on change la couleur du sprite
                    }
                }
            }
        }
        if (BouttonOn && porteFermée)
        {
            OuverturePorte();
            porteFermée = false;
            porteOuverte = true;
        }
        if (!BouttonOn && porteOuverte)
        {
            FermeturePorte();
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