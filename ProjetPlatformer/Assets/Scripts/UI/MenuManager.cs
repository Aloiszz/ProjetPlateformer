using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.SceneManagement;
using XInputDotNetPure;

public class MenuManager : MonoBehaviour/*, IPointerClickHandler*/
{
    [Header("Bool Open/Close")]
    public bool MenuParcheminOuvert;
    public bool MenuPrincipalOuvert;
    public bool IsChanging;
    public int pageOuverte = 1;
    public bool ActivateMenu = true;
    public bool StopPause;
    public bool OptionPause;
    public bool NON;

    [Header("Divers")]
    public FeuxDeCamp Fdc;
    public GameObject Parcheminmanager;
    [SerializeField] private CanvasGroup cv;
    [SerializeField] private CanvasGroup CgOption;
    [SerializeField] private CanvasGroup CgLevel;
    [SerializeField] private CanvasGroup CgAudio;
    [SerializeField] private CanvasGroup CgController;
    [SerializeField] private CanvasGroup CgCredit;
    [SerializeField] private CanvasGroup CgOptionpause;
    [SerializeField] private CanvasGroup CgCreditFin;
    [SerializeField] private CanvasGroup CgLevelPause;
    [SerializeField] private CanvasGroup CgAudioPause;
    [SerializeField] private CanvasGroup CgControllerPause;
    [SerializeField] private CanvasGroup CgCréditPause;
    private Tween fadeTween;
    public Animator parchAnim;
    public float distanceChangementPage;
    public CameraZoom cm;
    public AnimationIconeParch icone;

    [Header("First Selected")]
    public GameObject firstSelctedOption;
    public GameObject firstSelctedMain;
    public GameObject firstSelectedLevel;
    public GameObject firstSelectedAudio;
    public GameObject firstSelectedController;
    public GameObject firstSelectedCredit;
    public GameObject firstSelectedPause;
    public GameObject firstSelectedConfirmationRestart;
    public GameObject firstSelectedOptionPause;
    public GameObject firstSelectedCreditFin;
    public GameObject firstSelectedLevelPause;
    public GameObject firstSelectedAudioPause;
    public GameObject firstSelectedControllerPause;
    public GameObject firstSelectedCreditPause;
    public GameObject fleche1;
    public GameObject fleche2;
    public GameObject fleche3;
    public GameObject fleche4;
    
    [Header("Éléments du Menu")]
    public GameObject mainMenu;
    public GameObject menuPrincipal;
    public GameObject menuOption;
    public GameObject menuOptionPause;
    public GameObject menuLevel;
    public GameObject menuAudio;
    public GameObject menuController;
    public GameObject menuCredit;
    public GameObject menuPause;
    public GameObject menuParchemin;
    public GameObject menuCreditFin;
    public GameObject menuLevelPause;
    public GameObject menuAudioPause;
    public GameObject menuControllerPause;
    public GameObject menuCreditPause;
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
    public RectTransform TxtDuCrédit;
    public RectTransform DebutSpotCredit;
    public RectTransform FinSpotCredit;
    
    public RectTransform TxtDuCréditFin;
    public RectTransform DebutSpotCreditFin;
    public RectTransform FinSpotCreditFin;
    
    public static MenuManager instance;

    private void Awake()
    {
        if (instance == null) instance = this;
    }
    
    void Start()
    {
        parchAnim = GameObject.Find("IndicationParchemins").GetComponent<Animator>();
        Fdc = GameObject.Find("FeuxDeCamp").GetComponent<FeuxDeCamp>();
        cm = GameObject.Find("Main Camera").GetComponent<CameraZoom>();
       
        
       
        
      DontDestroyOnLoad(gameObject);
        if (ActivateMenu)
        {
            isPlaying = false;
            mainMenu.SetActive(true);
            MenuPrincipalOuvert = true;
            FadeIn(2f);
        }
        
        menuParchemin.SetActive(false);
        //parcheminManager.SetActive(false);
        MenuParcheminOuvert = false;
        
    }
    
