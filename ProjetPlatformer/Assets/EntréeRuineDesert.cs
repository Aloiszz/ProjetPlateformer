using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EntréeRuineDesert : MonoBehaviour
{
    public GameObject plateforme;
    public Tilemap TilemapFadeOut;
    public Animator anim;
    public ParticleSystem particulesBrisePlateforme;
    private Tween tweener;
    public GameObject MainCamera;


    private void OnTriggerEnter2D(Collider2D other)
    {
        StartCoroutine(BriserPlateforme());
    }

    IEnumerator BriserPlateforme()
    {
        tweener = MainCamera.transform.DOShakePosition(2,10,1,20,false);
        yield return new WaitForSeconds(1f);
        plateforme.SetActive(false);
        particulesBrisePlateforme.Play();
        yield return new WaitForSeconds(0.5f);
        TilemapFadeOut.GetComponent<TilemapRenderer>().material.DOFade(255, 1);
        anim.SetBool("IsFadeOut",true);
        

    }
}
