using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArretPiliers : MonoBehaviour
{

    public FermetureSalle2 trigger;
    
    void Start()
    {
        
    }

    
    void OnTriggerEnter2D(Collider2D other)
    {
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
        trigger.activationFrappe = false;
    }
}
