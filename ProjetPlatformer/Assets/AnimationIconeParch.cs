using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class AnimationIconeParch : MonoBehaviour
{
    public bool NewParchemin;
    
    private void Update()
    {
        if (NewParchemin)
        {
            StartCoroutine(Animation());
        }
        else
        {
            StopCoroutine(Animation());
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    IEnumerator Animation()
    {
        transform.DOScale(3, 2);
        yield return new WaitForSeconds(2.1f);
        transform.DOScale(-3, 2);
        yield return new WaitForSeconds(2.1f);
    }
}
