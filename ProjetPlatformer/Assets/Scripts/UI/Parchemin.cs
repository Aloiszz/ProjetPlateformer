using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parchemin : MonoBehaviour
{
    public GameObject parchemin1;
    public GameObject parchemin2;
    public GameObject parchemin3;
    public GameObject parchemin4;
    public GameObject parchemin5;
    public GameObject parchemin6;
    private bool getParchemin1;
    private bool getParchemin2;
    private bool getParchemin3;
    private bool getParchemin4;
    private bool getParchemin5;
    private bool getParchemin6;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (CompareTag("Player"))
        {
            Destroy(this);
        }
    }
}
