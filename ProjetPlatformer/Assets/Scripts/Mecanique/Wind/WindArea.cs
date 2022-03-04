using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindArea : MonoBehaviour
{
    private bool isWindy = false;
    public float WindForce_X = 45f;
    public float WindForceNull_X = 0f;
    public float WindForce_Y = 45f;
    public float WindForceNull_Y = 0f;
    
    public float timeWaitForWind = 3f;
    
    public CharacterMovement Character;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = Character.GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        isWindy = true;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (isWindy)
        {
            rb.AddForce(new Vector2(WindForceNull_X, WindForceNull_Y));
        }
        else
        {
            rb.AddForce(new Vector2(WindForce_X, WindForce_Y));
        }
        StartCoroutine(WaitForWind());
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        //StopCoroutine(WaitForWind());
        isWindy = false;
        //rb.AddForce(new Vector2(WindForce, 0));
    }

    IEnumerator WaitForWind()
    {
        while (isWindy)
        {
            yield return new WaitForSeconds(timeWaitForWind);
            isWindy = false;
            yield return new WaitForSeconds(timeWaitForWind);
            isWindy = true;
        }
    }
}