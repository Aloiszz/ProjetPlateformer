using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ToutLesCharacters : MonoBehaviour
{

    [Header("Animation Curve pour Loupiote")]
    public AnimationCurve curve;
    public List<UnityEngine.Rendering.Universal.Light2D> loupiote;
    private float graph, increment;
    private bool canRunGame = false;
    private bool stopWakeUp;

    [Header("Animation Curve ")] 
    public float timeToWait;
    public AnimationCurve curve2;
    public List<UnityEngine.Rendering.Universal.Light2D> loupiote2;
    private float graph2, increment2;
    private bool canRunGame2 = false;
    private bool stopWakeUp2;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            canRunGame = true;
            StartCoroutine(WaitForLoupiote2());
        }
    }

    private void Update()
    {
        if (canRunGame)
        {
            for (int i = 0; i < loupiote.Count; i++)
            {
                loupiote[i].intensity = 1;
                increment += Time.deltaTime;
                graph = curve.Evaluate(increment);
                loupiote[i].intensity = graph;
            }
        }
        if (canRunGame2)
        {
            for (int i = 0; i < loupiote2.Count; i++)
            {
                loupiote2[i].intensity = 1;
                increment2 += Time.deltaTime;
                graph2 = curve2.Evaluate(increment2);
                loupiote2[i].intensity = graph2;
            }
        }
    }


    IEnumerator WaitForLoupiote2()
    {
        canRunGame2 = false;
        yield return new WaitForSeconds(timeToWait);
        canRunGame2 = true;
    }
}
