using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ClapetVent : MonoBehaviour
{

    public float speed;
    public float timer;
    public float distanceMax;
    public WindArea wind;
    
 

    // Update is called once per frame
    /*void Update()
    {
        StartCoroutine(MouvementRégulier());
        
        if
    }


    private IEnumerator MouvementRégulier()
    {
        timer += Time.deltaTime;
        if (timer <= distanceMax)
        {
        //transform.position = Vector3.MoveTowards(transform.position, transform.position + Vector3.up,
            //speed * Time.deltaTime);
        transform.DOMove(transform.position + new Vector3(0,distanceMax,0), speed, false).OnComplete((() => timer -= distanceMax));
        }
        yield return new WaitForSeconds(wind.timeWaitForWind);
        
        //transform.position = Vector3.MoveTowards(transform.position, transform.position - Vector3.up,
        //    speed * Time.deltaTime);
        if (timer <= distanceMax)
        {
        transform.DOMove(transform.position + new Vector3(0,distanceMax,0), speed, false);
        }
    }*/
    
    
    
    [SerializeField] private List<Transform> waypoints;
    [SerializeField] private float moveSpeed = 5f;
    private int _currentWaypoint;

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
