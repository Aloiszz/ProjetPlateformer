using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;

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
    
    private int y = 0;
    private int z = 0;
    
    private Vector3 originalPos;
    public Quaternion originalRotationValue; 
    float rotationResetSpeed = 1.0f;

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

        collision.transform.position = playerSpawn.position;
        FeuxDeCamp.instanceFeuxdeCamp.onoff = false;
        FeuxDeCamp.instanceFeuxdeCamp.LeFeuxDeCampDeath();
        fadeSystem.SetTrigger("FadeIn");
        
        
        yield return new WaitForSeconds(0.2f);
        anim.SetBool("isGrounded", true);
    }
}
