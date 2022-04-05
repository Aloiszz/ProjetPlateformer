using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingForeverPlatform : MonoBehaviour
{

    private Rigidbody2D rb;
    public float DeplacementY;
    public float DeplacementX;
    
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(DeplacementX, DeplacementY);
    }
}
