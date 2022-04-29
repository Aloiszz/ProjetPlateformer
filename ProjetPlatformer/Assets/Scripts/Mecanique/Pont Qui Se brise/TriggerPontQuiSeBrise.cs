using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using XInputDotNetPure;

public class TriggerPontQuiSeBrise : MonoBehaviour
{
    public bool isTriggered;

    public GameObject mainCamera;
    public Tween tweener;
    public float strengh;
    public int vibration;
    public float randomness;
    
    PlayerIndex playerIndex;
    GamePadState state;
    GamePadState prevState;

    [Header("Vibration Motor")]
    public float leftMotor;
    public float rightMotor;
    public float duration;



    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isTriggered = true;
            tweener = mainCamera.transform.DOShakePosition(8.4f,strengh,vibration,randomness,false,false);
            StartCoroutine(VibrationTime());
        }
        
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isTriggered = false;
        }
        
    }
    
    IEnumerator VibrationTime()
    {
        GamePad.SetVibration(playerIndex, leftMotor-.3f, rightMotor-.3f);
        yield return new WaitForSeconds(duration-5);
        GamePad.SetVibration(playerIndex, leftMotor, rightMotor);
        yield return new WaitForSeconds(duration);
        //GamePad.SetVibration(playerIndex, leftMotor-.3f, rightMotor-.3f);
        //yield return new WaitForSeconds(duration-5);
        GamePad.SetVibration(playerIndex, 0, 0);
    }
}
