using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class RandomWind : MonoBehaviour
{
    public AreaEffector2D af;
    public float timerCourant;
    public float timeChangeCourant;
    public float angleCourant1;
    public float angleCourant2;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        while (timerCourant < timeChangeCourant)
        {
            af.forceAngle = angleCourant1;
            timerCourant += Time.deltaTime;
        }
       
        if (timerCourant >= timeChangeCourant)
        {
            af.forceAngle = angleCourant2;
            timerCourant = 0;
        }
    }
    
}
