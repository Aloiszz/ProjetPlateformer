using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using XInputDotNetPure;

public class PdPSalleDuHaut : MonoBehaviour
{
    public float timer;
    public float DistancePorteMax;
    public float speedPorte;
    public GameObject porteAssociée;
    public bool boolStop;
    private Tween tweener;
    public GameObject mainCamera;
    
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
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Respawn")
        {
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
        transform.DOMove(transform.position + new Vector3(0,-0.3f,0), 1);
        boolStop = true;
        timer += Time.deltaTime;
        if (timer <= DistancePorteMax)
        {
            porteAssociée.transform.position = Vector3.MoveTowards(porteAssociée.transform.position, porteAssociée.transform.position + Vector3.right,
                speedPorte * Time.deltaTime);
            
            tweener = mainCamera.transform.DOShakePosition(DistancePorteMax,2,1,30,false,true);
        }

        if (timer >= DistancePorteMax)
        {
            boolStop = false;
        }
    }
    
    IEnumerator VibrationTime()
    {
        GamePad.SetVibration(playerIndex, leftMotor, rightMotor);
        yield return new WaitForSeconds(duration);
        GamePad.SetVibration(playerIndex, 0, 0);
    }

}
