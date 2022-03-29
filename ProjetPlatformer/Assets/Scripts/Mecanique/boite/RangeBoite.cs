using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeBoite : MonoBehaviour
{

    public bool isAtRange;
    
    // On check à quel moment le player est à porté de prendre la boîte
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Player")
            {
                isAtRange = true;
            }
        }
    
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.tag == "Player")
            {
                isAtRange = false;
            }
        }
}