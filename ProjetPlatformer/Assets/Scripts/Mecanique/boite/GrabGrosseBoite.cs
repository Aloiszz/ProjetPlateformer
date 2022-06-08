using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

public class GrabGrosseBoite : MonoBehaviour
{
    PlayerIndex playerIndex;
    GamePadState state;
    GamePadState prevState;
    
    public bool boiteGrab;
    public GameObject player;
    private Rigidbody2D rb;
    private Animator anim;
    public CharacterMovement cm;
    public RangeBoite range;

    public AudioSource AudioData;
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
        rb.mass = 800;
        if (range.isAtRange)
        {
            
            //boiteGrab = false;
            if (Input.GetButton("GrabGamepad"))
            {
                AudioData.Play();
                //boiteGrab = true;
                rb.mass = 80;
                anim.SetBool("IsGrosseBoite", true);
                StartCoroutine(vibration());
            }
            else
            {
                anim.SetBool("IsGrosseBoite", false);
            }
            
        }
        else
        {
            //anim.SetBool("IsGrosseBoite", false);
        }


        /*if (boiteGrab)
        {
            
        }*/
    }

    IEnumerator vibration()
    {
        GamePad.SetVibration(playerIndex, 0.1f, 0.1f);
        yield return new WaitForSeconds(2);
        GamePad.SetVibration(playerIndex, 0, 0);
    }
}
