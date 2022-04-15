using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using XInputDotNetPure;

public class MenuManager : MonoBehaviour/*, IPointerClickHandler*/
{
    
    public bool MenuParcheminOuvert;
    public bool MenuPrincipalOuvert;

    
    public FeuxDeCamp Fdc;
    [SerializeField] private CanvasGroup cv;
    private Tween fadeTween;
    public Animator parchAnim;

    
    public GameObject firstSelctedOption;
    public GameObject firstSelctedMain;
    public GameObject firstSelectedPause;
    public GameObject firstSelectedParchemmin;
    
    public GameObject parcheminManager;
    public GameObject mainMenu;
    public GameObject menuPrincipal;
    public GameObject menuOption;
    public GameObject menuPause;
    public GameObject menuParchemin;
    
    
    public static MenuManager instance;
    
    private void Awake()
    {
        if (instance == null) instance = this;
    }
    
    void Start()
    {
        mainMenu.SetActive(true);
        MenuPrincipalOuvert = true;
        menuParchemin.SetActive(false);
        parcheminManager.SetActive(false);
        MenuParcheminOuvert = false;
        FadeIn(2f);
    }

  
    void Update()
    {
        if (MenuPrincipalOuvert == false)
        {
            if (Input.GetKeyUp(KeyCode.JoystickButton7))
            {
                Time.timeScale = 0;
                menuPause.SetActive(true);
                EventSystem.current.SetSelectedGameObject(null);
                EventSystem.current.SetSelectedGameObject(firstSelectedPause);
                CharacterMovement.instance.canMove = false;
                CharacterMovement.instance.canJump = false;
                CharacterMovement.instance.speed = 0;
            }
            else if (Input.GetKeyUp(KeyCode.JoystickButton7))
            {
                Unpause();
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
            if (MenuParcheminOuvert)
            {
                CharacterMovement.instance.canMove = false;
                CharacterMovement.instance.canJump = false;
                CharacterMovement.instance.speed = 0;
            }
            else
            {
              /*  CharacterMovement.instance.canMove = true;
                CharacterMovement.instance.canJump = true;
                CharacterMovement.instance.speed = 11; */
            }
        }

        //if (Fdc.onoff)
        //{
            if (Input.GetAxis("BouttonMenuParchemin") > 0.1f)
            {
                
                OpenMenuParchemin();
            }
        //}

        if (MenuParcheminOuvert)
        {
            if (Input.GetKeyDown(KeyCode.JoystickButton1))
            {
                CloseMenuParchemin();
            }
        }
        
    }

    public void OpenMenuParchemin()
    {
        parchAnim.SetBool("FadeInParch",false);
        parchAnim.SetBool("FadeOutParch",true);
        
        
        MenuParcheminOuvert = true;
        menuParchemin.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(firstSelectedParchemmin);
                
        CharacterMovement.instance.canMove = false;
        CharacterMovement.instance.canJump = false;
        CharacterMovement.instance.speed = 0;
    }


    public void CloseMenuParchemin()
    {
        parchAnim.SetBool("FadeInParch",true);
        parchAnim.SetBool("FadeOutParch",false);
        
        MenuParcheminOuvert = false;
        menuParchemin.SetActive(false);
        
        CharacterMovement.instance.canMove = true;
        CharacterMovement.instance.canJump = true;
        CharacterMovement.instance.speed = 11;
    }
    
    
    
    public void Unpause()
    {
        menuPause.SetActive(false);
        Time.timeScale = 1;
        if (!Fdc.onoff)
        {
            StartCoroutine(WaitMove());
        }
    }
    public void Play()
    {
        EventSystem.current.SetSelectedGameObject(null);
        StartCoroutine(WaitMove());
        mainMenu.GetComponent<CanvasGroup>().interactable = false;
        FadeOut(2f);
        MenuPrincipalOuvert = false;
    }

    IEnumerator WaitMove()
    {
        yield return new WaitForSeconds(0.1f);
        CharacterMovement.instance.canMove = true;
        CharacterMovement.instance.canJump = true;
        CharacterMovement.instance.speed = 11;
    }


    public void OpenOption()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(firstSelctedOption);
    }

    public void OpenMainMenu()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(firstSelctedMain);
        menuOption.SetActive(false);
        menuPrincipal.SetActive(true);
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
