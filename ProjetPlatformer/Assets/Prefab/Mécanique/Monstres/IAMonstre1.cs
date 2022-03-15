using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class IAMonstre1 : MonoBehaviour
{

    public AgroMonstre1 agroscript;
    public float speed;
    public Transform target;
    public bool exclamationDone;
    
    void Update()
    {
        if (agroscript.isAgro == true)
        {
            if (exclamationDone == false)
            {
                transform.DOMoveY(transform.position.y + 0.5f, 0.5f).OnComplete(() =>
                    transform.DOMoveY(transform.position.y - 0.5f, 0.2f).OnComplete(() =>
                        exclamationDone = true));
            }
            StartCoroutine(Stopeuhh());
                    transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.position.x, transform.position.y, transform.position.z) , speed*Time.deltaTime);
        }

        if (agroscript.isAgro == false)
        {
            exclamationDone = false;
        }
        
    }

    IEnumerator Stopeuhh()
    {
        yield return new WaitForSeconds(0.2f);
    }

}
