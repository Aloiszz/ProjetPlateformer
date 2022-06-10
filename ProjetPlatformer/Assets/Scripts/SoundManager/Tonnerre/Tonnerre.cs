using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Tonnerre : MonoBehaviour
{ 
    public AudioSource source;
    public bool canMakeNoise = false;
    public WindArea WindArea;

    private float time;

    private void Start()
    {
        time = Random.Range(2, 10);
        //Debug.Log(time);
    }

    private void Update()
    {
        if (canMakeNoise && WindArea.letsHaveTempete)
        {
            StartCoroutine(PlaySound());
        }
    }

    IEnumerator PlaySound()
    {
        yield return new WaitForSeconds(time);
        source.Play();
    }
}
