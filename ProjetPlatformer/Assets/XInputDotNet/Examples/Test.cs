using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

public class Test : MonoBehaviour
{
    
    PlayerIndex playerIndex;
    GamePadState state;
    GamePadState prevState;
    
    [Header("Vibration Motor")]
    public float leftMotor;
    public float rightMotor;
    
    void Update()
    {
        if (Input.GetButtonDown("GrabGamepad"))
        {
            StartCoroutine(VibrationTime());
        }
    }

    IEnumerator VibrationTime()
    {
        GamePad.SetVibration(playerIndex, leftMotor, rightMotor);
        yield return new WaitForSeconds(2);
        GamePad.SetVibration(playerIndex, 0, 0);
    }
}
