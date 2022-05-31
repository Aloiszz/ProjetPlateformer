using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPBoite : MonoBehaviour
{
    public GameObject empty;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "GrosseBoîte")
        {
            other.transform.position = empty.transform.position;
            other.transform.rotation = new Quaternion(0, 0, 40, 0);
        }
    }
}
