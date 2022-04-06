using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnBoite : MonoBehaviour
{
    // Start is called before the first frame update
    
    public Transform TpBoite;
    public bool lache;
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Respawn")
        {
            GrabBoite.grabBoiteinstance.boiteGrab = false;
            other.transform.position = TpBoite.position;
            StartCoroutine("lachelaboitedetesmorts");
        }
        
       
    }


    public IEnumerator lachelaboitedetesmorts()
    {
        lache = true;
        yield return new WaitForSeconds(1);
        lache = false;
    }
}
