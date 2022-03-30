using System.Collections;
using System.Collections.Generic;
using System.Timers;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuManager : MonoBehaviour/*, IPointerClickHandler*/
{
    public GameObject parcheminManager;
    public GameObject mainMenu;
    public bool MenuParcheminOuvert;
    public bool MenuPrincipalOuvert;
    [SerializeField] private CanvasGroup cv;
    private Tween fadeTween;

    
    void Start()
    {
        mainMenu.SetActive(true);
        MenuPrincipalOuvert = true;
        parcheminManager.SetActive(false);
        MenuParcheminOuvert = false;
        FadeIn(2f);
    }

  
    void Update()
    {
        if (MenuPrincipalOuvert == false)
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                MenuParcheminOuvert = !MenuParcheminOuvert;
                parcheminManager.SetActive(MenuParcheminOuvert);
            }
            else if (Input.GetKeyUp(KeyCode.E))
            {
                MenuParcheminOuvert = !MenuParcheminOuvert;
                parcheminManager.SetActive(MenuParcheminOuvert);
            } 
        }
  
        if (MenuPrincipalOuvert)
        {
            CharacterMovement.instance.canMove = false;
            CharacterMovement.instance.canJump = false;
            CharacterMovement.instance.speed = 0;
        }
        else
        {
            CharacterMovement.instance.canMove = true;
            CharacterMovement.instance.canJump = true;
            CharacterMovement.instance.speed = 11; 
        }
        
            if (MenuParcheminOuvert)
            {
                CharacterMovement.instance.canMove = false;
                CharacterMovement.instance.canJump = false;
                CharacterMovement.instance.speed = 0;
            }
            else
            {
                CharacterMovement.instance.canMove = true;
                CharacterMovement.instance.canJump = true;
                CharacterMovement.instance.speed = 11; 
            }
    }

    public void Play()
    {
        MenuPrincipalOuvert = false;
        FadeOut(2f);
    }

    public void Fade(float endValue, float duration, TweenCallback onEnd)
    {
        if (fadeTween != null)
        {
            fadeTween.Kill(false);
        }
        fadeTween = cv.DOFade(endValue,duration);
        fadeTween.onComplete += onEnd;
    }

    public void FadeIn(float duration)
    {
        Fade(1f, duration, (() =>
        {
            cv.interactable = true;
            cv.blocksRaycasts = true;
        }));
    }
    
    public void FadeOut(float duration)
    {
        Fade(0f, duration, (() =>
        {
            cv.interactable = false;
            cv.blocksRaycasts = false;
        }));
    }
    
    public void Quit()
    {
        Application.Quit();
    }
}
