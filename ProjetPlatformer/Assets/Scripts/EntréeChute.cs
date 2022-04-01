using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using XInputDotNetPure;

public class EntréeChute : MonoBehaviour
{

    PlayerIndex playerIndex;
    GamePadState state;
    GamePadState prevState;
    
    public ParticleSystem particuesEntree;
    public GameObject mainCamera;
    public Tween tweener;

    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("GrosseBoîte"))
        {
            StartCoroutine(VibrationTime());
            tweener = mainCamera.transform.DOShakePosition(1.5f,10,1,35,false);
            particuesEntree.Play();
            Destroy(gameObject);
            
        }
    }
    
    IEnumerator VibrationTime()
    {
        GamePad.SetVibration(playerIndex, 1, 1);
        yield return new WaitForSeconds(2);
        GamePad.SetVibration(playerIndex, 0, 0);
        
    }
    
}
