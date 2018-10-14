using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballLaunchScript : MonoBehaviour {

    public GameObject fireBall;
    public float speed;
    public string inputAxis;
    public float cooldownSeconds;
    private bool canFire = true;
    public bool isPlayer;

    //For enemy only
    public GameObject player;
    private Vector3 direction = new Vector3();



    void Update () {
        if(isPlayer)
            checkForLaunchInput(inputAxis);
        else
        {
            aimAtPlayer();
            checkShoot();
        }

	}

    //checks to see if the fire button was pressed and attempts to fire if pressed  
    void checkForLaunchInput(string launchAxis)
    {
        float fireInput = Input.GetAxis(launchAxis);
        if(fireInput != 0)
        {
            attemptToFire(transform.position);
        }
    }

    //checks to see if the player can fire the projectile and fires it if it can
    void attemptToFire(Vector3 shotDirection)
    {
        if (canFire)
            fire(shotDirection);
    }

    //fires the projectile and starts the cooldown period
    void fire(Vector3 shotDirection)
    {
        GameObject toFire = Instantiate(fireBall, transform.position, transform.rotation);
        toFire.GetComponent<Rigidbody>().velocity = Vector3.Normalize(shotDirection) * speed;
        canFire = false;
        Invoke("resetCooldown", cooldownSeconds);
    }

    //resets the cooldown
    void resetCooldown()
    {
        canFire = true;
    }

    //sets the direction of the shot (for enemy only)
    void aimAtPlayer()
    {
        direction = player.transform.position - transform.position;
    }

    //checks if the enemy sees the player and can shoot
    void checkShoot()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, direction, out hit))
        {
            //checks if the hit object was the player (no object between launcher and the player)
            if(hit.collider.CompareTag("Player"))
            {
                attemptToFire(direction);
            }
        }
    }

}


