using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.UI;

public class ShootBow : MonoBehaviour
{


    public float LaunchForce;

    public GameObject Arrow;

    public static ShootBow shootArrowInstance;
    // Start is called before the first frame update
    void Awake()
    {
        if (shootArrowInstance == null) shootArrowInstance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("JumpGamepad"))
        {
            Shoot();
        }
    }


    void Shoot()
    {
        GameObject ArrowIns =  Instantiate(Arrow, transform.position, transform.rotation);

        if (TestBow.ShootBowInstance.isNull == true)
        {
            ArrowIns.GetComponent<Rigidbody2D>().velocity = transform.right * 0;
        }
        else
        {
            ArrowIns.GetComponent<Rigidbody2D>().velocity = transform.right * LaunchForce;
        }
        
    }
}
