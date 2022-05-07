using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using XInputDotNetPure;

public class FinTriggerPiqueQuiBougent : MonoBehaviour
{
    
    [SerializeField] private List<ClapetVent> waypoints;
    [SerializeField] private float moveSpeed = 5f;

    public GameObject DeathZone1;
    public GameObject DeathZone2;
    public GameObject DeathZone3;

    private int DoOnce = 0;
    
    PlayerIndex playerIndex;
    GamePadState state;
    GamePadState prevState;
    private bool doOnce;
    
    [Header("Vibration Motor")]
    public float leftMotor;
    public float rightMotor;
    public float duration;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Respawn")
        {
            if (DoOnce == 0)
            {
                DeathZone1.SetActive(false);
                DeathZone2.SetActive(false);
                DeathZone3.SetActive(false);
                DoOnce++;
                StartCoroutine(Wait());
                for (int i = 0; i < waypoints.Count; i++)
                {
                    waypoints[i].moveSpeed = moveSpeed;
                }
                StartCoroutine(VibrationTime());
            }
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < waypoints.Count; i++)
        {
            waypoints[i].transform.DOScale(new Vector3(0, 0, 0), 1f);
            waypoints[i].transform.DORotate(new Vector3(0,0, -720), 1f);
        }
    }
    
    IEnumerator VibrationTime()
    {
        GamePad.SetVibration(playerIndex, leftMotor, rightMotor);
        yield return new WaitForSeconds(duration);
        GamePad.SetVibration(playerIndex, 0, 0);
    }
}
