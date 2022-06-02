using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using XInputDotNetPure;

public class DeathZonePontQuiSecroule : MonoBehaviour
{
    public int respawn;
    public Animator anim;
    [SerializeField] CameraZoom Camera;

    public GameObject PontQuiSecroule;
    
    public List<GameObject> listPontQuiSecroule;
    [SerializeField] private List<Vector3> listPontQuiSecroulePos;
    [SerializeField] private List<Quaternion> listPontQuiSecrouleRot;
    
    //public GameObject pontQuiSecrouleGameObject;
    
    private Transform playerSpawn;
    private Animator fadeSystem;
    
    PlayerIndex playerIndex;
    GamePadState state;
    GamePadState prevState;
    
    private int y = 0;
    private int z = 0;
    
    private Vector3 originalPos;
    public Quaternion originalRotationValue; 
    float rotationResetSpeed = 1.0f;

    public TriggerPontQuiSeBrise triggerPont;

    private void Awake()
    {
        playerSpawn = GameObject.FindGameObjectWithTag("PlayerSpawn").transform;
        fadeSystem = GameObject.FindGameObjectWithTag("DeathFade").GetComponent<Animator>();
        
        /*originalPos = new Vector3(PontQuiSecroule.transform.position.x, PontQuiSecroule.transform.position.y, PontQuiSecroule.transform.position.z);
        originalRotationValue = transform.rotation;*/
        
        foreach (GameObject x in listPontQuiSecroule)
        {
            listPontQuiSecroulePos.Add(new Vector3(x.transform.position.x, x.transform.position.y, x.transform.position.z));
            listPontQuiSecrouleRot.Add(x.transform.rotation);
        }

        y = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GamePad.SetVibration(playerIndex, 0, 0);
            triggerPont.tweener.Kill();
            
            Camera.isMoving = false;
            //Destroy(pontQuiSecrouleGameObject);
            
            /*PontQuiSecroule.transform.position = originalPos;
            PontQuiSecroule.transform.rotation = Quaternion.Slerp(transform.rotation, originalRotationValue, Time.time * rotationResetSpeed);*/

            foreach (Vector3 x in listPontQuiSecroulePos)
            {
                listPontQuiSecroule[y].transform.position = x;
                y++;
                if (y == listPontQuiSecroulePos.Count)
                {
                    y = 0;
                }
            }
            
            foreach (Quaternion x in listPontQuiSecrouleRot)
            {
                listPontQuiSecroule[z].transform.rotation = x;
                z++;
                if (z == listPontQuiSecroulePos.Count)
                {
                    z = 0;
                }
            }

            StartCoroutine(ReplacePlayer(collision));
            
            //Instantiate(PontQuiSecroule, PontQuiSecroule.transform.position, quaternion.identity);
            
        }
    }
    private IEnumerator ReplacePlayer(Collider2D collision)
    {
        PontQuiSecroulle.instancePont.rb.simulated = false;
        PontQuiSecroulle.instancePont.hingeJoint.enabled = false;
        PontQuiSecroulle.instancePont.rb.gravityScale = 0;
        
        PontQuiSuivent.instancePontQuiSuivent.rb.simulated = false;
        PontQuiSuivent.instancePontQuiSuivent.hingeJoint.enabled = false;
        PontQuiSuivent.instancePontQuiSuivent.rb.gravityScale = 0;
        
        PontQuiSuivent1.instancePontQuiSuivent1.rb.simulated = false;
        PontQuiSuivent1.instancePontQuiSuivent1.hingeJoint.enabled = false;
        PontQuiSuivent1.instancePontQuiSuivent1.rb.gravityScale = 0;
        
        PontQuiSuivent2.instancePontQuiSuivent2.rb.simulated = false;
        PontQuiSuivent2.instancePontQuiSuivent2.hingeJoint.enabled = false;
        PontQuiSuivent2.instancePontQuiSuivent2.rb.gravityScale = 0;
        
        PontQuiSuivent3.instancePontQuiSuivent3.rb.simulated = false;
        PontQuiSuivent3.instancePontQuiSuivent3.hingeJoint.enabled = false;
        PontQuiSuivent3.instancePontQuiSuivent3.rb.gravityScale = 0;
        
        PontQuisuivent4.instancePontQuiSuivent4.rb.simulated = false;
        PontQuisuivent4.instancePontQuiSuivent4.hingeJoint.enabled = false;
        PontQuisuivent4.instancePontQuiSuivent4.rb.gravityScale = 0;

        DébutPontQuiSecroule.instancePont.rb.simulated = false;
        DébutPontQuiSecroule.instancePont.hingeJoint.enabled = false;
        DébutPontQuiSecroule.instancePont.rb.gravityScale = 0;
        
        fadeSystem.SetTrigger("FadeIn");
        yield return new WaitForSeconds(0.2f);
        
        collision.transform.position = playerSpawn.position;
        Camera.transform.position = new Vector3(playerSpawn.position.x, playerSpawn.position.y, -10);
        
        FeuxDeCamp.instanceFeuxdeCamp.onoff = false;
        FeuxDeCamp.instanceFeuxdeCamp.GoToCamp();
        //FeuxDeCamp.instanceFeuxdeCamp.LeFeuxDeCamp();
        
        CharacterMovement.instance.speed = 0;
        CharacterMovement.instance.canMove = false;
        CharacterMovement.instance.canJump = false;
        
        anim.SetBool("isGrounded", true);
        
        yield return new WaitForSeconds(0.8f);
        CharacterMovement.instance.speed = 11;
        CharacterMovement.instance.canMove = true;
        CharacterMovement.instance.canJump = true;
    }
}
