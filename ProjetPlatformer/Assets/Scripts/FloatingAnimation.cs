using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingAnimation : MonoBehaviour
{
    private float y0;
    private Vector2 temp;
    public float amplitudeFloating;
    public float vitesseFloating;

    private void Start()
    {
        temp = transform.position;
        y0 = transform.position.y;
    }

    private void Update()
    {
        temp.y = y0 + amplitudeFloating *Mathf.Sin(vitesseFloating*Time.time);
        transform.position = temp;
    }
}
