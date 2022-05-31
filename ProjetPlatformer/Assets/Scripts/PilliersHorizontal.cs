using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using XInputDotNetPure;

public class PilliersHorizontal : MonoBehaviour
{
    
    [SerializeField] private List<Transform> waypoints;
    [SerializeField] private float moveSpeed = 5f;
    private Tween tweener;
    public float moveSpeedLent;
    public float moveSpeedRapide;
    private int _currentWaypoint;
    public bool lentRapide;
    public GameObject camera;
    public FermetureSalle3 trigger;
    public Vector3 saveScale;
    public GameObject deathzone;
    public GameObject playerHolder;

    private void OnTriggerEnter2D(Collider2D other)
    {
        /*if (!other.CompareTag("Player")) return;
        other.transform.parent = playerHolder.transform;
        //saveScale.x = other.transform.localScale.x;
        //saveScale.y = other.transform.localScale.y;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        other.transform.parent = null;
        //other.transform.localScale = Vector3.one;*/
    }
    
    
    

// Start is called before the first frame update
    private void Start()
    {
        if (waypoints.Count <= 0) return;
        _currentWaypoint = 0;
    }

// Update is called once per frame
    private void FixedUpdate()
    {
        HandleMovement();
    }

    
    
    private void HandleMovement()
    {
        if (trigger.activationFrappe2)
        {
            transform.position = Vector3.MoveTowards(transform.position, waypoints[_currentWaypoint].transform.position,
                (moveSpeed * Time.deltaTime));

            if (Vector3.Distance(waypoints[_currentWaypoint].transform.position, transform.position) <= 0)
            {
                lentRapide = !lentRapide;
                _currentWaypoint++;

                if (lentRapide)
                {
                    tweener = camera.transform.DOShakePosition(0.1f,1,1,10,false, false);
                }
            }

            if (lentRapide)
            {
                moveSpeed = moveSpeedLent;
                //deathzone.SetActive(true);
            }
            else
            {
                moveSpeed = moveSpeedRapide;
                //deathzone.SetActive(false);
            }
        }

        
        if (_currentWaypoint != waypoints.Count) return;
        waypoints.Reverse();
        _currentWaypoint = 0;
        lentRapide = !lentRapide;
        }
}

