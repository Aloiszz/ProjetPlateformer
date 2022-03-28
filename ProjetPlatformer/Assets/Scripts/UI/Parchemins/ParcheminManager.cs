using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ParcheminManager : MonoBehaviour
{

    public static bool parcheminActif;
    public bool parcheminActif2;
    public bool parcheminActif3;
    public bool parcheminActif4;
    public bool parcheminActif5;
    public bool parcheminActif6;
    public bool getParchemin1;
    public bool getParchemin2;
    public bool getParchemin3;
    public bool getParchemin4;
    public bool getParchemin5;
    public bool getParchemin6;
    public GameObject parcheminMenu1;
    public GameObject parcheminMenu2;
    public GameObject parcheminMenu3;
    public GameObject parcheminMenu4;
    public GameObject parcheminMenu5;
    public GameObject parcheminMenu6;
    public Sprite img1;
    public Image oldImg1;
    public Sprite img2;
    public Image oldImg2;
    public Sprite img3;
    public Image oldImg3;
    public Sprite img4;
    public Image oldImg4;
    public Sprite img5;
    public Image oldImg5;
    public Sprite img6;
    public Image oldImg6;
 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (getParchemin1)
        {
            oldImg1.sprite = img1;
        }
        
        if (getParchemin2)
        {
            oldImg2.sprite = img2;
        }
        
        if (getParchemin3)
        {
            oldImg3.sprite = img3;
        }
        
        if (getParchemin4)
        {
            oldImg4.sprite = img4;
        }
        
        if (getParchemin5)
        {
            oldImg5.sprite = img5;
        }
        
        if (getParchemin6)
        {
            oldImg6.sprite = img6;
        }
    }
    
    
    public void Agrandissement()
    {
        if(parcheminActif == false)
        {
            transform.DOScale(1.3f,0.5f); 
        }
    }
  
    public void Rappetissement()
    {
        if(parcheminActif == false)
        {
            transform.DOScale(1,0.5f); 
        }
    }
    
    
    public void GetBig1()
    {
        if (parcheminActif == false)
        {
            transform.DOScale(2,1);
            transform.DOMove(new Vector3(650,300,0),1.5f);
            parcheminActif = !parcheminActif;
            parcheminMenu2.SetActive(false);
            parcheminMenu3.SetActive(false);
            parcheminMenu4.SetActive(false);
            parcheminMenu5.SetActive(false);
            parcheminMenu6.SetActive(false);
        }
        else
        {
            transform.DOScale(1,1);
            transform.DOMove(new Vector3(385,395,0),1f);
            parcheminActif = !parcheminActif;
            parcheminMenu2.SetActive(true);
            parcheminMenu3.SetActive(true);
            parcheminMenu4.SetActive(true);
            parcheminMenu5.SetActive(true);
            parcheminMenu6.SetActive(true);
        }
    }
    
    public void GetBig2()
    {
        if (parcheminActif == false)
        {
            transform.DOScale(2,1);
            transform.DOMove(new Vector3(650,300,0),1.5f);
            parcheminActif = !parcheminActif;
            parcheminMenu1.SetActive(false);
            parcheminMenu3.SetActive(false);
            parcheminMenu4.SetActive(false);
            parcheminMenu5.SetActive(false);
            parcheminMenu6.SetActive(false);
        }
        else
        {
            transform.DOScale(1,1);
            transform.DOMove(new Vector3(385,395,0),1f);
            parcheminActif = !parcheminActif;
            parcheminMenu1.SetActive(true);
            parcheminMenu3.SetActive(true);
            parcheminMenu4.SetActive(true);
            parcheminMenu5.SetActive(true);
            parcheminMenu6.SetActive(true);
        }
    }
    
    public void GetBig3()
    {
        if (parcheminActif == false)
        {
            transform.DOScale(2,1);
            transform.DOMove(new Vector3(650,300,0),1.5f);
            parcheminActif = !parcheminActif;
            parcheminMenu2.SetActive(false);
            parcheminMenu1.SetActive(false);
            parcheminMenu4.SetActive(false);
            parcheminMenu5.SetActive(false);
            parcheminMenu6.SetActive(false);
        }
        else
        {
            transform.DOScale(1,1);
            transform.DOMove(new Vector3(385,395,0),1f);
            parcheminActif = !parcheminActif;
            parcheminMenu2.SetActive(true);
            parcheminMenu1.SetActive(true);
            parcheminMenu4.SetActive(true);
            parcheminMenu5.SetActive(true);
            parcheminMenu6.SetActive(true);
        }
    }
    
    public void GetBig4()
    {
        if (parcheminActif == false)
        {
            transform.DOScale(2,1);
            transform.DOMove(new Vector3(650,300,0),1.5f);
            parcheminActif = !parcheminActif;
            parcheminMenu2.SetActive(false);
            parcheminMenu3.SetActive(false);
            parcheminMenu1.SetActive(false);
            parcheminMenu5.SetActive(false);
            parcheminMenu6.SetActive(false);
        }
        else
        {
            transform.DOScale(1,1);
            transform.DOMove(new Vector3(385,395,0),1f);
            parcheminActif = !parcheminActif;
            parcheminMenu2.SetActive(true);
            parcheminMenu3.SetActive(true);
            parcheminMenu1.SetActive(true);
            parcheminMenu5.SetActive(true);
            parcheminMenu6.SetActive(true);
        }
    }
    
    public void GetBig5()
    {
        if (parcheminActif == false)
        {
            transform.DOScale(2,1);
            transform.DOMove(new Vector3(650,300,0),1.5f);
            parcheminActif = !parcheminActif;
            parcheminMenu2.SetActive(false);
            parcheminMenu3.SetActive(false);
            parcheminMenu4.SetActive(false);
            parcheminMenu1.SetActive(false);
            parcheminMenu6.SetActive(false);
        }
        else
        {
            transform.DOScale(1,1);
            transform.DOMove(new Vector3(385,395,0),1f);
            parcheminActif = !parcheminActif;
            parcheminMenu2.SetActive(true);
            parcheminMenu3.SetActive(true);
            parcheminMenu4.SetActive(true);
            parcheminMenu1.SetActive(true);
            parcheminMenu6.SetActive(true);
        }
    }
    
    public void GetBig6()
    {
        if (parcheminActif == false)
        {
            transform.DOScale(2,1);
            transform.DOMove(new Vector3(650,300,0),1.5f);
            parcheminActif = !parcheminActif;
            parcheminMenu2.SetActive(false);
            parcheminMenu3.SetActive(false);
            parcheminMenu4.SetActive(false);
            parcheminMenu5.SetActive(false);
            parcheminMenu1.SetActive(false);
        }
        else
        {
            transform.DOScale(1,1);
            transform.DOMove(new Vector3(385,395,0),1f);
            parcheminActif = !parcheminActif;
            parcheminMenu2.SetActive(true);
            parcheminMenu3.SetActive(true);
            parcheminMenu4.SetActive(true);
            parcheminMenu5.SetActive(true);
            parcheminMenu1.SetActive(true);
        }
    }
}
