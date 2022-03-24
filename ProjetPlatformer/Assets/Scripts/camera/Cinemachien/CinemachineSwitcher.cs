using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemachineSwitcher : MonoBehaviour
{
    private bool owerworldCamera;
    public float orthographicSize = 9.999f;

    [SerializeField]
    private CinemachineVirtualCamera vcam1; // npc
    
    [SerializeField]
    //private CinemachineVirtualCamera vcam2; // dezoom

    private void OnTriggerEnter2D(Collider2D other)
    {
        SwitchPriority();
        //vcam1.m_Lens.OrthographicSize = orthographicSize;
    }
    

    private void SwitchPriority()
    {
        if (owerworldCamera)
        {
            vcam1.Priority = 0;
            //vcam2.Priority = 1;
        }
        else
        {
            vcam1.Priority = 1;
            //vcam2.Priority = 0;
        }
        owerworldCamera = !owerworldCamera;
        Debug.Log(owerworldCamera);
    }
}
