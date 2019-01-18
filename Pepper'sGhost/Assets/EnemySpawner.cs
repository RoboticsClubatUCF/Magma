using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public float spawnTime = 1;
    float timer = 0;
    //private Component[] spawnLoc;
    public GameObject Target;
    public GameObject enemy;
    public float targetUpdateTime = 0.1f; 

	// Use this for initialization
	void Start () {
		
        


    }

    void spawnEnemy()
    {

        int loc = (int)Random.Range(0, (this.gameObject.transform.childCount -.01f) );

        Vector3 spawn = this.gameObject.transform.GetChild(loc).transform.localPosition;

        GameObject tempEnemy = Instantiate(enemy, spawn, Quaternion.identity, this.transform.parent);

        tempEnemy.GetComponent<ChasePlayer>().chaseTarget = Target;

    }
	
	// Update is called once per frame
	void Update () {

        timer += Time.deltaTime; 

        if(timer >= spawnTime)
        {

            spawnEnemy();
            timer = 0;

        }

	}
}
