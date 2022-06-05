using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class TriggerDisparitionTempête : MonoBehaviour
{
    public float nouvelleVitesseNuages;
    public GameObject triggerTempete;
    public Light2D globalLight;
    
    public GameObject BackgroundTempete1;
    public GameObject BackgroundTempete2;
    public GameObject BackgroundTempete3;
    public GameObject BackgroundTempete4;
    public GameObject BackgroundTempete5;
    public GameObject BackgroundTempete6;

    public GameObject effetVent1;
    public GameObject effetVent2;
    public GameObject effetVent3;
    public GameObject effetVent4;
    public GameObject effetVent5;

    public GameObject effetPoussière;
    public GameObject planetes;
    public GameObject ciel;
    public GameObject nuage1;
    public GameObject nuage2;
    public GameObject nuage3;
    public GameObject nuage4;
    public GameObject nuage5;
    public GameObject nuage6;
    public GameObject nuageSup1;
    public GameObject nuageSup2;
    public GameObject nuageSup3;
    public GameObject nuageSup4;
    public GameObject nuageSup5;
    public GameObject nuageSup6;
    public GameObject nuageSup7;
    public GameObject nuageSup8;
    public GameObject nuageSup9;
    public GameObject nuageSup10;
    public Sprite nuageSprite1;
    public Sprite nuageSprite2;
    public Sprite nuageSprite3;
    public Sprite nuageSprite4;
    public Sprite nuageSprite5;
    public Sprite nuageSprite6;
    public Sprite cielSprite1;
    public List<GameObject> WindZone;
    public List<GameObject> DecorMontagne;
    public List<GameObject> FondUnisMontagne;

    public List<GameObject> animTempete;
    private bool doOnce = false;

    private void Update()
    {
        if (doOnce)
        {
            if (globalLight.intensity >= 0.3f)
            {
                globalLight.intensity -= 0.2f * Time.deltaTime;
            }
        }
        
    }


    public GameObject GlobalVolume;
    private void OnTriggerEnter2D(Collider2D other)
    {
        doOnce = true;
        
        for (int i = 0; i < WindZone.Count; i++)
        {
            WindZone[i].SetActive(false);
        }
        
        effetPoussière.SetActive(false);
        planetes.SetActive(false);
        nuageSup1.SetActive(true);
        nuageSup2.SetActive(true);
        nuageSup3.SetActive(true);
        nuageSup4.SetActive(true);
        nuageSup5.SetActive(true);
        nuageSup6.SetActive(true);
        nuageSup7.SetActive(true);
        nuageSup8.SetActive(true);
        nuageSup9.SetActive(true);
        nuageSup10.SetActive(true);
        
        effetVent1.SetActive(false);
        effetVent2.SetActive(false);
        effetVent3.SetActive(false);
        effetVent4.SetActive(false);
        effetVent5.SetActive(false);
        
        ciel.GetComponent<SpriteRenderer>().sprite = cielSprite1;
        nuage1.GetComponent<SpriteRenderer>().sprite = nuageSprite1;
        nuage2.GetComponent<SpriteRenderer>().sprite = nuageSprite2;
        nuage3.GetComponent<SpriteRenderer>().sprite = nuageSprite3;
        nuage4.GetComponent<SpriteRenderer>().sprite = nuageSprite4;
        nuage5.GetComponent<SpriteRenderer>().sprite = nuageSprite5;
        nuage6.GetComponent<SpriteRenderer>().sprite = nuageSprite6;
        nuage1.GetComponent<DéplacementNuages>().parallaxSpeedX = nouvelleVitesseNuages;
        nuage2.GetComponent<DéplacementNuages>().parallaxSpeedX = nouvelleVitesseNuages;
        nuage3.GetComponent<DéplacementNuages>().parallaxSpeedX = nouvelleVitesseNuages;
        nuage4.GetComponent<DéplacementNuages>().parallaxSpeedX = nouvelleVitesseNuages;
        nuage5.GetComponent<DéplacementNuages>().parallaxSpeedX = nouvelleVitesseNuages;
        nuage6.GetComponent<DéplacementNuages>().parallaxSpeedX = nouvelleVitesseNuages;
        
        
        
        BackgroundTempete1.GetComponent<SpriteRenderer>().DOFade(0, 2);
        BackgroundTempete2.GetComponent<SpriteRenderer>().DOFade(0, 2);
        BackgroundTempete3.GetComponent<SpriteRenderer>().DOFade(0, 2);
        BackgroundTempete4.GetComponent<SpriteRenderer>().DOFade(0, 2);
        BackgroundTempete5.GetComponent<SpriteRenderer>().DOFade(0, 2);
        BackgroundTempete6.GetComponent<SpriteRenderer>().DOFade(0,2);
        triggerTempete.SetActive(true);
        GlobalVolume.SetActive(false);

        for (int i = 0; i < DecorMontagne.Count; i++)
        {
            DecorMontagne[i].GetComponent<SpriteRenderer>().color = new Color(0.5f, 0.5f, 0.5f, 1);
        }
        
        for (int i = 0; i < FondUnisMontagne.Count; i++)
        {
            FondUnisMontagne[i].GetComponent<SpriteRenderer>().color = new Color(0.2f, 0.1f, 0.1f, 1);
        }
        
        for (int i = 0; i < animTempete.Count; i++)
        {
            animTempete[i].SetActive(false);
        }
    }
}
