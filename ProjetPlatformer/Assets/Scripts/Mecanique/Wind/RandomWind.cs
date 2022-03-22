using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomWind : MonoBehaviour
{
    public AreaEffector2D af;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(hautBas());
    }

    IEnumerator hautBas()
    {
        af.forceAngle = Random.Range(250, 310);
        yield return new WaitForSeconds(3);
    }
}
