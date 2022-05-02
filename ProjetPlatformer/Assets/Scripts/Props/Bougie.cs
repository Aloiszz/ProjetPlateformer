using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Bougie : MonoBehaviour
{
    public bool isInList;
    public float time;
    
    [Header("Animation Curve")]
    public AnimationCurve CourbeDeFlamme;
    public Light2D Flamme;
    private float graph, increment;
    private bool canRunGame;
    

    void Update()
    {
        if (isInList)
        {
            Flamme.intensity = 0;
        }
        else
        {
            Flamme.intensity = 1;
        }
        //canRunGame = true;
        if (canRunGame)
        {
            Flamme.intensity = 1;
            increment += Time.deltaTime;
            graph = CourbeDeFlamme.Evaluate(increment);
            Flamme.intensity = graph;
        }
    }
    public void AllumeBougie()
    {
        if (BougieTrigger.instance.isTriggered)
        {
            Debug.Log("Allime");
            StartCoroutine(TimeToLight());
        }
    }

    IEnumerator TimeToLight()
    {
        yield return new WaitForSeconds(time);
        canRunGame = true;
    }
}
