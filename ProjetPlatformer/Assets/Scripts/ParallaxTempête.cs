using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxTempête : MonoBehaviour
{
    public float parallaxSpeedX;
    public float parallaxSpeedY;
    public GameObject Empty;

    private Transform cameraTransform;
    private float startPositionX, startPositionY;


    void Start()
    {
        cameraTransform = Camera.main.transform;
        startPositionX = Empty.transform.position.x;
        startPositionY = Empty.transform.position.y;
       
    }

    void Update()
    {
        float relativeDistX =  startPositionX - cameraTransform.position.x;
        float relativeDistY =  startPositionY - cameraTransform.position.y;
        transform.position = new Vector3( startPositionX - relativeDistX * parallaxSpeedX,  startPositionY - relativeDistY * parallaxSpeedY, transform.position.z);
    }
}
