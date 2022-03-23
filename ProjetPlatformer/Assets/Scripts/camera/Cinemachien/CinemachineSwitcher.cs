using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemachineSwitcher : MonoBehaviour
{
    private bool owerworldCamera;

    [SerializeField]
    private CinemachineVirtualCamera vcam1; // npc
    
    [SerializeField]
    private CinemachineVirtualCamera vcam2; // dezoom

    private void OnTriggerEnter2D(Collider2D other)
    {
        SwitchPriority();
    }
    

    private void SwitchPriority()
    {
        if (owerworldCamera)
        {
            vcam1.Priority = 0;
            //vcam1.m_Lens.OrthographicSize = 45;
            vcam2.Priority = 1;
        }
        else
        {
            vcam1.Priority = 1;
            vcam2.Priority = 0;
        }
        owerworldCamera = !owerworldCamera;
    }
}