    void Update()
    {
        
        parchAnim = GameObject.Find("IndicationParchemins").GetComponent<Animator>();
        Fdc = GameObject.Find("FeuxDeCamp").GetComponent<FeuxDeCamp>();
        cm = GameObject.Find("Main Camera").GetComponent<CameraZoom>();
        icone = GameObject.Find("IndicationParchemins").GetComponent<AnimationIconeParch>();

        IndexMove();
        
        
        if (MenuParcheminOuvert)
        {
            if (pageOuverte != 3 && Input.GetKeyDown(KeyCode.Joystick1Button5) && IsChanging == false)
            {
                ChangementPageDroite();
                Debug.Log("droit");
                pageOuverte += 1;
                if (pageOuverte == 1)
                {
                    EventSystem.current.SetSelectedGameObject(null);
                    EventSystem.current.SetSelectedGameObject(fleche1);
                }
                if (pageOuverte == 2)
                {
                    EventSystem.current.SetSelectedGameObject(null);
                    EventSystem.current.SetSelectedGameObject(fleche3);
                }
                if (pageOuverte == 3)
                {
                    EventSystem.current.SetSelectedGameObject(null);
                    EventSystem.current.SetSelectedGameObject(fleche4);
                }
            }
        }

        
        
        if (MenuParcheminOuvert)
        {
            if (pageOuverte != 1 && Input.GetKeyDown(KeyCode.Joystick1Button4) && IsChanging == false)
            {
                ChangementPageGauche();
                Debug.Log("gauche");
                pageOuverte -= 1;
                if (pageOuverte == 1)
                {
                    EventSystem.current.SetSelectedGameObject(null);
                    EventSystem.current.SetSelectedGameObject(fleche1);
                }
                if (pageOuverte == 2)
                {
                    EventSystem.current.SetSelectedGameObject(null);
                    EventSystem.current.SetSelectedGameObject(fleche3);
                }
                if (pageOuverte == 3)
                {
                    EventSystem.current.SetSelectedGameObject(null);
                    EventSystem.current.SetSelectedGameObject(fleche4);
                }
            }
        }

        if (NON)
        {
            CharacterMovement.instance.canMove = false;
            CharacterMovement.instance.canJump = false;
            CharacterMovement.instance.speed = 0; 
        }
        
        if (MenuPrincipalOuvert == false && MenuParcheminOuvert == false && OptionPause == false)
        {
            if (Input.GetKeyUp(KeyCode.JoystickButton7) || Input.GetKeyDown(KeyCode.Escape) && OptionPause == false)
            {
                NON = true;
                CharacterMovement.instance.blockCinematiques = true;
                //Time.timeScale = 0;
                menuPause.SetActive(true);
                EventSystem.current.SetSelectedGameObject(null);
                EventSystem.current.SetSelectedGameObject(firstSelectedPause);
                CharacterMovement.instance.canMove = false;
                CharacterMovement.instance.canJump = false;
                CharacterMovement.instance.speed = 0;
            }
            else if (Input.GetKeyUp(KeyCode.JoystickButton7) || Input.GetKeyDown((KeyCode.Escape)))
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

    public void NonPause()
    {
        StopPause = true;
    }
    
    public void OuiPause()
    {
        StopPause = false;
    }
    public void Restart()
    {
        MenuParcheminOuvert = false;
        menuParchemin.SetActive(false);
        OptionPause = false;
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(firstSelctedMain);
        SceneManager.LoadScene(0);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(firstSelctedMain);
        Time.timeScale = 1;
        Destroy(Parcheminmanager);
        Destroy(gameObject);
        
        
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
        icone.NewParchemin = false;
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

    public void OpenPause()
    {
        menuPause.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(firstSelectedPause);
    }
    
    public void ChangementPageDroite()
    {
        if (!IsChanging)
        {
            StartCoroutine(Changement());
            float newPosPage1 = Page1.transform.position.x - Screen.width + 20;
            float newPosPage2 = Page2.transform.position.x - Screen.width + 20;
            float newPosPage3 = Page3.transform.position.x - Screen.width + 20;
            Page1.transform.DOMove(new Vector3(newPosPage1,Page1.transform.position.y,Page1.transform.position.z), 1.5f);
            Page2.transform.DOMove(new Vector3(newPosPage2,Page2.transform.position.y,Page2.transform.position.z), 1.5f);
            Page3.transform.DOMove(new Vector3(newPosPage3,Page3.transform.position.y,Page3.transform.position.z), 1.5f).OnComplete((() => IsChanging = false));
        }
        
    }
    IEnumerator Changement()
    {
        IsChanging = true;
        yield return true;
    }
    public void ChangementPageGauche()
    {
        if (!IsChanging)
        {
            StartCoroutine(Changement());
            float newPosPage1 = Page1.transform.position.x + Screen.width - 20;
            float newPosPage2 = Page2.transform.position.x + Screen.width - 20;
            float newPosPage3 = Page3.transform.position.x + Screen.width - 20;
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

    public void PréRestart()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(firstSelectedConfirmationRestart);
        StopPause = true;
    }

    public void UnRestart()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(firstSelectedPause);
    }
    
    public void Unpause()
    {
        NON = false;
        CharacterMovement.instance.blockCinematiques = false;
        OptionPause = false;
        menuPause.SetActive(false);
        Time.timeScale = 1;
        CharacterMovement.instance.canMove = true;
        CharacterMovement.instance.canJump = true;
        CharacterMovement.instance.speed = 11;
        CharacterMovement.instance.animator.SetBool("IsFdC", false);
        CharacterMovement.instance.animator.SetTrigger("SortieFdC");
        
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
            yield return new WaitForSeconds(11.5f);
        } 
            CharacterMovement.instance.canMove = true;
            CharacterMovement.instance.canJump = true;
            CharacterMovement.instance.speed = 11;
        
    }

    public void OpenOptionPause()
    {
        OptionPause = true;
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(firstSelectedOptionPause);
        menuOptionPause.SetActive(true);
        menuLevelPause.SetActive(false);
        menuAudioPause.SetActive(false);
        menuControllerPause.SetActive(false);
        menuCreditPause.SetActive(false);
        
        TxtDuCrédit.transform.DOKill();
        TxtDuCrédit.transform.position = DebutSpotCredit.transform.position;
        
        cv.DOFade(0, 0.5f);
        CgOptionpause.DOFade(1, 0.5f);
        CgLevelPause.DOFade(0, 0.5f);
        CgAudioPause.DOFade(0, 0.5f);
        CgControllerPause.DOFade(0, 0.5f);
        CgCréditPause.DOFade(0, 0.5f);
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
        
        TxtDuCrédit.transform.DOKill();
        TxtDuCrédit.transform.position = DebutSpotCredit.transform.position;

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
        menuOptionPause.SetActive(false);
        menuLevel.SetActive(true);
        
        CgOption.DOFade(0, 0.5f);
        CgLevel.DOFade(1, 0.5f);
    }
    
    public void OpenAudioMenu()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(firstSelectedAudio);
        menuOption.SetActive(false);
        menuOptionPause.SetActive(false);
        menuAudio.SetActive(true);
        
        CgOption.DOFade(0, 0.5f);
        CgAudio.DOFade(1, 0.5f);
    }
    
    public void OpenControllerMenu()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(firstSelectedController);
        menuOption.SetActive(false);
        menuOptionPause.SetActive(false);
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
        menuOptionPause.SetActive(false);
        CgOption.DOFade(0, 0.5f);
        CgCredit.DOFade(1, 0.5f);

        TxtDuCrédit.transform.DOMove(FinSpotCredit.transform.position, 20);
    }

