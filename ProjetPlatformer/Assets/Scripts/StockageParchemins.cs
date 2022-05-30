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
    public bool level1;

    // Update is called once per frame
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            level1 = false;
        }
    }
    
    private void Update()
    {
        CanvasUI = GameObject.FindWithTag("Canvas");
        parcheminManager = CanvasUI.GetComponent<ParcheminManager2>();

        
        if (level1 == true)
        {
            nbDeParchemins = parcheminManager.parcheminsObtenus;
            Debug.Log("1");
        }
        else if (level1 == false)
        {
           parcheminManager.parcheminsObtenus = nbDeParchemins;
           Debug.Log("2");
        }


        if (SceneManager.GetActiveScene().name == "LD Ruines 3")
        {
            StartCoroutine(Kill());
        }
        
        IEnumerator Kill()
        {
            yield return new WaitForSeconds(2f);
            Destroy(gameObject);
        }
        
        /*if (SceneManager.GetActiveScene().name == "LD 1 + mieux2")
        {
            Level1 = true;
        }
        else if (SceneManager.GetActiveScene().name == "LD Ruines 3")
        {
            Level1 = false;
        }*/
    }

   
}
