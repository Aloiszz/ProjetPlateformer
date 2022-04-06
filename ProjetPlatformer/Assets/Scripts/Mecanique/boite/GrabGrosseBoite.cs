using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabGrosseBoite : MonoBehaviour
{
    public bool boiteGrab;
    public GameObject player;
    private Rigidbody2D rb;
    private Animator anim;
    public CharacterMovement cm;
    public RangeBoite range;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = player.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //boiteGrab = false;
        rb.mass = 500;
        if (range.isAtRange)
        {
            //boiteGrab = false;
            if (Input.GetButton("GrabGamepad"))
            {
                //boiteGrab = true;
                rb.mass = 50;
                anim.SetBool("IsGrosseBoite", true);
            }
            else
            {
                anim.SetBool("IsGrosseBoite", false);
            }
            
        }
        else
        {
            Debug.Log("TA graoose daronne");
            //anim.SetBool("IsGrosseBoite", false);
        }


        /*if (boiteGrab)
        {
            
        }*/
    }
}
