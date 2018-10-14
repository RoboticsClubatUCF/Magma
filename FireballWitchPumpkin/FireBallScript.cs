using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallScript : MonoBehaviour {

    public string wallBoundaryTag;
    public string enemyTag;

    //detects collision type
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag(wallBoundaryTag)) //projectile hit a wall or a boundary
        {
            Destroy(gameObject);
        }
        else if (collision.collider.CompareTag(enemyTag))
        {
            handleEnemyCollision(collision.collider.gameObject);
        }
    }

    //handles the collision if collided with an enemy
    void handleEnemyCollision(GameObject enemy)
    {
        //INSERT ENEMY COLLISION CODE
    }
}
