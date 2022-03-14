using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAMonstre1 : MonoBehaviour
{

    public AgroMonstre1 agroscript;
    public float speed;
    public Transform target;
    
    void Update()
    {
        if (agroscript.isAgro == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.position.x, transform.position.y, transform.position.z) , speed*Time.deltaTime);
        }
    }
}
