using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ParcheminManager2 : MonoBehaviour
{
    
    
    public int parcheminsObtenus;

    public TextMeshProUGUI textParchemins;
    public GameObject indicationParchemin;
    public MenuManager mm;
    public float déplacementCompteurIn;
    public float déplacementCompteurOut;

    [Header("Morceau Parchemin")]
    public GameObject morceauParchemin1;
    public GameObject morceauParchemin2;
    public GameObject morceauParchemin3;
    public GameObject morceauParchemin4;
    public GameObject morceauParchemin5;
    public GameObject morceauParchemin6;
    public GameObject morceauParchemin7;
    public GameObject morceauParchemin8;
    public GameObject morceauParchemin9;
    
    [Header("GameObject et image")]
    public GameObject Parchemin1;
    public Sprite Image1;
    public Sprite Image2;
    public Sprite Image3;
    public Sprite Image4;
    public GameObject Parchemin2;
    public Sprite Image5;
    public Sprite Image6;
    public Sprite Image7;
    public Sprite Image8;
    public GameObject Parchemin3;
    public Sprite Image9;
    public Sprite Image10;
    public Sprite Image11;
    public Sprite Image12;
    public Image indicationParch;
    
    
    
    
    
    private void Start()
    {
        //DontDestroyOnLoad(gameObject);
        
        
        
        RefreshText();
        Parchemin1.GetComponent<Image>().sprite = Image1;
        Parchemin2.GetComponent<Image>().sprite = Image5;
        Parchemin3.GetComponent<Image>().sprite = Image9;
    }

    public void AddParchemin()
    {
        parcheminsObtenus += 1;
        StartCoroutine(apparitionUIParchemin());
        //StartCoroutine(DoScaleScrolls());
    }

    IEnumerator DoScaleScrolls()
    {
        /*while (FeuxDeCamp.instanceFeuxdeCamp.isInRange && Input.GetButtonDown("BouttonMenuParchemin"))
        {
            indicationParch.rectTransform.DOScale(new Vector2(1.5f, 1.5f), 1f);
            yield return new WaitForSeconds(1);
            indicationParch.rectTransform.DOScale(new Vector2(1f, 1f), 1f);
            yield return new WaitForSeconds(1);
        }*/
        return null;
    }
    
    IEnumerator apparitionUIParchemin()
    {
        indicationParchemin.transform.DOMoveY(déplacementCompteurIn, 1);
        yield return new WaitForSeconds(1.2f);
        RefreshText();
        yield return new WaitForSeconds(1.5f);
        indicationParchemin.transform.DOMoveY(déplacementCompteurOut, 1);
    }
        
        
    public void RefreshText()
    {
        textParchemins.text = "" + parcheminsObtenus;
    }
    
    
    private void Update()
    {
        mm = GameObject.FindWithTag("MENU").GetComponent<MenuManager>();
        Parchemin1 = GameObject.Find("Parchemin1");
        Parchemin2 = GameObject.Find("Parchemin 2");
        Parchemin3 = GameObject.Find("Parchemin3");
        morceauParchemin1 = GameObject.Find("1Emplacement Morceau Parchemin");
        morceauParchemin2 = GameObject.Find("2Emplacement Morceau Parchemin ");
        morceauParchemin3 = GameObject.Find("3Emplacement Morceau Parchemin ");
        morceauParchemin4 = GameObject.Find("4Emplacement Morceau Parchemin ");
        morceauParchemin5 = GameObject.Find("5Emplacement Morceau Parchemin ");
        morceauParchemin6 = GameObject.Find("6Emplacement Morceau Parchemin ");
        morceauParchemin7 = GameObject.Find("7Emplacement Morceau Parchemin ");
        morceauParchemin8 = GameObject.Find("8Emplacement Morceau Parchemin ");
        morceauParchemin9 = GameObject.Find("9Emplacement Morceau Parchemin ");

        

        if (parcheminsObtenus == 0 && mm.MenuParcheminOuvert)
        {
            morceauParchemin1.GetComponent<Image>().enabled = false;
                 morceauParchemin2.GetComponent<Image>().enabled = false;
                 morceauParchemin3.GetComponent<Image>().enabled = false;
                 morceauParchemin4.GetComponent<Image>().enabled = false;
                 morceauParchemin5.GetComponent<Image>().enabled = false;
                 morceauParchemin6.GetComponent<Image>().enabled = false;
                 morceauParchemin7.GetComponent<Image>().enabled = false;
                 morceauParchemin8.GetComponent<Image>().enabled = false;
                 morceauParchemin9.GetComponent<Image>().enabled = false;
        }
             
        if (parcheminsObtenus == 1 && mm.MenuParcheminOuvert)
          {
             Parchemin1.GetComponent<Image>().sprite = Image2;
             Parchemin1.GetComponent<RectTransform>().localPosition = new Vector3(180, 119.75f, 0);
             Parchemin1.GetComponent<RectTransform>().sizeDelta = new Vector2(963.9696f, 576.35f);
                
             morceauParchemin1.GetComponent<Image>().enabled = true;
             morceauParchemin2.GetComponent<Image>().enabled = false;
             morceauParchemin3.GetComponent<Image>().enabled = false;   
             morceauParchemin4.GetComponent<Image>().enabled = false;
             morceauParchemin5.GetComponent<Image>().enabled = false;
             morceauParchemin6.GetComponent<Image>().enabled = false;
             morceauParchemin7.GetComponent<Image>().enabled = false;
             morceauParchemin8.GetComponent<Image>().enabled = false;
             morceauParchemin9.GetComponent<Image>().enabled = false;

             if (mm.pageOuverte == 1)
             {
                 //morceauParchemin1.transform.localScale = new Vector3(0,0,0);
                 morceauParchemin1.transform.DOScale(new Vector3(2, 2, 2),2).OnComplete((() =>
                 {
                     morceauParchemin1.transform.DOScale(new Vector3(1, 1, 1), 1.5f).Kill();
                 } ));  
             }
          }
             
             if (parcheminsObtenus == 2 && mm.MenuParcheminOuvert)
             {
                 Parchemin1.GetComponent<Image>().sprite = Image3;
                 Parchemin1.GetComponent<RectTransform>().localPosition = new Vector3(176f, 70f, 0);
                 Parchemin1.GetComponent<RectTransform>().sizeDelta = new Vector2(929.246f, 807.3909f);
                 
                 morceauParchemin1.GetComponent<Image>().enabled = true;
                 morceauParchemin2.GetComponent<Image>().enabled = true;
                 morceauParchemin3.GetComponent<Image>().enabled = false;
                 morceauParchemin4.GetComponent<Image>().enabled = false;
                 morceauParchemin5.GetComponent<Image>().enabled = false;
                 morceauParchemin6.GetComponent<Image>().enabled = false;
                 morceauParchemin7.GetComponent<Image>().enabled = false;
                 morceauParchemin8.GetComponent<Image>().enabled = false;
                 morceauParchemin9.GetComponent<Image>().enabled = false;

                 if (mm.pageOuverte == 1)
                 {
                     //morceauParchemin1.transform.localScale = new Vector3(0,0,0);
                                                      morceauParchemin1.transform.DOScale(new Vector3(2, 2, 2),2).OnComplete((() =>
                                                      {
                                                          morceauParchemin1.transform.DOScale(new Vector3(1, 1, 1), 1.5f).Kill();
                                                      } ));
                                                      
                                    // morceauParchemin2.transform.localScale = new Vector3(0,0,0);
                                     morceauParchemin2.transform.DOScale(new Vector3(2, 2, 2),1).OnComplete((() =>
                                     {
                                         morceauParchemin2.transform.DOScale(new Vector3(1, 1, 1), 1).Kill();
                                     } )); 
                 }
             }
             
             if (parcheminsObtenus == 3 && mm.MenuParcheminOuvert)
             {
                 Parchemin1.GetComponent<Image>().sprite = Image4;
                 Parchemin1.GetComponent<RectTransform>().localPosition = new Vector3(170f, -54, 0);
                 Parchemin1.GetComponent<RectTransform>().sizeDelta = new Vector2(634.9857f, 873.6876f);

                 morceauParchemin1.GetComponent<Image>().enabled = true;
                 morceauParchemin2.GetComponent<Image>().enabled = true;
                 morceauParchemin3.GetComponent<Image>().enabled = true;
                 morceauParchemin4.GetComponent<Image>().enabled = false;
                 morceauParchemin5.GetComponent<Image>().enabled = false;
                 morceauParchemin6.GetComponent<Image>().enabled = false;
                 morceauParchemin7.GetComponent<Image>().enabled = false;
                 morceauParchemin8.GetComponent<Image>().enabled = false;
                 morceauParchemin9.GetComponent<Image>().enabled = false;

                 if (mm.pageOuverte == 1)
                 {
                    // morceauParchemin1.transform.localScale = new Vector3(0,0,0);
                     morceauParchemin1.transform.DOScale(new Vector3(2, 2, 2),2).OnComplete((() =>
                     {
                         morceauParchemin1.transform.DOScale(new Vector3(1, 1, 1), 1.5f).Kill();
                     } ));
                                  
                    // morceauParchemin2.transform.localScale = new Vector3(0,0,0);
                     morceauParchemin2.transform.DOScale(new Vector3(2, 2, 2),1).OnComplete((() =>
                     {
                         morceauParchemin2.transform.DOScale(new Vector3(1, 1, 1), 1).Kill();
                     } ));
                    // morceauParchemin3.transform.localScale = new Vector3(0,0,0);
                     morceauParchemin3.transform.DOScale(new Vector3(2, 2, 2),1).OnComplete((() =>
                     {
                         morceauParchemin3.transform.DOScale(new Vector3(1, 1, 1), 1).Kill();
                     } )); 
                 }
             }

             if (parcheminsObtenus == 4 && mm.MenuParcheminOuvert)
             {
                 Parchemin2.GetComponent<Image>().sprite = Image6;
                 Parchemin2.GetComponent<RectTransform>().localPosition = new Vector3(184, 70, 0);
                 Parchemin2.GetComponent<RectTransform>().sizeDelta = new Vector2(963.9696f, 576.35f);
                 
                 morceauParchemin1.GetComponent<Image>().enabled = true;
                 morceauParchemin2.GetComponent<Image>().enabled = true;
                 morceauParchemin3.GetComponent<Image>().enabled = true;
                 morceauParchemin4.GetComponent<Image>().enabled = true;
                 morceauParchemin5.GetComponent<Image>().enabled = false;
                 morceauParchemin6.GetComponent<Image>().enabled = false;
                 morceauParchemin7.GetComponent<Image>().enabled = false;
                 morceauParchemin8.GetComponent<Image>().enabled = false;
                 morceauParchemin9.GetComponent<Image>().enabled = false;

                 if (mm.pageOuverte == 2)
                 {
                     //morceauParchemin4.transform.localScale = new Vector3(0,0,0);
                     morceauParchemin4.transform.DOScale(new Vector3(2, 2, 2),1).OnComplete((() =>
                     {
                         morceauParchemin4.transform.DOScale(new Vector3(1, 1, 1), 1).Kill();
                     } ));
                 }
                 
             }
             
             if (parcheminsObtenus == 5 && mm.MenuParcheminOuvert)
             {
                 Parchemin2.GetComponent<Image>().sprite = Image7;
                 Parchemin2.GetComponent<RectTransform>().localPosition = new Vector3(184, 69, 0);
                 Parchemin2.GetComponent<RectTransform>().sizeDelta = new Vector2(929.246f, 807.3909f);
                 
                 morceauParchemin1.GetComponent<Image>().enabled = true;
                 morceauParchemin2.GetComponent<Image>().enabled = true;
                 morceauParchemin3.GetComponent<Image>().enabled = true;
                 morceauParchemin4.GetComponent<Image>().enabled = true;
                 morceauParchemin5.GetComponent<Image>().enabled = true;
                 morceauParchemin6.GetComponent<Image>().enabled = false;
                 morceauParchemin7.GetComponent<Image>().enabled = false;
                 morceauParchemin8.GetComponent<Image>().enabled = false;
                 morceauParchemin9.GetComponent<Image>().enabled = false;

                 if (mm.pageOuverte == 2)
                 {
                     //morceauParchemin5.transform.localScale = new Vector3(0,0,0);
                     morceauParchemin5.transform.DOScale(new Vector3(2, 2, 2),1).OnComplete((() =>
                     {
                         morceauParchemin5.transform.DOScale(new Vector3(1, 1, 1), 1).Kill();
                     } )); 
                     
                     //morceauParchemin4.transform.localScale = new Vector3(0,0,0);
                     morceauParchemin4.transform.DOScale(new Vector3(2, 2, 2),1).OnComplete((() =>
                     {
                         morceauParchemin4.transform.DOScale(new Vector3(1, 1, 1), 1).Kill();
                     } ));
                 }
                 
             }
             
             if (parcheminsObtenus == 6 && mm.MenuParcheminOuvert)
             {
                 Parchemin2.GetComponent<Image>().sprite = Image8;
                 Parchemin2.GetComponent<RectTransform>().localPosition = new Vector3(184, -45.2f, 0);
                 Parchemin2.GetComponent<RectTransform>().sizeDelta = new Vector2(634.9857f, 873.6876f);
                 
                 
                 morceauParchemin1.GetComponent<Image>().enabled = true;
                 morceauParchemin2.GetComponent<Image>().enabled = true;
                 morceauParchemin3.GetComponent<Image>().enabled = true;
                 morceauParchemin4.GetComponent<Image>().enabled = true;
                 morceauParchemin5.GetComponent<Image>().enabled = true;
                 morceauParchemin6.GetComponent<Image>().enabled = true;
                 morceauParchemin7.GetComponent<Image>().enabled = false;
                 morceauParchemin8.GetComponent<Image>().enabled = false;
                 morceauParchemin9.GetComponent<Image>().enabled = false;

                 if (mm.pageOuverte == 2)
                 {
                     //morceauParchemin6.transform.localScale = new Vector3(0,0,0);
                     morceauParchemin6.transform.DOScale(new Vector3(2, 2, 2),1).OnComplete((() =>
                     {
                         morceauParchemin6.transform.DOScale(new Vector3(1, 1, 1), 1).Kill();
                     } )); 
                     
                     //morceauParchemin5.transform.localScale = new Vector3(0,0,0);
                     morceauParchemin5.transform.DOScale(new Vector3(2, 2, 2),1).OnComplete((() =>
                     {
                         morceauParchemin5.transform.DOScale(new Vector3(1, 1, 1), 1).Kill();
                     } )); 
                     
                     //morceauParchemin4.transform.localScale = new Vector3(0,0,0);
                     morceauParchemin4.transform.DOScale(new Vector3(2, 2, 2),1).OnComplete((() =>
                     {
                         morceauParchemin4.transform.DOScale(new Vector3(1, 1, 1), 1).Kill();
                     } ));
                 }
                 
             }
             
             if (parcheminsObtenus == 7 && mm.MenuParcheminOuvert)
             {
                 Parchemin3.GetComponent<Image>().sprite = Image10;
                 Parchemin3.GetComponent<RectTransform>().localPosition = new Vector3(293, 123.52f, 0);
                 Parchemin3.GetComponent<RectTransform>().sizeDelta = new Vector2(1129.236f, 531.26f);
                 
                 morceauParchemin1.GetComponent<Image>().enabled = true;
                 morceauParchemin2.GetComponent<Image>().enabled = true;
                 morceauParchemin3.GetComponent<Image>().enabled = true;
                 morceauParchemin4.GetComponent<Image>().enabled = true;
                 morceauParchemin5.GetComponent<Image>().enabled = true;
                 morceauParchemin6.GetComponent<Image>().enabled = true;
                 morceauParchemin7.GetComponent<Image>().enabled = true;
                 morceauParchemin8.GetComponent<Image>().enabled = false;
                 morceauParchemin9.GetComponent<Image>().enabled = false;

                 if (mm.pageOuverte == 3)
                 {
                     //morceauParchemin7.transform.localScale = new Vector3(0,0,0);
                     morceauParchemin7.transform.DOScale(new Vector3(2, 2, 2),1).OnComplete((() =>
                     {
                         morceauParchemin7.transform.DOScale(new Vector3(1, 1, 1), 1).Kill();
                     } ));
                 }
                 
             }
             
             if (parcheminsObtenus == 8 && mm.MenuParcheminOuvert)
             {
                 Parchemin3.GetComponent<Image>().sprite = Image11;
                 Parchemin3.GetComponent<RectTransform>().localPosition = new Vector3(293, 22, 0);
                 Parchemin3.GetComponent<RectTransform>().sizeDelta = new Vector2(1055.913f, 807.6f);
                 
                 morceauParchemin1.GetComponent<Image>().enabled = true;
                 morceauParchemin2.GetComponent<Image>().enabled = true;
                 morceauParchemin3.GetComponent<Image>().enabled = true;
                 morceauParchemin4.GetComponent<Image>().enabled = true;
                 morceauParchemin5.GetComponent<Image>().enabled = true;
                 morceauParchemin6.GetComponent<Image>().enabled = true;
                 morceauParchemin7.GetComponent<Image>().enabled = true;
                 morceauParchemin8.GetComponent<Image>().enabled = true;
                 morceauParchemin9.GetComponent<Image>().enabled = false;

                 if (mm.pageOuverte == 3)
                 {
                    // morceauParchemin8.transform.localScale = new Vector3(0,0,0);
                     morceauParchemin8.transform.DOScale(new Vector3(2, 2, 2),1).OnComplete((() =>
                     {
                         morceauParchemin8.transform.DOScale(new Vector3(1, 1, 1), 1).Kill();
                     } ));
                     
                     //morceauParchemin7.transform.localScale = new Vector3(0,0,0);
                     morceauParchemin7.transform.DOScale(new Vector3(2, 2, 2),1).OnComplete((() =>
                     {
                         morceauParchemin7.transform.DOScale(new Vector3(1, 1, 1), 1).Kill();
                     } ));
                 }
                 
             }
             
             if (parcheminsObtenus == 9 && mm.MenuParcheminOuvert)
             {
                 Parchemin3.GetComponent<Image>().sprite = Image12;
                 Parchemin3.GetComponent<RectTransform>().localPosition = new Vector3(237, -45.204f, 0);
                 Parchemin3.GetComponent<RectTransform>().sizeDelta = new Vector2(656.5009f, 873.6f);
                 
                 morceauParchemin1.GetComponent<Image>().enabled = true;
                 morceauParchemin2.GetComponent<Image>().enabled = true;
                 morceauParchemin3.GetComponent<Image>().enabled = true;
                 morceauParchemin4.GetComponent<Image>().enabled = true;
                 morceauParchemin5.GetComponent<Image>().enabled = true;
                 morceauParchemin6.GetComponent<Image>().enabled = true;
                 morceauParchemin7.GetComponent<Image>().enabled = true;
                 morceauParchemin8.GetComponent<Image>().enabled = true;
                 morceauParchemin9.GetComponent<Image>().enabled = true;

                 if (mm.pageOuverte == 3)
                 {
                     //morceauParchemin9.transform.localScale = new Vector3(0,0,0);
                     morceauParchemin9.transform.DOScale(new Vector3(2, 2, 2),1).OnComplete((() =>
                     {
                         morceauParchemin9.transform.DOScale(new Vector3(1, 1, 1), 1).Kill();
                     } ));
                     
                     //morceauParchemin8.transform.localScale = new Vector3(0,0,0);
                     morceauParchemin8.transform.DOScale(new Vector3(2, 2, 2),1).OnComplete((() =>
                     {
                         morceauParchemin8.transform.DOScale(new Vector3(1, 1, 1), 1).Kill();
                     } ));
                     
                     //morceauParchemin7.transform.localScale = new Vector3(0,0,0);
                     morceauParchemin7.transform.DOScale(new Vector3(2, 2, 2),1).OnComplete((() =>
                     {
                         morceauParchemin7.transform.DOScale(new Vector3(1, 1, 1), 1).Kill();
                     } ));
                 }
                 
             }
         }
}
