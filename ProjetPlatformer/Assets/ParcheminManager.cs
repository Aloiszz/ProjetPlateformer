using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class ParcheminManager : MonoBehaviour
{

    public bool parcheminActif;
    public GameObject filtre;
    public Vector3 posParchemin1;
    public Vector3 posParchemin2;
    public Vector3 posParchemin3;
    public Vector3 posParchemin4;
    public Vector3 posParchemin5;
    public Vector3 posParchemin6;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (parcheminActif)
        {
            filtre.SetActive(true);
        }
        else
        {
            filtre.SetActive(false);
        }
    }
    
    
    public void GetBig()
    {
        transform.DOScale(2,1);
        transform.DOMove(new Vector3(650,300,0),2.5f);
        parcheminActif = true;
    }

    public void GetSmall()
    {
        transform.DOScale(1,1);
        transform.DOMove(new Vector3(0,0,0),2.5f);
        parcheminActif = false;
    }

    public void Agrandissement()
    {
        if(parcheminActif == false)
        {
            transform.DOScale(1.3f,0.5f); 
        }
    }
  
    public void Rappetissement()
    {
        if(parcheminActif == false)
        {
            transform.DOScale(1,0.5f); 
        }
    }
    
    
}
