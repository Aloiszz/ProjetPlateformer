using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeRuche : MonoBehaviour
{

    public bool IsAtRange;

    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            IsAtRange = true;
        }
            
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            IsAtRange = false;
        }
            
    }
}
