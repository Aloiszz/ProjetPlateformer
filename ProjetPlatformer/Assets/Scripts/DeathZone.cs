using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DeathZone : MonoBehaviour
{
    public int respawn;
    public Animator anim;
    [SerializeField] CameraZoom Camera;
    
    private Transform playerSpawn;
    private Animator fadeSystem;

    private void Awake()
    {
        playerSpawn = GameObject.FindGameObjectWithTag("PlayerSpawn").transform;
        fadeSystem = GameObject.FindGameObjectWithTag("DeathFade").GetComponent<Animator>();
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Camera.isMoving = false;
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(ReplacePlayer(collision));
        }
    }
    private IEnumerator ReplacePlayer(Collider2D collision)
    {
        fadeSystem.SetTrigger("FadeIn");
        yield return new WaitForSeconds(0.2f);
        anim.SetBool("isGrounded", true);
        collision.transform.position = playerSpawn.position;
        //FeuxDeCamp.instanceFeuxdeCamp.LeFeuxDeCamp();
    }
}

