using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using XInputDotNetPure;

public class LoadingScript : MonoBehaviour
{
    public float Time;
    public GameObject pointPlayer;
    public GameObject pointPlayer2;
    public GameObject piedDuFeux;
    public Animator Anim;
    public Animator AnimFdC;
    public MenuManager mm;
    public GameObject Barre2;
    public GameObject Barre1;
    
    [Header("UI")]
    public bool canSee = false;
    public CanvasGroup Continue;
    public CanvasGroup loading;

    [Header("Animation Curve")]
    public AnimationCurve AnimLoading;
    public Slider Slider;
    private float graph, increment;
    private bool canRunGame;
    private bool stopWakeUp;
    
    PlayerIndex playerIndex;
    GamePadState state;
    GamePadState prevState;
    private bool doOnce;
    
    [Header("Vibration Motor")]
    public float leftMotor;
    public float rightMotor;
    public float duration;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.DOMove(pointPlayer.transform.position, Time).SetEase(Ease.Linear);
        Anim.SetBool("IsWalking", true);
        
        mm = GameObject.Find("Canvas (Menu)").GetComponent<MenuManager>();
        mm.isPlaying = false;
        //Barre1 = GameObject.Find("")
    }

    // Update is called once per frame
    void Update()
    {
        Slider.value = 1;
        increment += UnityEngine.Time.deltaTime;
        graph = AnimLoading.Evaluate(increment);
        Slider.value = graph;
        
        if (!doOnce)
        {
            StartCoroutine(VibrationTime());
            doOnce = true;
        }
        
        StartCoroutine(WaitForSecond());
        StartCoroutine(WaitForLevel());
        
        if (!canSee)
        {
            StartCoroutine(Loading());
        }
        

        if (canSee)
        {
            if (Input.GetButtonDown("GrabGamepad") || Input.GetKeyDown(KeyCode.F))
            {
                StopAllCoroutines();
                StartCoroutine(Leave());
            }
        }
    }

    IEnumerator WaitForSecond()
    {
        yield return new WaitForSeconds(Time);
        piedDuFeux.SetActive(true);
        Anim.SetBool("IsWalking", false);
        Anim.SetTrigger("EntreeFdC");
        Anim.SetBool("IsFdC", true);
        AnimFdC.SetBool("isFire", true);
    }
    
    IEnumerator WaitForLevel()
    {
        yield return new WaitForSeconds(Time+3);
        canSee = true;
        Continue.DOFade(1, 1f);
    }
    
    IEnumerator Loading()
    {
        yield return new WaitForSeconds(0.5f);
        loading.DOFade(1, 1);
    }

    IEnumerator Leave()
    {
        Debug.Log("CACA "+ (SceneManager.GetActiveScene().buildIndex - 1));
        yield return new WaitForSeconds(0.1f);
        Anim.ResetTrigger("EntreeFdC");
        Anim.SetTrigger("SortieFdC");
        Anim.SetBool("IsFdC", false);
        yield return new WaitForSeconds(0.5f);
        Debug.Log("poupou "+ (SceneManager.GetActiveScene().buildIndex - 1));
        gameObject.transform.DOMove(pointPlayer2.transform.position, Time-1).SetEase(Ease.Linear);
        Anim.SetBool("IsWalking", true);
        Continue.DOFade(0, 1f);
        loading.DOFade(0, 1f);
        yield return new WaitForSeconds(Time-1);
        mm.isPlaying = true;
        Debug.Log("HOLA "+ (SceneManager.GetActiveScene().buildIndex - 1));
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    
    IEnumerator VibrationTime()
    {
        yield return new WaitForSeconds(Time+0.9f);
        GamePad.SetVibration(playerIndex, leftMotor, rightMotor);
        yield return new WaitForSeconds(duration);
        GamePad.SetVibration(playerIndex, 0, 0);
    }
    
}
