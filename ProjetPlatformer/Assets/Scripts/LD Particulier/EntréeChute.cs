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
    public ParticleSystem particuesEntree2;
    public GameObject mainCamera;
    public Tween tweener;
    public RangeBoite boite;

    public AudioSource AudioData;

    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("GrosseBoîte"))
        {
            StartCoroutine(VibrationTime());
            tweener = mainCamera.transform.DOShakePosition(1.2f,2,15,20,false,false);
            particuesEntree.Play();
            particuesEntree2.Play();
            AudioData.Play();
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            boite.actif = false;
        }
    }
    
    IEnumerator VibrationTime()
    {
        GamePad.SetVibration(playerIndex, 1, 1);
        yield return new WaitForSeconds(2);
        GamePad.SetVibration(playerIndex, 0, 0);
    }
}
