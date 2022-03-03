using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindArea : MonoBehaviour
{
    public bool isWindy = false;
    public float WindForce = 45f;
    public float WindForceNull = 0f;
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
            rb.AddForce(new Vector2(WindForceNull, 0));
        }
        else
        {
            rb.AddForce(new Vector2(WindForce, 0));
        }
        StartCoroutine(WaitForWind());
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        isWindy = false;
        rb.AddForce(new Vector2(WindForce, 0));
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