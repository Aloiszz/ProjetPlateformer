using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingForeverPlatform : MonoBehaviour
{

    private Rigidbody2D rb;
    public Rigidbody2D rbPlayer;
    public float DeplacementY;
    public float DeplacementX;
    public bool PlayerFollow;
    public GameObject player;
    private Transform stop;
    private GameObject target=null;
    private Vector3 offset;
    
    
    void Start()
    {
        target = null;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(DeplacementX, DeplacementY);

        /*if (rbPlayer.velocity.x != 0)
        {
            transform.parent = null;
            player.GetComponent<Rigidbody2D>().isKinematic=false;
        }
        
        if (rbPlayer.velocity.y != 0)
        {
            transform.parent = null;
            player.GetComponent<Rigidbody2D>().isKinematic=false;
        }*/
    }
    
    /*void OnCollisionEnter2D(Collision2D other)
    {
        target = null;
        player.GetComponent<Rigidbody2D>().isKinematic=true;
        other.transform.parent = transform;
    }
    void OnCollisionExit2D(Collision2D other)
    {
        StartCoroutine(WaitKinematic());
        Debug.Log("Chips");
        other.transform.SetParent(null);
    }


    IEnumerator WaitKinematic()
    {
        yield return new WaitForSeconds(0.1f);
        player.GetComponent<Rigidbody2D>().isKinematic=false;
    }*/
}
