using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using XInputDotNetPure;

public class PilierFrappant : MonoBehaviour
{
      
    [SerializeField] private List<Transform> waypoints;
    [SerializeField] private float moveSpeed = 5f;
    private Tween tweener;
    public float moveSpeedLent;
    public float moveSpeedRapide;
    private int _currentWaypoint;
    public bool lentRapide;
    public GameObject camera;
    public FermetureSalle2 trigger;
    public GameObject deathZone;

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
        if (trigger.activationFrappe)
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
                StartCoroutine(WaitUnactive());
            }
            else
            {
                moveSpeed = moveSpeedRapide;
                deathZone.SetActive(true);
            }

            IEnumerator WaitUnactive()
            {
                yield return new WaitForSeconds(0.5f);
                deathZone.SetActive(false);
            }
        
            if (_currentWaypoint != waypoints.Count) return;
            waypoints.Reverse();
            _currentWaypoint = 0;
            lentRapide = !lentRapide;
        }
    }
}
