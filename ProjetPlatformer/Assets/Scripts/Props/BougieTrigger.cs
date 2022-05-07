using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BougieTrigger : MonoBehaviour
{
    public bool isTriggered;
    public List<Bougie> bougies;

    private int limit = 0;

    public static BougieTrigger instance;
    public void Start()
    {
        if (instance == null) instance = this;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        isTriggered = true;
        
        if (limit <= 0)
        {
            limit++;
            for (int i = 0; i < bougies.Count; i++)
            {
                bougies[i].AllumeBougie();
            }
        }
    }
}
