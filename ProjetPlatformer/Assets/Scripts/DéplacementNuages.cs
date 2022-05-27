using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DéplacementNuages : MonoBehaviour
{
    public float parallaxSpeedX;
    public float parallaxSpeedY;

    private Transform cameraTransform;
    public Camera mainCamera;
    private float startPositionY;
    private float spriteSizeX;

    void Start()
    {
        cameraTransform = Camera.main.transform;
        startPositionY = transform.position.y;
        spriteSizeX = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        float relativeDistY = cameraTransform.position.y * parallaxSpeedY;
        transform.position += new Vector3(parallaxSpeedX, 0,0);
        transform.position = new Vector3(transform.position.x, (startPositionY + relativeDistY),transform.position.z);

        float relativePositionX = cameraTransform.position.x - transform.position.x; 
        if (relativePositionX > 2f * mainCamera.orthographicSize + spriteSizeX)
        {
            transform.position += new Vector3(spriteSizeX*2 + (2f * mainCamera.orthographicSize)*2,Random.Range(3,9),0);
        }
    }
}
