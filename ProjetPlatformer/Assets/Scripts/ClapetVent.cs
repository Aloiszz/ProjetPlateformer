using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using DG.Tweening;

public class ClapetVent : MonoBehaviour
{
    [SerializeField] private List<Transform> waypoints;
    public float moveSpeed = 5f;
    private int _currentWaypoint;
    
    public static ClapetVent instance;
    
    private void Awake()
    {
        if (instance == null) instance = this;
    }
    private void Start()
    {
        if (waypoints.Count <= 0) return;
        _currentWaypoint = 0;
    }
    private void FixedUpdate()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        transform.position = Vector3.MoveTowards(transform.position, waypoints[_currentWaypoint].transform.position,
            (moveSpeed * Time.deltaTime));

        if (Vector3.Distance(waypoints[_currentWaypoint].transform.position, transform.position) <= 0)
        {
           
            _currentWaypoint++;
        }
        
        if (_currentWaypoint != waypoints.Count) return;
        waypoints.Reverse();
        _currentWaypoint = 0;
    }
}
