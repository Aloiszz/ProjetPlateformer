using System.Collections;
using System.Collections.Generic;
using System.Timers;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuManager : MonoBehaviour/*, IPointerClickHandler*/
{
    public GameObject camera;
    public GameObject parcheminManager;
    public GameObject mainMenu;
    public bool MenuParcheminOuvert;
    public bool MenuPrincipalOuvert;
    public Vector3 travellingStart;
    public float timeTravellingStart;
    [SerializeField] CameraZoom cameraZoom;
    public Vector3 emplacmentDébutCamera;

    
    void Start()
    {
        CharacterMovement.instance.canMove = false;
        CharacterMovement.instance.canJump = false;
        CharacterMovement.instance.speed = 0;
        mainMenu.SetActive(true);
        MenuPrincipalOuvert = true;
        parcheminManager.SetActive(false);
        MenuParcheminOuvert = false;
        //  CameraZoom.EmplacementCamera = emplacmentDébutCamera;
    }

  
    void Update()
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
        camera.transform.DOMove(travellingStart, timeTravellingStart);
        CharacterMovement.instance.canMove = true;
        CharacterMovement.instance.canJump = true;
        CharacterMovement.instance.speed = 11;
       // CameraZoom.EmplacementCamera = emplacmentDébutCamera;
    }


    public void Options()
    {
        
    }
    public void Quit()
    {
        Application.Quit();
    }
}
