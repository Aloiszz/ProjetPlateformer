using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusiqueTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        StartCoroutine(Music());
    }
    
    
    IEnumerator Music()
    {
        MuqiqueManager.instance.GrossePorte = true;
        yield return new WaitForSeconds(0.5f);
        MuqiqueManager.instance.GrossePorte = false; 
    }
}
