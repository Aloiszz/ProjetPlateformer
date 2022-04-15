using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using Unity.Mathematics;
using UnityEngine;
using DG.Tweening;

public class TestBow : MonoBehaviour
{
    
    public Vector2 direction;
    public float force;
    public bool isNull = false;

    [Header("Joystick position")]
    public float joystickX;
    public float joystickY;

    [Header("Tracer de la courbe")]
    public GameObject PointPrefab;
    public GameObject[] Points;
    public int numberOfpoints;

    public static TestBow ShootBowInstance;

    private void Awake()
    {
        if (ShootBowInstance == null) ShootBowInstance = this;
    }

    void Start()
    {
        Points = new GameObject[numberOfpoints];

        for (int i = 0; i < numberOfpoints; i++)
        {
            Points[i] = Instantiate(PointPrefab, transform.position, quaternion.identity);
        }
    }

    
    void Update()
    {
        joystickX = Input.GetAxisRaw("HorizontalAxis");
        joystickY = Input.GetAxisRaw("VerticalAxis");

        Vector2 MousePos = new Vector2(joystickX, -(joystickY)) * 360; //Debug.Log(Camera.main.ViewportToScreenPoint(Input.mousePosition));
        

        //Vector2 bowPos = transform.position;

        direction = MousePos ; //- bowPos
        
        FaceMouse();

        for (int i = 0; i < Points.Length; i++)
        {
            if (MousePos == new Vector2(0, 0))
            {
                Points[i].transform.DOMove(PointPositionNull(i * 0.1f), 0.2f);
                isNull = true;
            }
            else
            {
                Points[i].transform.DOMove(PointPosition(i * 0.1f), 0.2f);
                isNull = false;
            }
            //Points[i].transform.position = PointPosition(i * 0.1f);
        }
    }


    void FaceMouse()
    {
        transform.right = direction;
    }

    Vector2 PointPosition(float t)
    {
        Vector2 currentPointPos = (Vector2) transform.position + (direction.normalized * force * t) + 0.5f * Physics2D.gravity * (t*t);

        return currentPointPos;
    }
    
    Vector2 PointPositionNull(float t)
    {
        Vector2 currentPointPos = (Vector2) transform.position + (direction.normalized * 0 * t) + 0.5f * Physics2D.gravity * (t*t);

        return currentPointPos;
    }
}
