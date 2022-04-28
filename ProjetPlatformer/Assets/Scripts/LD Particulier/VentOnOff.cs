using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentOnOff : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isVisible;
    public GameObject particulesVent;

    private SpriteRenderer renderer;
    private Collider2D coll;
    

    private void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
        coll = GetComponent<Collider2D>();
        
        if (isVisible == false)
        {
            renderer.enabled = false;
            coll.enabled = false;
            particulesVent.SetActive(false);
        }
        else
        {
            renderer.enabled = true;
            coll.enabled = true;
            particulesVent.SetActive(true);
        }
    }
    
    private void Update()
    {
        if (CharacterMovement.instance.isJumpingSingle == true)
        {
            if(isVisible)
            {
                isVisible = false;
                particulesVent.SetActive(false);
                //gameObject.transform.DOScale(new Vector3(0, 0, 0), 0.1f);
                //renderer.enabled = false;
                coll.enabled = false;
            }
            else
            {
                isVisible = true;
                particulesVent.SetActive(true);
                //gameObject.transform.DOScale(new Vector3(1, 1, 0), 0.1f);
                renderer.enabled = true;
                coll.enabled = true;
            }
        }
    }
}
