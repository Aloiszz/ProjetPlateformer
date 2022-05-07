using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class TriggerDisparitionTempête : MonoBehaviour
{
    
    public GameObject BackgroundTempete1;
    public GameObject BackgroundTempete2;
    public GameObject BackgroundTempete3;
    public GameObject BackgroundTempete4;
    public GameObject BackgroundTempete5;
    public GameObject BackgroundTempete6;
    
    public GameObject GlobalVolume;
    private void OnTriggerEnter2D(Collider2D other)
    {
        BackgroundTempete1.GetComponent<SpriteRenderer>().DOFade(0, 2);
        BackgroundTempete2.GetComponent<SpriteRenderer>().DOFade(0, 2);
        BackgroundTempete3.GetComponent<SpriteRenderer>().DOFade(0, 2);
        BackgroundTempete4.GetComponent<SpriteRenderer>().DOFade(0, 2);
        BackgroundTempete5.GetComponent<SpriteRenderer>().DOFade(0, 2);
        BackgroundTempete6.GetComponent<SpriteRenderer>().DOFade(0,2);
        GlobalVolume.SetActive(false);
    }
}
