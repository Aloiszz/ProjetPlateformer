using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStayPlateforme : MonoBehaviour
{
    public GameObject target;
    void OnTriggerStay2D(Collider2D other){
             
        if(other.gameObject.tag == "Player"){
            other.transform.parent = target.transform;
            //other.transform.position = target.transform.position;
            //other.transform.localScale = new Vector3(1,1,1);
            other.transform.rotation = new Quaternion(0,0,0,0);
        }
    }
 
    void OnTriggerExit2D(Collider2D other){
        if(other.gameObject.tag == "Player"){
            //other.transform.parent = null;
             
        }
    }    
    
}
