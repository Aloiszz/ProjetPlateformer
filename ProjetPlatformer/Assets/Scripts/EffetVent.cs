using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class EffetVent : MonoBehaviour
{
    public GameObject camera;

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(AttenteVent());
    }

    IEnumerator AttenteVent()
    {
        GetComponent<Animator>().Play("AnimationVent",-1,0);
        transform.DOMove(new Vector3(camera.transform.position.x - 10,transform.position.y+5,transform.position.z), 3);
        yield return new WaitForSeconds(3f); // de la durée de l'animation
        GetComponent<Material>().DOFade(0,0.5f);
        yield return new WaitForSeconds(4f);
        transform.position = camera.transform.position - new Vector3(10, -5,camera.transform.position.z);
        GetComponent<Material>().DOFade(255,0.5f);
    }
}
