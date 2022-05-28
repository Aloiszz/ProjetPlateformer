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

    
    public GameObject morceauParchemin1;
    public GameObject morceauParchemin2;
    public GameObject morceauParchemin3;
    public GameObject morceauParchemin4;
    public GameObject morceauParchemin5;
    public GameObject morceauParchemin6;
    public GameObject morceauParchemin7;
    public GameObject morceauParchemin8;
    public GameObject morceauParchemin9;
    
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
    
    
    
    
    
    
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        
        RefreshText();
        Parchemin1.GetComponent<Image>().sprite = Image1;
        Parchemin2.GetComponent<Image>().sprite = Image5;
        Parchemin3.GetComponent<Image>().sprite = Image9;
    }

    public void AddParchemin()
    {
        parcheminsObtenus += 1;
        StartCoroutine(apparitionUIParchemin());
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
             if (parcheminsObtenus == 0 && mm.MenuParcheminOuvert)
             {
                 morceauParchemin1.SetActive(false);
                 morceauParchemin2.SetActive(false);
                 morceauParchemin3.SetActive(false);
                 morceauParchemin4.SetActive(false);
                 morceauParchemin5.SetActive(false);
                 morceauParchemin6.SetActive(false);
                 morceauParchemin7.SetActive(false);
                 morceauParchemin8.SetActive(false);
                 morceauParchemin9.SetActive(false);
             }
             
             if (parcheminsObtenus == 1 && mm.MenuParcheminOuvert)
             {
                 Parchemin1.GetComponent<Image>().sprite = Image2;
                 Parchemin1.GetComponent<RectTransform>().localPosition = new Vector3(180, 119.75f, 0);
                 Parchemin1.GetComponent<RectTransform>().sizeDelta = new Vector2(963.9696f, 576.35f);
                 
                 morceauParchemin1.SetActive(true);
                 morceauParchemin2.SetActive(false);
                 morceauParchemin3.SetActive(false);
                 morceauParchemin4.SetActive(false);
                 morceauParchemin5.SetActive(false);
                 morceauParchemin6.SetActive(false);
                 morceauParchemin7.SetActive(false);
                 morceauParchemin8.SetActive(false);
                 morceauParchemin9.SetActive(false);

                 if (mm.pageOuverte == 1)
                 {
                     morceauParchemin1.transform.localScale = new Vector3(0,0,0);
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
                 
                 morceauParchemin1.SetActive(true);
                 morceauParchemin2.SetActive(true);
                 morceauParchemin3.SetActive(false);
                 morceauParchemin4.SetActive(false);
                 morceauParchemin5.SetActive(false);
                 morceauParchemin6.SetActive(false);
                 morceauParchemin7.SetActive(false);
                 morceauParchemin8.SetActive(false);
                 morceauParchemin9.SetActive(false);

                 if (mm.pageOuverte == 1)
                 {
                     morceauParchemin1.transform.localScale = new Vector3(0,0,0);
                                                      morceauParchemin1.transform.DOScale(new Vector3(2, 2, 2),2).OnComplete((() =>
                                                      {
                                                          morceauParchemin1.transform.DOScale(new Vector3(1, 1, 1), 1.5f).Kill();
                                                      } ));
                                                      
                                     morceauParchemin2.transform.localScale = new Vector3(0,0,0);
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

                 morceauParchemin1.SetActive(true);
                 morceauParchemin2.SetActive(true);
                 morceauParchemin3.SetActive(true);
                 morceauParchemin4.SetActive(false);
                 morceauParchemin5.SetActive(false);
                 morceauParchemin6.SetActive(false);
                 morceauParchemin7.SetActive(false);
                 morceauParchemin8.SetActive(false);
                 morceauParchemin9.SetActive(false);

                 if (mm.pageOuverte == 1)
                 {
                     morceauParchemin1.transform.localScale = new Vector3(0,0,0);
                     morceauParchemin1.transform.DOScale(new Vector3(2, 2, 2),2).OnComplete((() =>
                     {
                         morceauParchemin1.transform.DOScale(new Vector3(1, 1, 1), 1.5f).Kill();
                     } ));
                                  
                     morceauParchemin2.transform.localScale = new Vector3(0,0,0);
                     morceauParchemin2.transform.DOScale(new Vector3(2, 2, 2),1).OnComplete((() =>
                     {
                         morceauParchemin2.transform.DOScale(new Vector3(1, 1, 1), 1).Kill();
                     } ));
                     morceauParchemin3.transform.localScale = new Vector3(0,0,0);
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
                 
                 morceauParchemin1.SetActive(true);
                 morceauParchemin2.SetActive(true);
                 morceauParchemin3.SetActive(true);
                 morceauParchemin4.SetActive(true);
                 morceauParchemin5.SetActive(false);
                 morceauParchemin6.SetActive(false);
                 morceauParchemin7.SetActive(false);
                 morceauParchemin8.SetActive(false);
                 morceauParchemin9.SetActive(false);

                 if (mm.pageOuverte == 2)
                 {
                     morceauParchemin4.transform.localScale = new Vector3(0,0,0);
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
                 
                 morceauParchemin1.SetActive(true);
                 morceauParchemin2.SetActive(true);
                 morceauParchemin3.SetActive(true);
                 morceauParchemin4.SetActive(true);
                 morceauParchemin5.SetActive(true);
                 morceauParchemin6.SetActive(false);
                 morceauParchemin7.SetActive(false);
                 morceauParchemin8.SetActive(false);
                 morceauParchemin9.SetActive(false);

                 if (mm.pageOuverte == 2)
                 {
                     morceauParchemin5.transform.localScale = new Vector3(0,0,0);
                     morceauParchemin5.transform.DOScale(new Vector3(2, 2, 2),1).OnComplete((() =>
                     {
                         morceauParchemin5.transform.DOScale(new Vector3(1, 1, 1), 1).Kill();
                     } )); 
                     
                     morceauParchemin4.transform.localScale = new Vector3(0,0,0);
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
                 
                 
                 morceauParchemin1.SetActive(true);
                 morceauParchemin2.SetActive(true);
                 morceauParchemin3.SetActive(true);
                 morceauParchemin4.SetActive(true);
                 morceauParchemin5.SetActive(true);
                 morceauParchemin6.SetActive(true);
                 morceauParchemin7.SetActive(false);
                 morceauParchemin8.SetActive(false);
                 morceauParchemin9.SetActive(false);

                 if (mm.pageOuverte == 2)
                 {
                     morceauParchemin6.transform.localScale = new Vector3(0,0,0);
                     morceauParchemin6.transform.DOScale(new Vector3(2, 2, 2),1).OnComplete((() =>
                     {
                         morceauParchemin6.transform.DOScale(new Vector3(1, 1, 1), 1).Kill();
                     } )); 
                     
                     morceauParchemin5.transform.localScale = new Vector3(0,0,0);
                     morceauParchemin5.transform.DOScale(new Vector3(2, 2, 2),1).OnComplete((() =>
                     {
                         morceauParchemin5.transform.DOScale(new Vector3(1, 1, 1), 1).Kill();
                     } )); 
                     
                     morceauParchemin4.transform.localScale = new Vector3(0,0,0);
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
                 
                 morceauParchemin1.SetActive(true);
                 morceauParchemin2.SetActive(true);
                 morceauParchemin3.SetActive(true);
                 morceauParchemin4.SetActive(true);
                 morceauParchemin5.SetActive(true);
                 morceauParchemin6.SetActive(true);
                 morceauParchemin7.SetActive(true);
                 morceauParchemin8.SetActive(false);
                 morceauParchemin9.SetActive(false);

                 if (mm.pageOuverte == 3)
                 {
                     morceauParchemin7.transform.localScale = new Vector3(0,0,0);
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
                 
                 morceauParchemin1.SetActive(true);
                 morceauParchemin2.SetActive(true);
                 morceauParchemin3.SetActive(true);
                 morceauParchemin4.SetActive(true);
                 morceauParchemin5.SetActive(true);
                 morceauParchemin6.SetActive(true);
                 morceauParchemin7.SetActive(true);
                 morceauParchemin8.SetActive(true);
                 morceauParchemin9.SetActive(false);

                 if (mm.pageOuverte == 3)
                 {
                     morceauParchemin8.transform.localScale = new Vector3(0,0,0);
                     morceauParchemin8.transform.DOScale(new Vector3(2, 2, 2),1).OnComplete((() =>
                     {
                         morceauParchemin8.transform.DOScale(new Vector3(1, 1, 1), 1).Kill();
                     } ));
                     
                     morceauParchemin7.transform.localScale = new Vector3(0,0,0);
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
                 
                 morceauParchemin1.SetActive(true);
                 morceauParchemin2.SetActive(true);
                 morceauParchemin3.SetActive(true);
                 morceauParchemin4.SetActive(true);
                 morceauParchemin5.SetActive(true);
                 morceauParchemin6.SetActive(true);
                 morceauParchemin7.SetActive(true);
                 morceauParchemin8.SetActive(true);
                 morceauParchemin9.SetActive(true);

                 if (mm.pageOuverte == 3)
                 {
                     morceauParchemin9.transform.localScale = new Vector3(0,0,0);
                     morceauParchemin9.transform.DOScale(new Vector3(2, 2, 2),1).OnComplete((() =>
                     {
                         morceauParchemin9.transform.DOScale(new Vector3(1, 1, 1), 1).Kill();
                     } ));
                     
                     morceauParchemin8.transform.localScale = new Vector3(0,0,0);
                     morceauParchemin8.transform.DOScale(new Vector3(2, 2, 2),1).OnComplete((() =>
                     {
                         morceauParchemin8.transform.DOScale(new Vector3(1, 1, 1), 1).Kill();
                     } ));
                     
                     morceauParchemin7.transform.localScale = new Vector3(0,0,0);
                     morceauParchemin7.transform.DOScale(new Vector3(2, 2, 2),1).OnComplete((() =>
                     {
                         morceauParchemin7.transform.DOScale(new Vector3(1, 1, 1), 1).Kill();
                     } ));
                 }
                 
             }
         }
}
