using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ENDGAME : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Ce fut une belle aventure... J'espère que ce jeu on s'en rapellera comme étant une source d'apprentissage majeur.");
            MenuManager.instance.OpenCreditMenu();
        }
    }
}
