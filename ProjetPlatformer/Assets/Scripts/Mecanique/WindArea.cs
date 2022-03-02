using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindArea : MonoBehaviour
{
    public bool isWindy = false;
    public float WindForce = 45f;
    public float timeWaitForWind = 3f;
    public CharacterMovement Character;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = Character.GetComponent<Rigidbody2D>();
    }
    

    private void OnTriggerStay2D(Collider2D other)
    {
        rb.AddForce(new Vector2(WindForce, 0));
        //StartCoroutine(WaitForWind());
    } 

    private void OnTriggerExit2D(Collider2D other)
    {
        isWindy = false;
    }

    IEnumerator WaitForWind()
    {
        yield return new WaitForSeconds(timeWaitForWind);
        isWindy = true;
    }
}
