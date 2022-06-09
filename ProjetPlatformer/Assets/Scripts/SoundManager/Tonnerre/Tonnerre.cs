using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Tonnerre : MonoBehaviour
{ 
    public AudioSource source;
    public AudioClip tonnerreSound;
    public bool canMakeNoise = false;
    public WindArea WindArea;

    private float time;

    private void Start()
    {
        time = Random.Range(2, 10);
        Debug.Log(time);
    }

    private void Update()
    {
        if (canMakeNoise && WindArea.letsHaveTempete)
        {
            Invoke("PlaySound", time);
            //StartCoroutine(StartNoise());
        }
    }

    IEnumerator StartNoise()
    {
        yield return new WaitForSeconds(time);
        
        //yield return new WaitForSeconds(time);
    }


    void PlaySound()
    {
        source.PlayOneShot(tonnerreSound, 0.2f); 
    }
}
