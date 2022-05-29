using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;
using DG.Tweening;

public class Stamina : MonoBehaviour
{
    public Slider staminaBar;

    private float maxStamina = 100f;
    private float currentStamina;

    private WaitForSeconds regenTick = new WaitForSeconds(0.1f);
    private Coroutine regen;

    public static Stamina instance;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    private void Start()
    {
        currentStamina = maxStamina;
        staminaBar.maxValue = maxStamina;
        staminaBar.value = maxStamina;
    }

    public void Update()
    {
        if (currentStamina <= 0)
        {
            CharacterMovement.instance.isPlannage = false;
            staminaBar.gameObject.SetActive(true);
            //staminaBar.GetComponent<SpriteRenderer>().DOFade(1, 0.3f);
        }
        else
        {
            CharacterMovement.instance.isPlannage = true;
            staminaBar.gameObject.SetActive(false);
            //staminaBar.GetComponent<SpriteRenderer>().DOFade(0, 0.3f);
        }

        if (currentStamina < maxStamina )
        {
            staminaBar.gameObject.SetActive(true);
            //staminaBar.GetComponent<SpriteRenderer>().DOFade(0, 0.3f);
        }
    }

    public void UseStamina(float amount)
    {
        if (currentStamina - amount >= -35)
        {
            currentStamina -= amount * Time.deltaTime;
            staminaBar.value = currentStamina;

            if (regen != null)
            {
                StopCoroutine(regen);
            }
            regen = StartCoroutine(RegentStamina());
        }
        else
        {
            Debug.Log("not enough stamina");
        }
    }

    private IEnumerator RegentStamina()
    {
        yield return new WaitForSeconds(0.5f);

        while (currentStamina < maxStamina)
        {
            currentStamina += (maxStamina * 6) / 100; 
            staminaBar.value = currentStamina;
            yield return regenTick;
        }
        regen = null;
    }


    /*[Header("Base settings")]
    public float playerStamina = 100f;
    [SerializeField] private float maxStamina = 100f;
    [SerializeField] private float plannageCost = 2.5f;
    [SerializeField] private float doubleJumpCost = 33.33f;

    [Header("Parameter")]
    [HideInInspector] public bool hasRegenerated = true;
    [HideInInspector] public bool isPlannageStamina = false;
    [HideInInspector] public bool isDoubleJumpStamina = false;

    
    [Range(0,50)] [SerializeField] private float staminaDrain = 0.5f;
    [Range(0,50)] [SerializeField] private float staminaRegen = 0.5f;
    
    [Header("UI")]
    [SerializeField] private Image staminaProgressUI = null;
    [SerializeField] private CanvasGroup sliderCanvasGroup = null;

    private CharacterMovement player;


    private void Update()
    {
        if (!isPlannageStamina)
        {
            if (playerStamina <= maxStamina - 0.1f)
            {
                playerStamina += staminaRegen * Time.deltaTime;
                StaminaUpdate(1);
            }
            if (playerStamina >= maxStamina)
            {
                sliderCanvasGroup.alpha = 0;
                hasRegenerated = true;
            }
        }
    }

    public void Plannage()
    {
        if (hasRegenerated)
        {
            isPlannageStamina = true;
            playerStamina -= staminaDrain * Time.deltaTime;
            StaminaUpdate(1);

            if (playerStamina > 0)
            {
                hasRegenerated = false;
                sliderCanvasGroup.alpha = 0f;
            }
        }
    }

    public void DoubleJumpStamina()
    {
        if (playerStamina >= (maxStamina * doubleJumpCost / maxStamina))
        {
            playerStamina -= doubleJumpCost;
            StaminaUpdate(1);
        }
    }

    void StaminaUpdate(int value)
    {
        staminaProgressUI.fillAmount = playerStamina / maxStamina;
        if (value == 0)
        {
            sliderCanvasGroup.alpha = 0;
        }
        else
        {
            sliderCanvasGroup.alpha = 1;
        }
    }*/
}
