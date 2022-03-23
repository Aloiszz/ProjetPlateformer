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
        if (timerCourant < timeChangeCourant)
        {
            af.forceAngle = angleCourant1;
            af.forceMagnitude = 500;
            timerCourant += Time.deltaTime;
        }
       
        if (timerCourant >= timeChangeCourant)
        {
            af.forceAngle = angleCourant2;
            af.forceMagnitude = 350;
            timerCourant += Time.deltaTime;
        }

        if (timerCourant >= 5.5)
        {
            timerCourant = 0;
        }
    }
    
}
