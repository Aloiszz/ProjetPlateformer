using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tonnerre : MonoBehaviour
{ 
    public AudioSource AudioData;
    public bool canMakeNoise = false;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (canMakeNoise)
        {
            StartCoroutine(StartNoise());
        }
    }

    IEnumerator StartNoise()
    {
        yield return new WaitForSeconds(4);
        AudioData.Play();
        yield return new WaitForSeconds(0.8f);
    }
}
