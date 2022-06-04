using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class FadeOutMontagne : MonoBehaviour
{
    public GameObject MontagneFadeOut;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            MontagneFadeOut.GetComponent<SpriteRenderer>().DOFade(0, 0.75f);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            MontagneFadeOut.GetComponent<SpriteRenderer>().DOFade(1, 0.75f);
        }
    }
}
