using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnBoite : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject player;

    void Start()
    {
        
    }

    // Update is called once per frame


    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Respawn")
        other.transform.position = player.transform.position;
    }
}