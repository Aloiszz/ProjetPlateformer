using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Tonnerre : MonoBehaviour
{ 
    public AudioSource source;
    public bool canMakeNoise = false;
    public EclairBox éclairBox;

    private float time;
    public bool recommencer = false;

    private void Start()
    {
        time = Random.Range(2, 10);
    }

    private void Update()
    {
        if (éclairBox.isInStorm == false)
        {
            Debug.Log("dfsqdqsd");
            StartCoroutine(PlaySound());
        }
    }

    IEnumerator PlaySound()
    {
        yield return new WaitForSeconds(time);
        source.Play();
        yield return new WaitForSeconds(time);
        recommencer = true;
    }
}
