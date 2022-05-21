using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using XInputDotNetPure;

public class PdPSalleDuHaut : MonoBehaviour
{
    public float timer;
    public float DistancePorteMax;
    public float speedPorte;
    public float speedPorte2;
    public GameObject porteAssociée;
    public GameObject porteAssociée2;
    public GameObject porteAssociée3;
    public GameObject SpotPorte2;
    public GameObject SpotPorte3;
    public bool boolStop;
    private Tween tweener;
    public GameObject mainCamera;
    public GameObject impultionElectique;

    [Header("Camera")] public CameraZoom Camera;
    public bool isCameraFix; // a cocher si l'on veut que la camera ne bouge plus 
    public GameObject EmplacementCamera; // permet d'établir une nouvelle position pour la camera (déplacement), Attention: l'emplacement est un peu buggeron établie le nouvel emplacement en fonction de l'emplacement du trigger et non celui du localScale de l'éditeur */
    public GameObject EmplacementCameraDeBase;

    //public float EmplacementCameraX;
    //public float EmplacementCameraY;

    [Header("modification camera")] 
    public float atoidejouet;
    public float distanceTarget = 9.999f; // permet d'établir la distance entre target et camera, plus la valeur est grande plus l'objet est loin
    public float dezoomSpeed = 2f; // permet d'ajuster sur la vitesse de la caméra pour dézoomer ou zoomer
    public float smoothSpeed = 2f;

    public bool salleDuHaut;
    
    PlayerIndex playerIndex;
    GamePadState state;
    GamePadState prevState;
    private bool doOnce;
    
    [Header("Vibration Motor")]
    public float leftMotor;
    public float rightMotor;
    public float duration;

    private void Update()
    {
        if (boolStop == true)
        {
            OuverturePorte();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Respawn")
        {
            impultionElectique.SetActive(true);
            OuverturePorte();
            StartCoroutine(Cinématique());
            if (!doOnce)
            {
                StartCoroutine(VibrationTime());
                doOnce = true;
            }
        }
    }

    IEnumerator Cinématique()
    {
        CharacterMovement.instance.canMove = false;
        CharacterMovement.instance.canJump = false;
        CharacterMovement.instance.speed = 0;
        yield return new WaitForSeconds(1.5f);
        Camera.smoothSpeed = dezoomSpeed;
        Camera.targetOrtho = distanceTarget;
        Camera.smoothSpeed = smoothSpeed;
        Camera.transform.DOMove(EmplacementCamera.transform.position,2f).SetEase(Ease.OutQuart);//OutQuart
        yield return new WaitForSeconds(3f);
        distanceTarget = atoidejouet;
        Camera.targetOrtho = distanceTarget;
        Camera.transform.DOMove(EmplacementCameraDeBase.transform.position,2f).SetEase(Ease.OutQuart);//OutQuart
        yield return new WaitForSeconds(1.5f);
        CharacterMovement.instance.canMove = true;
        CharacterMovement.instance.canJump = true;
        CharacterMovement.instance.speed = 11;
    }
   
    private void OuverturePorte()
    {
        transform.DOMove(transform.position + new Vector3(-0.05f,0,0), 1);
        boolStop = true;
        timer += Time.deltaTime;
        if (timer <= DistancePorteMax)
        {
            if (salleDuHaut)
            {
                porteAssociée.transform.position = Vector3.MoveTowards(porteAssociée.transform.position, porteAssociée.transform.position + Vector3.right,
                    speedPorte * Time.deltaTime);  
            }

            porteAssociée2.transform.position = Vector3.MoveTowards(porteAssociée2.transform.position, SpotPorte2.transform.position,
                speedPorte * Time.deltaTime);

            
            porteAssociée3.transform.position = Vector3.MoveTowards(porteAssociée3.transform.position, SpotPorte3.transform.position,
                    speedPorte2 * Time.deltaTime); 
            
            
            
            //tweener = mainCamera.transform.DOShakePosition(DistancePorteMax,2,1,30,false,true);
        }

        if (timer >= DistancePorteMax)
        {
            boolStop = false;
        }
    }
    
    IEnumerator VibrationTime()
    {
        GamePad.SetVibration(playerIndex, leftMotor, rightMotor);
        yield return new WaitForSeconds(duration);
        GamePad.SetVibration(playerIndex, 0, 0);
    }

}