    public void OpendCreditFin()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(firstSelectedCreditFin);
        menuOption.SetActive(false);
        menuCreditFin.SetActive(true);
        menuOptionPause.SetActive(false);
        CgOption.DOFade(0, 0.5f);
        CgCreditFin.DOFade(1, 0.5f);

        TxtDuCréditFin.transform.DOMove(FinSpotCreditFin.transform.position, 20);
    }

    public void OpenRestartEndGame()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(firstSelctedMain);
        SceneManager.LoadScene(0);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(firstSelctedMain);
        menuCreditFin.SetActive(false);
        CgCreditFin.DOFade(0, 0.5f);
        Time.timeScale = 1;
    }

    IEnumerator Music()
    {
        MuqiqueManager.instance.audioSource.Stop();
        MuqiqueManager.instance.MusicStart = true;
        yield return new WaitForSeconds(0.5f);
        MuqiqueManager.instance.MusicStart = false; 
    }
    
    public void JoinLevel1()
    {
        
        StartCoroutine(Music());
        OptionPause = false;
        menuLevelPause.SetActive(false);
        menuLevel.SetActive(false);
        SceneManager.LoadScene(0);
        Restart();
    }
    
    IEnumerator Music2()
    {
        MuqiqueManager.instance.audioSource.Stop();
        MuqiqueManager.instance.MusicRuines = true;
        yield return new WaitForSeconds(0.5f);
        MuqiqueManager.instance.MusicRuines = false; 
    }
    
    public void JoinLevel2()
    {
        StartCoroutine(Music2());
        OptionPause = false;
        menuLevelPause.SetActive(false);
        menuLevel.SetActive(false);
        SceneManager.LoadScene(1);
        Play();
    }

    public void OpenLevelPause()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(firstSelectedLevelPause);
        menuOptionPause.SetActive(false);
        menuLevelPause.SetActive(true);
        
        CgOptionpause.DOFade(0, 0.5f);
        CgLevelPause.DOFade(1, 0.5f);
    }

    public void OpenAudioPause()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(firstSelectedAudioPause);
        menuOptionPause.SetActive(false);
        menuAudioPause.SetActive(true);
        
        CgOptionpause.DOFade(0, 0.5f);
        CgAudioPause.DOFade(1, 0.5f);
    }

    public void OpenControllerPause()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(firstSelectedControllerPause);
        menuOptionPause.SetActive(false);
        menuControllerPause.SetActive(true);
        
        CgOptionpause.DOFade(0, 0.5f);
        CgControllerPause.DOFade(1, 0.5f);
    }

    public void OpenCreditPause()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(firstSelectedCreditPause);
        menuCreditPause.SetActive(true);
        menuOptionPause.SetActive(false);
        CgOptionpause.DOFade(0, 0.5f);
        CgCréditPause.DOFade(1, 0.5f);

        TxtDuCréditFin.transform.DOMove(FinSpotCreditFin.transform.position, 20);
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
