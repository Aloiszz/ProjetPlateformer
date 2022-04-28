using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeBoite : MonoBehaviour
{

    public bool isAtRange;
    private Animator anim;
    public GameObject player;
    public GameObject UIpousser;
    public bool actif = true;
    
    
    
    
    
    void Start()
    {
        UIpousser.SetActive(false);
        anim = player.GetComponent<Animator>();
    }
    
    // On check à quel moment le player est à porté de prendre la boîte
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Player")
            {
                isAtRange = true;
                if (actif)
                {
                UIpousser.SetActive(true);
                }
            }
        }
    
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.tag == "Player")
            {
                isAtRange = false;
                UIpousser.SetActive(false);
                anim.SetBool("IsGrosseBoite", false);
            }
            
        }
}
