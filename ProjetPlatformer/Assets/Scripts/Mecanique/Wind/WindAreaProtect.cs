using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindAreaProtect : MonoBehaviour
{
    public WindArea WindArea;
    
    public float WindForce_X = 0f;
    public float WindForceNull_X = 0f;
    
    public float timeWaitForWind = 3f;
    
    public CharacterMovement Character;
    private Rigidbody2D rb;
    
    
    private void Awake()
    {
        rb = Character.GetComponent<Rigidbody2D>();
    }
    

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (WindArea.isWindy)
            {
                
                rb.AddForce(new Vector2(WindForceNull_X, 0));
            }
            else
            {
                rb.AddForce(new Vector2(WindForce_X, 0));
            }
            StartCoroutine(WaitForWind()); 
        }
        
    }
    
    IEnumerator WaitForWind()
    {
        while (WindArea.isWindy)
        {
            yield return new WaitForSeconds(timeWaitForWind);
            WindArea.isWindy = false;
            yield return new WaitForSeconds(timeWaitForWind);
            WindArea.isWindy = true;
        }
    }
}
