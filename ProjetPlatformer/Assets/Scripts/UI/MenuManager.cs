using System.Collections;
using System.Collections.Generic;
using System.Timers;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuManager : MonoBehaviour/*, IPointerClickHandler*/
{
    public GameObject parcheminManager;
    public bool MenuOuvert;
    public ParcheminManager pm;

    
    void Start()
    {
        parcheminManager.SetActive(false);
        MenuOuvert = false;
    }

  
    void Update()
    {
        if (MenuOuvert == false)
        {
            if (Input.GetKeyUp(KeyCode.A))
            {
                parcheminManager.SetActive(true);
                MenuOuvert = true;
            //    Time.timeScale = 0;
            }
        }

          if (MenuOuvert == true)
          {
              if (Input.GetKeyUp(KeyCode.E))
              {
                  parcheminManager.SetActive(false);
                  MenuOuvert = false;
              //    Time.timeScale = 1;
              }
          }
        
    }

    public void Quit()
    {
        Application.Quit();
    }
}
