using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using XInputDotNetPure;

public class PlaqueDePression : MonoBehaviour
{
    public float timer;
    public float DistancePorteMax;
    public float speedPorte;
    public GameObject porteAssociée;
    public GameObject porteAssociée2;
    public GameObject porteAssociée3;
    private bool boolStop = false;
    public bool plusieursPortes;
    private Tween tweener;
    public GameObject mainCamera;
    public GameObject particulesAssociées;
    public bool particules;
    public Vector3 enfoncement;
    public GameObject impultionElectique;

    public bool haveParticle = false;
    public ParticleSystem particle;
    public GameObject particleLocation;
    
    PlayerIndex playerIndex;
    GamePadState state;
    GamePadState prevState;
    private bool doOnce;
    
    [Header("Vibration Motor")]
    public float leftMotor;
    public float rightMotor;
    public float duration;

    public AudioSource AudioData;
    public AudioSource sourceBoite;

    private void Update()
    {
        if (boolStop == true)
        {
            OuverturePorte();
        }
    }

    IEnumerator StopSoundBoite()
    {
        sourceBoite.mute = true;
        yield return new WaitForSeconds(2.3f);
        sourceBoite.mute = false;
    }

    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Respawn")
        {
            StartCoroutine(StopSoundBoite());
            AudioData.Play();
            OuverturePorte(); 
            if (!doOnce)
            {
                StartCoroutine(VibrationTime());
                doOnce = true;
            }
        }
    }

    private void OuverturePorte()
    {
        impultionElectique.SetActive(true);
        transform.DOMove(transform.position + enfoncement, 1);
        boolStop = true;
        timer += Time.deltaTime;
        if (timer <= DistancePorteMax)
        {
            porteAssociée.transform.position = Vector3.MoveTowards(porteAssociée.transform.position, porteAssociée.transform.position + Vector3.up,
                speedPorte * Time.deltaTime);
            
            tweener = mainCamera.transform.DOShakePosition(DistancePorteMax,2,1,20,false);
            if (haveParticle)
            {
                //Instantiate(particle, particleLocation.transform.position, quaternion.identity);
                particle.Play();
            }
            
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
