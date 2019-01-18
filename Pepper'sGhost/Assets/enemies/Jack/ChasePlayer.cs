using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChasePlayer : MonoBehaviour {


    // How many units left and right it should patrol 


    //  public List<WayPoint> _patrolPoints;
    //   private int _currentPatrolIndex = 0;

   

    [HideInInspector]
    public GameObject chaseTarget;
    [HideInInspector]
    public float targetUpdate = 0.1f;
    public float targetAngle = 60;
    
    private NavMeshAgent agent;
    // Use this for initialization

    void Start () {
           
        agent = this.GetComponent<NavMeshAgent>();

    }

    private void OnCollisionEnter(Collision collision)
    {

        GameObject hit = collision.gameObject;

       if( hit.tag == "Player")
        {
            Debug.Log("hit");
            Vector3 colAngle = hit.transform.position - this.transform.position;

            if ( colAngle.y > .7)
            {

                Destroy(this.gameObject);

            }
            else
            {
                //hurt player
            }



        }

    }
    // Update is called once per frame
    private float timer = 0.0f;

    void Update () {


        timer += Time.deltaTime;
        if (timer >= targetUpdate)
        {
            agent.destination = chaseTarget.transform.position;
            timer = 0.0f;
        }
        
        
    }

 
}
