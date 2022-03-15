using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Boutton : MonoBehaviour
{

    private bool BouttonOn = false;
    public KeyCode bouttonInteraction = KeyCode.UpArrow;
    public RangeBoutton range;
    public GameObject porteAssociée;
    public float duréeTranslation;
    public Vector3 directionPorte;
    public bool stopPorte;


    void Update()
    {
        if (range.isAtRange == false)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        }
        
        if (range.isAtRange == true)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.green;
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (BouttonOn == true)
                {
                    BouttonOn = false;
                }
                
                if (BouttonOn == false)
                {
                    BouttonOn = true;
                }
            }
        }

        if (BouttonOn == true && !stopPorte)
        {
            OuverturePorte();
            stopPorte = true;
        }
        


    }

    void OuverturePorte()
    {
        porteAssociée.transform.DOMove(porteAssociée.transform.position + directionPorte, duréeTranslation);
        Debug.Log("zf");
    }
    
}
