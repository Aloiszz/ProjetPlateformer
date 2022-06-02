using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class EffetPoussière : MonoBehaviour
{
    
    public WindArea windArea;
    public bool fadeAway;
    

    private void Update()
    {
        StartCoroutine(AttenteVent());
    }


    IEnumerator AttenteVent()
    {
        if (WindArea.instance.letsHaveTempete)
        {
            gameObject.SetActive(true);
            fadeAway = false;
            StartCoroutine(FadeImage());
            yield return new WaitForSeconds(1.5f);
            gameObject.SetActive(false);// de la durée de l'animation
            fadeAway = true;
            StartCoroutine(FadeImage());
        }
        
    }
    
    IEnumerator FadeImage()
    {
        // fade from opaque to transparent
        if (fadeAway)
        {
            // loop over 1 second backwards
            for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
                // set color with i as alpha
                gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, i);
                yield return null;
            }
        }
        // fade from transparent to opaque
        else
        {
            // loop over 1 second
            for (float i = 0; i <= 1; i += Time.deltaTime)
            {
                // set color with i as alpha
                gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, i);
                yield return null;
            }
        }
    }
}
