using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using XInputDotNetPure;

public class PlaquedePressionRelache : MonoBehaviour
{
    public float timer;
    public float timerFerme;
    public float DistancePorteMax;
    public float speedPorte;
    public GameObject porteAssociée;
    public GameObject porteAssociée2;
    public GameObject porteAssociée3;
    private bool boolStop = false;
    public bool boolStopFerme = false;
    public bool plusieursPortes;
    private Tween tweener;
    public GameObject mainCamera;
    public GameObject particulesAssociées;
    public bool particules;
    public bool ouvertFerme;

    PlayerIndex playerIndex;
    GamePadState state;
    GamePadState prevState;
    private bool doOnce;
    
    [Header("Vibration Motor")]
    public float leftMotor;
    public float rightMotor;
    public float duration;
    

    private void Update()
    {
        if (boolStop == true)
        {
            OuverturePorte();
        }
        
        if (boolStopFerme == true)
        {
            FermeturePorte();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Respawn")
        {
            if (ouvertFerme == false)
            {
                OuverturePorte(); 
            }
            
            if (!doOnce)
            {
                StartCoroutine(VibrationTime());
                doOnce = true;
            }
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Respawn")
        {
            if (ouvertFerme)
            {
                FermeturePorte(); 
            }
            if (!doOnce)
            {
                StartCoroutine(VibrationTime());
                doOnce = true;
            }
        }
    }


    private void FermeturePorte()
    {
        ouvertFerme = false;
        transform.DOMove(transform.position + new Vector3(0,0.04f,0), 1);
        boolStopFerme = true;
        timerFerme += Time.deltaTime;
        if (timerFerme <= DistancePorteMax)
        {
            porteAssociée.transform.position = Vector3.MoveTowards(porteAssociée.transform.position, porteAssociée.transform.position + Vector3.down,
                speedPorte * Time.deltaTime);
            
            tweener = mainCamera.transform.DOShakePosition(DistancePorteMax,1,1,20,false);
            if (particules)
            {
                particulesAssociées.SetActive(true);
            }
            
            if (plusieursPortes)
            {
                porteAssociée2.transform.position = Vector3.MoveTowards(porteAssociée2.transform.position, porteAssociée2.transform.position + Vector3.up,
                    speedPorte * Time.deltaTime);
                
                porteAssociée3.transform.position = Vector3.MoveTowards(porteAssociée3.transform.position, porteAssociée3.transform.position + Vector3.up,
                    speedPorte * Time.deltaTime);
            }
        }

        if (timerFerme >= DistancePorteMax)
        {
            boolStopFerme = false;
            timerFerme = 0;
            if (particules)
            {
                particulesAssociées.SetActive(false);
            }
        }
    }
    
    private void OuverturePorte()
    {
        ouvertFerme = true;
        transform.DOMove(transform.position + new Vector3(0,-0.04f,0), 1);
        boolStop = true;
        timer += Time.deltaTime;
        if (timer <= DistancePorteMax)
        {
            porteAssociée.transform.position = Vector3.MoveTowards(porteAssociée.transform.position, porteAssociée.transform.position + Vector3.up,
                speedPorte * Time.deltaTime);
            
            tweener = mainCamera.transform.DOShakePosition(DistancePorteMax,2,1,20,false);
            if (particules)
            {
                particulesAssociées.SetActive(true);
            }
            
            if (plusieursPortes)
            {
                porteAssociée2.transform.position = Vector3.MoveTowards(porteAssociée2.transform.position, porteAssociée2.transform.position + Vector3.up,
                    speedPorte * Time.deltaTime);
                
                porteAssociée3.transform.position = Vector3.MoveTowards(porteAssociée3.transform.position, porteAssociée3.transform.position + Vector3.up,
                    speedPorte * Time.deltaTime);
            }
        }

        if (timer >= DistancePorteMax)
        {
            boolStop = false;
            timer = 0;
            if (particules)
            {
                particulesAssociées.SetActive(false);
            }
        }
    }
    
    IEnumerator VibrationTime()
    {
        GamePad.SetVibration(playerIndex, leftMotor, rightMotor);
        yield return new WaitForSeconds(duration);
        GamePad.SetVibration(playerIndex, 0, 0);
    }
}
