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
    public GameObject camera;
    public Vector3 travellingStart;
    public float timeTravellingStart;
    [SerializeField] CameraZoom cameraZoom;
    public Vector3 emplacmentDébutCamera;

    
    void Start()
    {
        parcheminManager.SetActive(false);
        MenuOuvert = false;
        CharacterMovement.instance.canMove = false;
        CharacterMovement.instance.canJump = false;
        CharacterMovement.instance.speed = 0;
      //  CameraZoom.EmplacementCamera = emplacmentDébutCamera;
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


    public void Play()
    {
        camera.transform.DOMove(travellingStart, timeTravellingStart);
        CharacterMovement.instance.canMove = true;
        CharacterMovement.instance.canJump = true;
        CharacterMovement.instance.speed = 11;
       // CameraZoom.EmplacementCamera = emplacmentDébutCamera;
    }
    public void Quit()
    {
        Application.Quit();
    }
}
