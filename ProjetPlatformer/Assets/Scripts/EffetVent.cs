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

    public Animator animTempete;

    public static EffetVent instance;
    public WindArea windArea;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    private void Start()
    {
        animTempete.SetBool("CanBegin", true);
        animTempete.SetBool("CanEnd", false);
    }

    // Update is called once per frame
    public void Update()
    {
        //StartCoroutine(AttenteVent());
        transform.position = camera.transform.position - new Vector3(xPos, yPos, camera.transform.position.z);
        

        if (windArea.isWindy == false)
        {
            //GetComponent<Animator>().Play("AnimationVent",5);
            animTempete.SetBool("CanBegin", true);
            animTempete.SetBool("CanEnd", false);
        }
        else 
        {
            animTempete.SetBool("CanEnd", true);
            animTempete.SetBool("CanBegin", false);
        }
    }
    

    IEnumerator AttenteVent()
    {
        if (WindArea.instance.letsHaveTempete)
        {
            GetComponent<Animator>().Play("AnimationVent",5,0);
            //transform.DOMove(new Vector3(camera.transform.position.x - 10,transform.position.y+5,transform.position.z), 3);
        
            yield return new WaitForSeconds(1.5f); // de la durée de l'animation
            GetComponent<Material>().DOFade(0,0.5f);

            GetComponent<Material>().DOFade(255,0.5f);
        }
        
    }
}
