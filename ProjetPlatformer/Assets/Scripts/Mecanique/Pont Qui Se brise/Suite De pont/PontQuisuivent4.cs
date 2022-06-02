using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PontQuisuivent4 : MonoBehaviour
{
    public TriggerPontQuiSeBrise trigger;
    

    public Rigidbody2D rb;
    public HingeJoint2D hingeJoint;
    
    public static PontQuisuivent4 instancePontQuiSuivent4;
    
    public ParticleSystem particules;
    public GameObject particulesPoint;

    // public GameObject mainCamera;
    //  private Tween tweener;
    private void Awake()
    {
        if (instancePontQuiSuivent4 == null) instancePontQuiSuivent4 = this;
        
        rb = GetComponent<Rigidbody2D>();
        hingeJoint = GetComponent<HingeJoint2D>();
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        gameObject.GetComponent<PontQuisuivent4>().enabled = true;
        
        hingeJoint.enabled = false;
        rb.gravityScale = 0;
    }

    private void Update()
    {
        if (trigger.isTriggered == true)
        {
            //  tweener = mainCamera.transform.DOShakePosition(1.5f,5,1,35,false);
            hingeJoint.enabled = true;
            rb.gravityScale = 1;
            rb.simulated = true;
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;
        }
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag != "Player")
        {
            Instantiate(particules, particulesPoint.transform.position, Quaternion.identity);
            //particules.Play();
        }
    }
}
