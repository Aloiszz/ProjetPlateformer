using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    /*public float length, startpos;
        public GameObject cam;
        public float parallaxEffetc;
        
        void Start()
        {
            startpos = transform.position.x;
            length = GetComponent<SpriteRenderer>().bounds.size.x;
        }
    
        // Update is called once per frame
        private void FixedUpdate()
        {
            float temp = (cam.transform.position.x * (1 - parallaxEffetc));
            float dist = (cam.transform.position.x * parallaxEffetc);
    
            transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);
    
            if (temp > startpos + length) startpos += length;
            else if (temp < startpos - length) startpos -= length;
        }*/
    
    
    private float lenght;  
    private float startPosition;
    public GameObject camera;
    public float parallaxEffect;

    void Start()
    {
        startPosition = transform.position.x;
    }

    void Update()
    { 
        float dist = (camera.transform.position.x * parallaxEffect);
        transform.position = new Vector3(startPosition + dist, transform.position.y, transform.position.z);
    }
}
