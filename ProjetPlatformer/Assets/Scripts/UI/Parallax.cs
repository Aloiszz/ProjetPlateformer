using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float length, startpos;
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
        }
}