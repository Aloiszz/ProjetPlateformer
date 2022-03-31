using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parchemin2 : MonoBehaviour
{
  
    public ParcheminManager pm;
    public ParticleSystem particulesParchemin;
    

    // Update is called once per frame

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
           // pm.getParchemin2 = true;
            particulesParchemin.Play(true);
            gameObject.SetActive(false);
        }
    }
    
}
