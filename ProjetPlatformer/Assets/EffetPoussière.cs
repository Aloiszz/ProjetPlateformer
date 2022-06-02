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
        if (windArea.letsHaveTempete)
        {
            StartCoroutine(FadeImage());
            yield return new WaitForSeconds(1.5f);
            StartCoroutine(FadeImage());
        }
        
    }
    
    IEnumerator FadeImage()
    {
        // fade from opaque to transparent
        if (fadeAway)
        {
            gameObject.GetComponent<SpriteRenderer>().DOFade(1, 1.5f);
            yield return null;
            
            /*for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
                gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, i);
                
            }*/
        }
        
        else
        {
            gameObject.GetComponent<SpriteRenderer>().DOFade(0, 1.5f);
            yield return null;
            /*for (float i = 0; i <= 1; i += Time.deltaTime)
            {
                gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, i);
                
            }*/
        }
    }
}
