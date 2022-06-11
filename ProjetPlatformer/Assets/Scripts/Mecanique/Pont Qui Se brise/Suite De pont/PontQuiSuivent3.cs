using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PontQuiSuivent3 : MonoBehaviour
{
    public TriggerPontQuiSeBrise trigger;

    public Rigidbody2D rb;
    public HingeJoint2D hingeJoint;
    
    public static PontQuiSuivent3 instancePontQuiSuivent3;

    public ParticleSystem particules;
    public GameObject particulesPoint;
    public bool doOnce;
    
    public AudioSource source;
    
    // public GameObject mainCamera;
    //  private Tween tweener;
    private void Awake()
    {
        StartCoroutine(WaitSound());
        doOnce = false;
        if (instancePontQuiSuivent3 == null) instancePontQuiSuivent3 = this;
        
        rb = GetComponent<Rigidbody2D>();
        hingeJoint = GetComponent<HingeJoint2D>();
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        gameObject.GetComponent<PontQuiSuivent3>().enabled = true;
        
        hingeJoint.enabled = false;
        rb.gravityScale = 0;
    }

    private void Update()
    {
        if (trigger.isTriggered == true)
        {
            doOnce = false;
            //  tweener = mainCamera.transform.DOShakePosition(1.5f,5,1,35,false);
            hingeJoint.enabled = true;
            rb.gravityScale = 1;
            rb.simulated = true;
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;
        }
    }
    
    IEnumerator WaitSound()
    {
        source.mute = true;
        yield return new WaitForSeconds(1.5f);
        source.mute = false;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag != "Player" && doOnce == false)
        {
            source.Play();
            doOnce = true;
            Instantiate(particules, particulesPoint.transform.position, Quaternion.identity);
            //particules.Play();
        }
    }
}
