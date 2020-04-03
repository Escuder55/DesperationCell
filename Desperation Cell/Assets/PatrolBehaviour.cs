using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;


public class PatrolBehaviour : MonoBehaviour
{
    [Header("WAY POINTS")]
    [SerializeField] Transform[] wayPoints;
    [SerializeField] float minDistance = 0.2f;
    [Header("AGENT")]
    public NavMeshAgent agent;
    public float speedAgent;
    public float speedLookAt= 0.2f;

    int maxWaypoints = 0;
    public int currentIndex = 1;
    float distance;
    
    private void Start()
    {
        maxWaypoints = wayPoints.Length;

        agent.speed = speedAgent;

        GoToWayPoint();
    }

    
    void Update()
    {
        distance = Vector3.Distance(this.transform.position, wayPoints[currentIndex].position);

        if (distance < minDistance)
        {

            GoToNextPoint();
        }

        this.transform.DOLookAt(wayPoints[currentIndex].position, speedLookAt);
    }

    #region GO TO NEXT POINT
    void GoToNextPoint()
    {
        currentIndex++;

        if (currentIndex > maxWaypoints - 1)
        {
            currentIndex = 0;
        }

        GoToWayPoint();
    }
    #endregion

    #region GO TO POINT
    void GoToWayPoint()
    {
        agent.SetDestination(wayPoints[currentIndex].position);
    }
    #endregion
}
