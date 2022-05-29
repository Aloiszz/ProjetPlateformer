using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RespawnBoite : MonoBehaviour
{
    // Start is called before the first frame update
    
    public Transform TpBoite;
    public bool lache;
    public ParticleSystem éclair;
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Respawn")
        {
            GrabBoite.grabBoiteinstance.boiteGrab = false;
            GrabBoite.grabBoiteinstance.GetComponent<SpriteRenderer>().DOFade(0, 5f);
            other.transform.position = TpBoite.position;
            StartCoroutine("lachelaboitedetesmorts");
            éclair.Play();
        }
        
       
    }


    public IEnumerator lachelaboitedetesmorts()
    {
        lache = true;
        yield return new WaitForSeconds(0.1f);
        lache = false;
    }
}
