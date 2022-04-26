using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

public class TriggerMovingPlatform : MonoBehaviour
{

    public List<MovingPlatform> movingPlatform;

    PlayerIndex playerIndex;
    GamePadState state;
    GamePadState prevState;
    public bool doOnce;
    
    [Header("Vibration Motor")]
    public float leftMotor;
    public float rightMotor;
    public float duration;
    //private MovingPlatform movingPlatform;

    private int limit = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!doOnce)
        {
            StartCoroutine(VibrationTime());
            doOnce = true;
        }
        
        if (limit <= 0)
        {
            limit++;
            for (int i = 0; i < movingPlatform.Count; i++)
            {
                movingPlatform[i].Salope();
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
