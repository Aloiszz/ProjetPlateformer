using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class FermetureSalle3 : MonoBehaviour
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
    public bool activationFrappe2;
    public bool activation;
    
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
           
            activationFrappe2 = !activationFrappe2;
            transform.position += new Vector3(60,0,0);
        }
    }
    
    private void FermeturePorte()
    {
        boolStop = true;
        timer += Time.deltaTime;
        if (timer <= DistancePorteMax)
        {
            porteAssociée.transform.position = Vector3.MoveTowards(porteAssociée.transform.position, porteAssociée.transform.position + Vector3.down,
                speedPorte * Time.deltaTime);
            
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
    }
}
