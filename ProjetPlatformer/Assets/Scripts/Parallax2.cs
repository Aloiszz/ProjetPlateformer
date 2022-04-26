using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax2 : MonoBehaviour
{
   public float parallaxSpeedX;
   public float parallaxSpeedY;

   private Transform cameraTransform;
   private float startPositionX, startPositionY;
   private float spriteSizeX;

   void Start()
   {
      cameraTransform = Camera.main.transform;
      startPositionX = transform.position.x;
      startPositionY = transform.position.y;
      spriteSizeX = GetComponent<SpriteRenderer>().bounds.size.x;
   }

   void Update()
   {
      float relativeDistX = cameraTransform.position.x * parallaxSpeedX;
      float relativeDistY = cameraTransform.position.y * parallaxSpeedY;
      transform.position = new Vector3(startPositionX + relativeDistX, startPositionY + relativeDistY, transform.position.z);

      float relativeCameraDist = cameraTransform.position.x * (1 - parallaxSpeedX);
      if (relativeCameraDist > startPositionX + spriteSizeX)
      {
         startPositionX += spriteSizeX;
      }
      else if (relativeCameraDist < startPositionX - spriteSizeX)
      {
         startPositionX -= spriteSizeX;
      }
   }
}
