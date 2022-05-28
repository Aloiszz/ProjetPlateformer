using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class TriggerApparitionBackgroundTempête : MonoBehaviour
{
    public GameObject BackgroundTempete1;
    public GameObject BackgroundTempete2;
    public GameObject BackgroundTempete3;
    public GameObject BackgroundTempete4;
    public GameObject BackgroundTempete5;
    public GameObject BackgroundTempete6;
    public GameObject Barre2;
    public GameObject Barre1;
    public float DistanceBarres;
    public float DistanceBarres2;
    


    public Animator playerAnim;
    public GameObject GlobalVolume;
    
    public GameObject EmptyDéplaTempete;
    private void OnTriggerEnter2D(Collider2D other)
    {
        StartCoroutine(CinematiqueTempête());
        
    }


    IEnumerator CinematiqueTempête()
    {
        float newPosPage1 = Barre1.transform.position.y - DistanceBarres;
        float newPosPage2 = Barre2.transform.position.y - DistanceBarres2;
        Barre1.transform.DOMove(new Vector3(Barre1.transform.position.x,-newPosPage1,Barre1.transform.position.z), 1.5f);
        Barre2.transform.DOMove(new Vector3(Barre2.transform.position.x,newPosPage2,Barre2.transform.position.z), 1.5f);
        CharacterMovement.instance.blockCinematiques = true;
        CharacterMovement.instance.canMove = false;
        CharacterMovement.instance.canJump = false;
        CharacterMovement.instance.speed = 0;
        playerAnim.Rebind();
        playerAnim.Play("Player_Idle");
        BackgroundTempete1.transform.DOMove(EmptyDéplaTempete.transform.position, 4.5f).OnComplete((() => BackgroundTempete1.GetComponent<ParallaxTempête>().enabled = true));
        BackgroundTempete2.transform.DOMove(EmptyDéplaTempete.transform.position, 4.5f).OnComplete((() => BackgroundTempete2.GetComponent<ParallaxTempête>().enabled = true));
        BackgroundTempete3.transform.DOMove(EmptyDéplaTempete.transform.position, 4.5f).OnComplete((() => BackgroundTempete3.GetComponent<ParallaxTempête>().enabled = true));
        BackgroundTempete4.transform.DOMove(EmptyDéplaTempete.transform.position, 4.5f).OnComplete((() => BackgroundTempete4.GetComponent<ParallaxTempête>().enabled = true));
        BackgroundTempete5.transform.DOMove(EmptyDéplaTempete.transform.position, 4.5f).OnComplete((() => BackgroundTempete5.GetComponent<ParallaxTempête>().enabled = true));
        BackgroundTempete6.transform.DOMove(EmptyDéplaTempete.transform.position, 4.5f).OnComplete((() => BackgroundTempete6.GetComponent<ParallaxTempête>().enabled = true));
        yield return new WaitForSeconds(2.5f);
        GlobalVolume.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        float newPosPage3 = Barre1.transform.position.y + DistanceBarres;
        float newPosPage4 = Barre2.transform.position.y + DistanceBarres2;
        Barre1.transform.DOMove(new Vector3(Barre1.transform.position.x,newPosPage3,Barre1.transform.position.z), 1.5f);
        Barre2.transform.DOMove(new Vector3(Barre2.transform.position.x,newPosPage4,Barre2.transform.position.z), 1.5f);
        CharacterMovement.instance.canMove = true;
        CharacterMovement.instance.canJump = true;
        CharacterMovement.instance.speed = 11;
        CharacterMovement.instance.blockCinematiques = false;
        gameObject.SetActive(false);
    }
}
