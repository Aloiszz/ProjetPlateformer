using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeBoutton : MonoBehaviour
{
    public bool isAtRange;
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
    
    
