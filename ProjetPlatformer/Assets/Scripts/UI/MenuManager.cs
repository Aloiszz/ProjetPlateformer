using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
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
    [SerializeField] private CanvasGroup CgOption;
    [SerializeField] private CanvasGroup CgLevel;
    [SerializeField] private CanvasGroup CgAudio;
    [SerializeField] private CanvasGroup CgController;
    [SerializeField] private CanvasGroup CgCredit;
    private Tween fadeTween;
    public Animator parchAnim;
    public float distanceChangementPage;
    public CameraZoom cm;

    [Header("First Selected")]
    public GameObject firstSelctedOption;
    public GameObject firstSelctedMain;
    public GameObject firstSelectedLevel;
    public GameObject firstSelectedAudio;
    public GameObject firstSelectedController;
    public GameObject firstSelectedCredit;
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
    public GameObject menuLevel;
    public GameObject menuAudio;
    public GameObject menuController;
    public GameObject menuCredit;
    public GameObject menuPause;
    public GameObject menuParchemin;
    public GameObject Page1;
    public GameObject Page2;
    public GameObject Page3;

    [Header("Element indextion")] 
    public int indexINT = 0;
    public GameObject abeillos;
    public GameObject abeillos2;
    public GameObject index1;
    public GameObject index2;
    public GameObject index3;

    public bool isPlaying;
    public bool isInFeuxDeCamp;
    
    [Header("Crédit")] 
    public GameObject TxtDuCrédit;
    
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
        IndexMove();
            
            
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
        if (isInFeuxDeCamp)
        {
            if (Input.GetAxis("BouttonMenuParchemin") > 0.1f || Input.GetKeyDown(KeyCode.E))
            {
                OpenMenuParchemin();
            }   
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

    public void IndexMove()
    {
        if (Input.GetAxisRaw("Vertical") == 1f)
        {
            
            StartCoroutine(MonterIndex(indexINT));
            
            if (indexINT == 1)
            {
                abeillos.transform.DOMove(index2.transform.position, 0.1f);
            }
            else if (indexINT == 2)
            {
                abeillos.transform.DOMove(index3.transform.position, 0.1f);
            }
            else if (indexINT < 3)
            {
                abeillos.transform.DOMove(index2.transform.position, 0.1f);
                indexINT = 1;
            }
        }
        if (Input.GetAxisRaw("Vertical") == -1f)
        {
            
            //StartCoroutine(DescendreIndex(indexINT));
            
        }
    }

    IEnumerator DescendreIndex(int index)
    {
        yield return new WaitForSeconds(0.001f);
        indexINT --;
        
    }
    
    IEnumerator MonterIndex(int index)
    {
        yield return new WaitForSeconds(0.0001f);
        indexINT ++;
    }

    #region Menu Parchemin
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
    
    #endregion 
    
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
        menuOption.SetActive(true);
        menuPrincipal.SetActive(false);
        menuLevel.SetActive(false);
        menuAudio.SetActive(false);
        menuController.SetActive(false);
        menuCredit.SetActive(false);

        cv.DOFade(0, 0.5f);
        CgOption.DOFade(1, 0.5f);
        CgLevel.DOFade(0, 0.5f);
        CgAudio.DOFade(0, 0.5f);
        CgController.DOFade(0, 0.5f);
        CgCredit.DOFade(0, 0.5f);
    }

    public void OpenMainMenu()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(firstSelctedMain);
        menuOption.SetActive(false);
        menuPrincipal.SetActive(true);
        
        cv.DOFade(1, 0.5f);
        CgOption.DOFade(0, 0.5f);
    }

    public void OpenLevelsMenu()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(firstSelectedLevel);
        menuOption.SetActive(false);
        menuLevel.SetActive(true);
        
        CgOption.DOFade(0, 0.5f);
        CgLevel.DOFade(1, 0.5f);
    }
    
    public void OpenAudioMenu()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(firstSelectedAudio);
        menuOption.SetActive(false);
        menuAudio.SetActive(true);
        
        CgOption.DOFade(0, 0.5f);
        CgAudio.DOFade(1, 0.5f);
    }
    
    public void OpenControllerMenu()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(firstSelectedController);
        menuOption.SetActive(false);
        menuController.SetActive(true);
        
        CgOption.DOFade(0, 0.5f);
        CgController.DOFade(1, 0.5f);
    }
    
    public void OpenCreditMenu()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(firstSelectedCredit);
        menuOption.SetActive(false);
        menuCredit.SetActive(true);
        
        CgOption.DOFade(0, 0.5f);
        CgCredit.DOFade(1, 0.5f);

        TxtDuCrédit.transform.DOMoveY(750, 20);
    }

    public void JoinLevel1()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    
    public void JoinLevel2()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
