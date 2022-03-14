using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class RalentissementMonstres : MonoBehaviour
{
    public IAMonstre1 IA;
    public bool monstreSlowed;
    public float slowValue;
    private float speedNormal = 5;
    public float timeSlowed;
    private float timerSlowed;
    

    void OnCollisionEnter2D (Collision2D other)
    {
        if (other.gameObject.tag == "Goutte") 
        {
        monstreSlowed = true; 
        }
    }

    private void Update()
    {
        if (monstreSlowed)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
            IA.speed = slowValue;
            timerSlowed += Time.deltaTime;
            if (timerSlowed >= timeSlowed)
            {
                monstreSlowed = false;
                timerSlowed = 0;
                gameObject.GetComponent<SpriteRenderer>().color = Color.white;
                IA.speed = speedNormal;
            }
        }
    }
}
