using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApparitionShaderDeau : MonoBehaviour
{
    public List<GameObject> ShaderEau;
    private void Awake()
    {
        StartCoroutine(WaitForShader());
    }

    IEnumerator WaitForShader()
    {
        yield return new WaitForSeconds(2f);
        
        foreach (var VARIABLE in ShaderEau)
        {
            VARIABLE.SetActive(true);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
