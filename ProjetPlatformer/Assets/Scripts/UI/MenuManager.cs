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
            if (Input.GetKeyUp(KeyCode.R))
            {
                parcheminManager.SetActive(true);
                MenuOuvert = true;
                CharacterMovement.instance.canMove = false;
            CharacterMovement.instance.canJump = false;
            CharacterMovement.instance.speed = 0;
            }
        }

          if (MenuOuvert == true)
          {
              if (Input.GetKeyUp(KeyCode.E))
              {
                  parcheminManager.SetActive(false);
                  MenuOuvert = false;
                  CharacterMovement.instance.canMove = true;
              CharacterMovement.instance.canJump = true;
              CharacterMovement.instance.speed = 11;
              }
          }
        
    }

    public void Quit()
    {
        Application.Quit();
    }
}
