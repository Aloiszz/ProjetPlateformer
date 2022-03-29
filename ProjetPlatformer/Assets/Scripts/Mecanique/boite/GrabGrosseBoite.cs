using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabGrosseBoite : MonoBehaviour
{
    public bool boiteGrab;
    public GameObject player;
    private Rigidbody2D rb;
    public CharacterMovement cm;
    public RangeBoite range;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        boiteGrab = false;
        rb.mass = 500;
        if (range.isAtRange == true)
        {
            boiteGrab = false;
            if (Input.GetButton("GrabGamepad"))
            {
                boiteGrab = true;
                // animation 
            }
        }
        if (boiteGrab == true)
        {
            Debug.Log("je te porte");
            rb.mass = 50;
        }
    }
}
