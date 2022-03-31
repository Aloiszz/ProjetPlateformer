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
    public ParticleSystem particulesVent;
    
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timerCourant < timeChangeCourant)
        {
            particulesVent.transform.localRotation = new Quaternion(0,0,0,0);
            af.forceAngle = angleCourant1;
          //  af.forceAngle = Mathf.Lerp(af.forceAngle, angleCourant1, 1/timeChangeCourant);
            af.forceMagnitude = 500;
            timerCourant += Time.deltaTime;
        }
       
        if (timerCourant >= timeChangeCourant)
        {
            particulesVent.transform.localRotation = new Quaternion(-180,0,0,0);
            af.forceAngle = angleCourant2;
          // af.forceAngle = Mathf.Lerp(af.forceAngle, angleCourant2, 1/timeChangeCourant);
            af.forceMagnitude = 350;
            timerCourant += Time.deltaTime;
        }

        if (timerCourant >= 5.5)
        {
            timerCourant = 0;
        }
    }
    
}
