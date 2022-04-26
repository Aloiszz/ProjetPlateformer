using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlatform : MonoBehaviour
{
    public float timeToDestroy = 1.5f;
    public float timeToReapear = 3f;

    public GameObject platform;

    public Animator AnimDestroy;
    
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(TimeToDestroy());
        }
    }

    IEnumerator TimeToDestroy()
    {
        yield return new WaitForSeconds(timeToDestroy);
        platform.SetActive(false);
        AnimDestroy.SetBool("isVisible", true);
        StartCoroutine(TimeToReapear());
    }
    IEnumerator TimeToReapear()
    {
        yield return new WaitForSeconds(timeToReapear);
        platform.SetActive(true);
        AnimDestroy.SetBool("isVisible", false);
    }
}
