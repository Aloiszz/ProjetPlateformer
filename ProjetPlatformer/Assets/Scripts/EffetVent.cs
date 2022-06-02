using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class EffetVent : MonoBehaviour
{
    public GameObject camera;
    public float xPos;
    public float yPos;
    public bool fadeAway;

    public Animator animTempete;
    public Animator TempeteManager;

    public static EffetVent instance;
    public WindArea windArea;
    
    private SpriteRenderer renderer;
    public ParticleSystem particulesPrevention;

    public GameObject doubleEffetPoussière;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    private void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        animTempete.SetBool("CanBegin", true);
        animTempete.SetBool("CanEnd", false);
    }

    // Update is called once per frame
    public void Update()
    {
        //StartCoroutine(AttenteVent());
       // transform.position = camera.transform.position - new Vector3(xPos, yPos, camera.transform.position.z);
        

        if (windArea.isWindy == false)
        {
            renderer.enabled = true;
            //GetComponent<Animator>().Play("AnimationVent",5);
            animTempete.SetBool("CanBegin", true);
            animTempete.SetBool("CanEnd", false);
            TempeteManager.SetBool("Start",true);
            TempeteManager.SetBool("End",false);
        }
        else 
        {
            renderer.enabled = false;
            animTempete.SetBool("CanEnd", true);
            animTempete.SetBool("CanBegin", false);
            TempeteManager.SetBool("Start",false);
            TempeteManager.SetBool("End",true);
        }
        
    }
    

    IEnumerator AttenteVent()
    {
        if (WindArea.instance.letsHaveTempete)
        {
            particulesPrevention.Play();
            fadeAway = false;
            StartCoroutine(FadeImage());
            GetComponent<Animator>().Play("AnimationVent",5,0);
            transform.DOMove(new Vector3(camera.transform.position.x - 10,transform.position.y+5,transform.position.z), 3);
        
            yield return new WaitForSeconds(1.5f); // de la durée de l'animation
            fadeAway = true;
            StartCoroutine(FadeImage());
            GetComponent<Material>().DOFade(0,0.5f);

            GetComponent<Material>().DOFade(255,0.5f);
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
                doubleEffetPoussière.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, i);
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
                doubleEffetPoussière.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, i);
                yield return null;
            }
        }
    }
    
}
