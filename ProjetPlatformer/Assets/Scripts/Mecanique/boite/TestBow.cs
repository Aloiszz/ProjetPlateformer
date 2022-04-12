using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using Unity.Mathematics;
using UnityEngine;

public class TestBow : MonoBehaviour
{

    public Vector2 direction;

    public float force;

    public GameObject PointPrefab;

    public GameObject[] Points;

    public int numberOfpoints;
    // Start is called before the first frame update
    void Start()
    {
        Points = new GameObject[numberOfpoints];

        for (int i = 0; i < numberOfpoints; i++)
        {
            Points[i] = Instantiate(PointPrefab, transform.position, quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        //Camera.main.ViewportToScreenPoint(Input.mousePosition);
        Vector2 MousePos = Camera.main.ViewportToScreenPoint(Input.mousePosition) ;
        

        Vector2 bowPos = transform.position;

        direction = MousePos - bowPos;
        
        FaceMouse();

        for (int i = 0; i < Points.Length; i++)
        {
            Points[i].transform.position = PointPosition(i * 0.1f);
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
}
