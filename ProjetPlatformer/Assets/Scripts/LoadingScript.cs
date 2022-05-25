using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

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
        StartCoroutine(WaitForSecond());
        StartCoroutine(WaitForLevel());

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
    
    IEnumerator Leave()
    {
        yield return new WaitForSeconds(0.1f);
        Anim.ResetTrigger("EntreeFdC");
        Anim.SetTrigger("SortieFdC");
        Anim.SetBool("IsFdC", false);
        yield return new WaitForSeconds(0.5f);
        gameObject.transform.DOMove(pointPlayer2.transform.position, Time-1).SetEase(Ease.Linear);
        Anim.SetBool("IsWalking", true);
        Continue.DOFade(0, 1f);
        yield return new WaitForSeconds(Time-1);
        mm.isPlaying = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
