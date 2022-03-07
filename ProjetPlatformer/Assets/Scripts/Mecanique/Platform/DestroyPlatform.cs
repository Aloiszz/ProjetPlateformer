using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlatform : MonoBehaviour
{
    public float timeToDestroy = 1.5f;
    public float timeToReapear = 3f;

    public GameObject platform;
    
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        StartCoroutine(TimeToDestroy());
    }

    IEnumerator TimeToDestroy()
    {
        yield return new WaitForSeconds(timeToDestroy);
        platform.SetActive(false);
        StartCoroutine(TimeToReapear());
    }
    IEnumerator TimeToReapear()
    {
        Debug.Log(("fefef"));
        yield return new WaitForSeconds(timeToReapear);
        platform.SetActive(true);
    }
}