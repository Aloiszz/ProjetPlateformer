using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;
using DG.Tweening;

public class DebutTriggerPiqueQuiBougent : MonoBehaviour
{
    
    [SerializeField] private List<ClapetVent> waypoints;
    [SerializeField] private float moveSpeed = 5f;

    private int DoOnce = 0;
    
    PlayerIndex playerIndex;
    GamePadState state;
    GamePadState prevState;
    private bool doOnce;

    public AudioSource source;
    
    [Header("Vibration Motor")]
    public float leftMotor;
    public float rightMotor;
    public float duration;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
           
            if (DoOnce == 0)
            {
                source.Play();
                DoOnce++;
                StartCoroutine(Tamere());
                StartCoroutine(Wait());
                StartCoroutine(VibrationTime());
            }
        }
    }
    
    IEnumerator Tamere()
    {
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < waypoints.Count; i++)
        {
            waypoints[i].transform.DOScale(new Vector3(0.8f,0.8f, 1), 1f);
            waypoints[i].transform.DORotate(new Vector3(0,0, -720), 1.5f);         
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2.5f);
        
        for (int i = 0; i < waypoints.Count; i++)
        {
            waypoints[i].moveSpeed = moveSpeed;
        }
    }
    
    IEnumerator VibrationTime()
    {
        GamePad.SetVibration(playerIndex, leftMotor, rightMotor);
        yield return new WaitForSeconds(duration);
        GamePad.SetVibration(playerIndex, 0, 0);
    }
}
