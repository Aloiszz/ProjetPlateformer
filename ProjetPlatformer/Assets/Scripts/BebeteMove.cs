using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BebeteMove : MonoBehaviour
{
    public float speedbete;
    public float machin;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        machin += new Vector3(1, 0, 0).x;
        //transform.position.x = machin;
    }
}
