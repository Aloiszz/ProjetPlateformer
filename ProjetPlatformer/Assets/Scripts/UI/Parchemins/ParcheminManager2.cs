using System;
using System.Collections;
using System.Collections.Generic;
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

    
    public GameObject morceauParchemin1;
    public GameObject morceauParchemin2;
    public GameObject morceauParchemin3;
    
    public Image ImageParchemin1;
   // public GameObject ImageParchemin2;
   // public GameObject ImageParchemin3;
    private void Start()
    {
        RefreshText();
    }


    private void Update()
    {
        if (parcheminsObtenus == 1 || mm.MenuParcheminOuvert)
        {
            morceauParchemin1.transform.DOMoveX(50,2);
            morceauParchemin2.GetComponent<SpriteRenderer>().DOFade(50,2);
            ImageParchemin1.GetComponent<Image>();
        }
        
    }


    public void AddParchemin()
    {
        parcheminsObtenus += 1;
        StartCoroutine(apparitionUIParchemin());
    }


    IEnumerator apparitionUIParchemin()
    {
        indicationParchemin.transform.DOMoveY(290, 1);
        yield return new WaitForSeconds(1.2f);
        RefreshText();
        yield return new WaitForSeconds(1.5f);
        indicationParchemin.transform.DOMoveY(500, 1);
    }
        
        
    public void RefreshText()
    {
        textParchemins.text = "" + parcheminsObtenus;
    }
}
