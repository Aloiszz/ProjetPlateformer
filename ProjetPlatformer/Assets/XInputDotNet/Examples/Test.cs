using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

public class Test : MonoBehaviour
{
    
    PlayerIndex playerIndex;
    GamePadState state;
    GamePadState prevState;
    
    
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("JumpGamepad"))
        {
            StartCoroutine(VibrationTime());
        }
    }

    IEnumerator VibrationTime()
    {
        GamePad.SetVibration(playerIndex, 1, 1);
        yield return new WaitForSeconds(0.5f);
        GamePad.SetVibration(playerIndex, 0, 0);
    }
}
