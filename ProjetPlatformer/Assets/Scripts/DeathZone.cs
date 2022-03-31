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
        if (collision.CompareTag("Player"))
        {
            Camera.isMoving = false;
            StartCoroutine(ReplacePlayer(collision));
        }
    }
    private IEnumerator ReplacePlayer(Collider2D collision)
    {
        collision.transform.position = playerSpawn.position;
        FeuxDeCamp.instanceFeuxdeCamp.onoff = false;
        FeuxDeCamp.instanceFeuxdeCamp.LeFeuxDeCampDeath();
        fadeSystem.SetTrigger("FadeIn");
        yield return new WaitForSeconds(0.2f);
        anim.SetBool("isGrounded", true);
    }
}

