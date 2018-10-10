using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class JackBehavior : MonoBehaviour {


    // How many units left and right it should patrol 
    public int patrolBoundLeft; 
    public int patrolBoundRight;

    private Transform[] points;
    private int destPoint = 0;
    private NavMeshAgent agent;
    // Use this for initialization

    public  void GoToNextPoint()
    {

        agent.destination = points[destPoint].position;

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1) % points.Length;

    }


    void Start () {

        Vector3 leftBound =  (this.transform.position - new Vector3(0, 0 , patrolBoundLeft));
        Vector3 rightBound = (this.transform.position + new Vector3(0, 0, patrolBoundRight));

        GameObject left = new GameObject();
        left.transform.position = leftBound;
        GameObject right = new GameObject();
        right.transform.position = rightBound;


        points = new[]{ left.transform, right.transform }; 



        agent = GetComponent<NavMeshAgent>();

        GoToNextPoint();

	}
	
   

	// Update is called once per frame
	void Update () {

        if (!agent.pathPending && agent.remainingDistance < 0.5f)
            GoToNextPoint();
    }
}
