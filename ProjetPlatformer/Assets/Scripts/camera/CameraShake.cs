using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    
    public IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 originalPosition = transform.localPosition;

        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            Debug.Log("là");
            float x = Random.Range(-0.1f,  0.1f) * magnitude;
            float y = Random.Range(- 0.1f,  0.1f) * magnitude;

            transform.position = new Vector3(transform.position.x + x, transform.position.y + y, originalPosition.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originalPosition;
    }




  public void Shake()
  {
      
  }

}
