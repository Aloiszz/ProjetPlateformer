using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class FermetureSalle2 : MonoBehaviour
{
    public float timer;
    public float DistancePorteMax;
    public float speedPorte;
    public GameObject porteAssociée;
    public GameObject porteAssociée2;
    public GameObject porteAssociée3;
    private bool boolStop = false;
    public bool plusieursPortes;
    private Tween tweener;
    public GameObject particulesAssociées;
    public bool particules;
    public GameObject camera;
    public bool activationFrappe;
    public bool activation;
    public int index;
    public GameObject spotPorteAssocierFermer;
    public GameObject spotPorteAssocierOuverte;
    
    private void Update()
    {
        if (boolStop == true)
        {
            FermeturePorte();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            FermeturePorte();
            activationFrappe = !activationFrappe;
            /*if (index == 0)
            {
                
                //transform.position += new Vector3(60,0,0);
                index++;
            }*/

            /*if (index == 2)
            {   
                Destroy(gameObject);
            }*/
           
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            activationFrappe = false;
            porteAssociée.transform.DOMove(spotPorteAssocierOuverte.transform.position, 1.5f).SetEase(Ease.Linear);
        }
    }
    
    private void FermeturePorte()
    {
        boolStop = true;
        timer += Time.deltaTime;
        if (timer <= DistancePorteMax)
        {
            porteAssociée.transform.DOMove(spotPorteAssocierFermer.transform.position, 1.5f).SetEase(Ease.Linear);
            /*porteAssociée.transform.position = Vector3.MoveTowards(porteAssociée.transform.position, porteAssociée.transform.position + Vector3.down,
                speedPorte * Time.deltaTime);*/
            
            if (particules)
            {
                particulesAssociées.SetActive(true);
            }
            
            if (plusieursPortes)
            {
                porteAssociée2.transform.position = Vector3.MoveTowards(porteAssociée2.transform.position, porteAssociée2.transform.position + Vector3.down,
                    speedPorte * Time.deltaTime);
                
                porteAssociée3.transform.position = Vector3.MoveTowards(porteAssociée3.transform.position, porteAssociée3.transform.position + Vector3.down,
                    speedPorte * Time.deltaTime);
            }
        }
        else if (timer >= DistancePorteMax)
        {
            timer = 0;
            boolStop = false;
        }
    }
}
