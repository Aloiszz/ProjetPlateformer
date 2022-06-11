using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptimisationduJeu : MonoBehaviour
{
    public bool isInRange = false;
    public GameObject shader;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = false;
        }
    }

    private void Update()
    {
        if (isInRange)
        {
            shader.SetActive(true);
        }
        else
        {
            shader.SetActive(false);
        }
    }
}
