using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class JackBehavior : MonoBehaviour {


    // How many units left and right it should patrol 
  

    public List<WayPoint> _patrolPoints;
    private int _currentPatrolIndex = 0;
    private NavMeshAgent agent;
    // Use this for initialization


    private int health = 10;

    void Start () {

    
        
        agent = this.GetComponent<NavMeshAgent>();


        _currentPatrolIndex = 0;
        SetDestination();

    }

    private void SetDestination()
    {
        if (_patrolPoints != null)
        {
            Vector3 targetVector = _patrolPoints[_currentPatrolIndex].transform.position;
            agent.destination = targetVector;
         
        }
    }
    private void ChangePatrolPoint()
    {
       
        _currentPatrolIndex = (_currentPatrolIndex + 1) % _patrolPoints.Count;
     
    }

    // Update is called once per frame
    void Update () {

        if (!agent.pathPending && agent.remainingDistance <= 1.0f) 
        {

            ChangePatrolPoint();
            SetDestination();
        }
            
    }
}
