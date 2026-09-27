using System.Collections;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;
public class Enemy : MonoBehaviour
{
    public Transform playerShip; // Player Ship position
    float MinRange = 5.0f; // Range Value

    Vector3 velocity = Vector3.zero; // Velocity value

    float acceleration = 1.5f; // Acceleration value
    float decceleration = 1.5f; // Decceleration Value

    private void Update()
    {
        EnemyMovement();
    }
    public void EnemyMovement() // Makes the enemy move away from the player
    {
        Vector3 playerDirection = (playerShip.position - transform.position).normalized; // Player direction relative to the enemy

        if (Vector3.Distance(playerShip.position, transform.position) < MinRange) // Makes the enemy move away if the player is between the minimum range
        {
            velocity += -playerDirection * acceleration * Time.deltaTime;
        }
        else
        {
            velocity -= velocity * decceleration * Time.deltaTime; // Deccelerates the enemy when player is not inside the minimum range
        }

        transform.position += velocity * Time.deltaTime; // Changes the position of the enemy based on the velocity
    }

}
