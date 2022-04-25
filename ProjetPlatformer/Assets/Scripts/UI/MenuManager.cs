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
    [Header("Bool Open/Close")]
    public bool MenuParcheminOuvert;
    public bool MenuPrincipalOuvert;
    public bool IsChanging;
    public int pageOuverte = 1;

    [Header("Divers")]
    public FeuxDeCamp Fdc;
    [SerializeField] private CanvasGroup cv;
    private Tween fadeTween;
    public Animator parchAnim;
    public float distanceChangementPage;
    public CameraZoom cm;

    [Header("First Selected")]
    public GameObject firstSelctedOption;
    public GameObject firstSelctedMain;
    public GameObject firstSelectedPause;
    public GameObject fleche1;
    public GameObject fleche2;
    public GameObject fleche3;
    public GameObject fleche4;
    
    [Header("Éléments du Menu")]
    public GameObject parcheminManager;
    public GameObject mainMenu;
    public GameObject menuPrincipal;
    public GameObject menuOption;
    public GameObject menuPause;
    public GameObject menuParchemin;
    public GameObject Page1;
    public GameObject Page2;
    public GameObject Page3;
    
    public bool isPlaying;
    
    
    public static MenuManager instance;
    
    private void Awake()
    {
        if (instance == null) instance = this;
    }
    
    void Start()
    {
        isPlaying = false;
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
        

        //if (Fdc.onoff)
        //{
            if (Input.GetAxis("BouttonMenuParchemin") > 0.1f || Input.GetKeyDown(KeyCode.E))
            {
                OpenMenuParchemin();
            }
        //}

        if (MenuParcheminOuvert)
        {
            if (Input.GetKeyDown(KeyCode.JoystickButton1) || Input.GetKeyDown(KeyCode.B))
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
        if (pageOuverte == 1)
        {
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(fleche1);
        }
        
        if (pageOuverte == 2)
        {
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(fleche2);
        }
        
        if (pageOuverte == 3)
        {
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(fleche4);
        }
        
    }

    public void ChangementPageDroite()
    {
        if (!IsChanging)
        {
            StartCoroutine(Changement());
            float newPosPage1 = Page1.transform.position.x - distanceChangementPage;
            float newPosPage2 = Page2.transform.position.x - distanceChangementPage;
            float newPosPage3 = Page3.transform.position.x - distanceChangementPage;
            Page1.transform.DOMove(new Vector3(newPosPage1,Page1.transform.position.y,Page1.transform.position.z), 1.5f);
            Page2.transform.DOMove(new Vector3(newPosPage2,Page2.transform.position.y,Page2.transform.position.z), 1.5f);
            Page3.transform.DOMove(new Vector3(newPosPage3,Page3.transform.position.y,Page3.transform.position.z), 1.5f).OnComplete((() => IsChanging = false));
        }
        
    }

    IEnumerator Changement()
    {
        yield return new WaitForSeconds(0.1f);
        IsChanging = true;
    }
    
    public void ChangementPageGauche()
    {
        if (!IsChanging)
        {
            StartCoroutine(Changement());
            float newPosPage1 = Page1.transform.position.x + distanceChangementPage;
            float newPosPage2 = Page2.transform.position.x + distanceChangementPage;
            float newPosPage3 = Page3.transform.position.x + distanceChangementPage;
            Page1.transform.DOMove(new Vector3(newPosPage1,Page1.transform.position.y,Page1.transform.position.z), 1.5f);
            Page2.transform.DOMove(new Vector3(newPosPage2,Page2.transform.position.y,Page2.transform.position.z), 1.5f);
            Page3.transform.DOMove(new Vector3(newPosPage3,Page3.transform.position.y,Page3.transform.position.z), 1.5f).OnComplete((() => IsChanging = false));
        }
    }

    public void ChangementSelected1()
    {
        if (!IsChanging)
        {
            pageOuverte = 2;
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(fleche3);
        }
        
    }
    
    public void ChangementSelected2()
    {
        if (!IsChanging)
        {
            pageOuverte = 1;
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(fleche1);
        }
    }
    
    public void ChangementSelected3()
    {
        if (!IsChanging)
        {
            pageOuverte = 3;
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(fleche4);
        }
    }
    
    public void ChangementSelected4()
    {
        if (!IsChanging)
        {
            pageOuverte = 2;
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(fleche2);
        }
    }
    
    
    public void CloseMenuParchemin()
    {
        parchAnim.SetBool("FadeInParch",true);
        parchAnim.SetBool("FadeOutParch",false);
        
        MenuParcheminOuvert = false;
        menuParchemin.SetActive(false);
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
        isPlaying = true;
        EventSystem.current.SetSelectedGameObject(null);
        StartCoroutine(WaitMove());
        mainMenu.GetComponent<CanvasGroup>().interactable = false;
        FadeOut(2f);
        MenuPrincipalOuvert = false;
    }

    IEnumerator WaitMove()
    {
        if (cm.CinematiqueIntro)
        {
            yield return new WaitForSeconds(10.5f);
        } 
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
