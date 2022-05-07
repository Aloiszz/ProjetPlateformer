using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeBoite : MonoBehaviour
{

    public bool isAtRange;
    private Animator anim;
    public GameObject player;
    public GameObject UIpousser;
    public GameObject UIGrab;
    public bool actif = true;
    public bool grosseBoite;
    
    
    
    
    
    void Start()
    {
        if (grosseBoite)
        {
            UIpousser.SetActive(false);
        }
        anim = player.GetComponent<Animator>();
    }
    
    // On check à quel moment le player est à porté de prendre la boîte
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Player")
            {
                UIGrab.SetActive(true);
                isAtRange = true;
                if (actif && grosseBoite)
                {
                    UIpousser.SetActive(true);
                }
            }
        }
    
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.tag == "Player")
            {
                UIGrab.SetActive(false);
                isAtRange = false;
                if (grosseBoite)
                {
                    UIpousser.SetActive(false);
                    anim.SetBool("IsGrosseBoite", false);
                }
               
            }
            
        }
}
