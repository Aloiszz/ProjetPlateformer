using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
 

public class tutoPlanage : MonoBehaviour
{
   // public GameObject textTouche;
   // private SpriteRenderer sr;
    public Color color;
    private float timeToFade = 1.0f;
    public AnimationCurve animationCurveUp;
    public AnimationCurve animationCurveDown;
    public float deltaTimeCurve;

    // Start is called before the first frame update
    void Start()
    {
      //  sr = textTouche.GetComponent<SpriteRenderer>();
      //  sr.color = color;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale > 0)
        {
            deltaTimeCurve = 0;
            deltaTimeCurve -= Time.deltaTime; 
        }
        else
        {
            deltaTimeCurve = 0;
            deltaTimeCurve += Time.deltaTime;
        }
        if (Input.GetButtonDown("DoubleJumpGamepad") && (Time.timeScale == 0))
        {
           // StartCoroutine(ScaleTime(0, 1.0f, 0.5f));
            color.a = Mathf.Lerp(255, 0, 1);
            Time.timeScale = animationCurveDown.Evaluate((deltaTimeCurve));
        }

        //sr.color = color;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        color.a = Mathf.Lerp(0, 255, 1);
        Time.timeScale = animationCurveUp.Evaluate(deltaTimeCurve);
        // StartCoroutine(ScaleTime(1.0f, 0.0f, 0.5f));
    }
    
    
    /*IEnumerator ScaleTime(float start, float end, float time)     //not in Start or Update
    {
        float lastTime = Time.realtimeSinceStartup;
        float timer = 0.0f;
          
        while (timer < time)
        {
            Time.timeScale = Mathf.Lerp (start, end, timer / time);
            timer += (Time.realtimeSinceStartup - lastTime);
            lastTime = Time.realtimeSinceStartup;
            yield return null;
        }
          
        Time.timeScale = end;
    }*/
    
}
