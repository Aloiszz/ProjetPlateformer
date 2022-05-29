using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StockageParchemins : MonoBehaviour
{
    public GameObject CanvasUI;
    public ParcheminManager2 parcheminManager;
    public int nbDeParchemins;
    public bool Level1;
    
    // Update is called once per frame
    private void Awake()
    {
        
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        CanvasUI = GameObject.FindWithTag("Canvas");
        parcheminManager = CanvasUI.GetComponent<ParcheminManager2>();

        
        if (Level1)
        {
            nbDeParchemins = parcheminManager.parcheminsObtenus;
        }
        else
        {
            parcheminManager.parcheminsObtenus = nbDeParchemins;
        }
        
        
        if (SceneManager.GetActiveScene().name == "LD 1 + mieux2")
        {
            Level1 = true;
        }
        else
        {
            Level1 = false;
        }
    }
}
