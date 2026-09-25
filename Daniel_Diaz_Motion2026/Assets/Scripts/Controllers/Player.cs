using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;// list of asteroid transforms
    public Transform enemyTransform;// enemy position
    public GameObject bombPrefab;// bomb prefab reference
    public Transform bombsTransform;// parent transform for bombs

    public Transform playerPost;// player position

    public Vector3 currentVelocity = Vector3.zero;// starting velocity

    public float MaxSpeed; // Max possible speed
    public float MinSpeed; // Min possible speed before setting it to 0

    public float accelerationTime; //Time it takes to accelerate

    public float decelerationTime; // Time it takes to decelerate

    public float currentAcceleration; // Acceleration value

    public float currentDecceleration; // Deceleration value


    private void Start()
    {
        // Calculates the values of acceleration and deceleration 
        currentAcceleration = MaxSpeed / accelerationTime;  
        currentDecceleration = MaxSpeed / decelerationTime;
    }

    void Update()
    {
        DetectAsteroids(1.5f, asteroidTransforms);// calls the detect asteroids function with a max range of 1.5 and the list of asteroid transforms

        PlayerMovement();

        if (Keyboard.current.spaceKey.wasPressedThisFrame)// normalizes a vector and prints it to the console (done in class)
        {
            Debug.Log("Normalized Vector: " + Normalizer(new Vector2(-3, 2)));
        }

        if (Keyboard.current.bKey.wasPressedThisFrame)// spawns a bomb relative to the player position when b is pressed
        {
            SpawnBombAtOffset(transform.up);// calls a bomb in front of the player 
        }
        if (Keyboard.current.tKey.wasPressedThisFrame)// spawns a trail of bombs below the player position when t is pressed
        {
            SpawnBombTrail(0.8f, 5);// calls the trail spawn fuction with a spacing of 0.5 and 5 bombs totalS
        }
        if (Keyboard.current.hKey.wasPressedThisFrame)// spawns a bomb at a random corner when h is pressed
        {
            SpawnBombOnRandomCorner(1f);// calls the random corner spawn function with a certain distance 
        }
        if (Mouse.current.leftButton.wasPressedThisFrame)// warps the player when the left mouse button is pressed
        {
           WarpPlayer(enemyTransform, 0.5f);// calls the warp function and move the player towards the nearest enemy with a ratio betwen 0 and 1 (0.5)
        }
    }

    public static Vector2 Normalizer(Vector2 normalized)// normalizes a vector and prints it to the console (done in class)
    {
        return normalized.normalized;// returns the noramlized vector
    }

    public void SpawnBombAtOffset(Vector3 inOffset)// spawns a bomb at the player position with an offset
    {
        Instantiate(bombPrefab, playerPost.position + (Vector3)inOffset, Quaternion.identity);// instantiates a bomb relative to the player position with an offset
    }

    public void SpawnBombTrail(float inBombSpacing, int inNumberOfBombs) // spawns a trail of bombs with a specified spacing and number of bombs
    {
        for (int i = 1; i <= inNumberOfBombs; i++) // for loop for spawning bombs 
        {
            Instantiate(bombPrefab, playerPost.position + new Vector3(0, inBombSpacing * -i, 0), Quaternion.identity); // spawns the bombs with the correct spacing
        }

    }

    public void SpawnBombOnRandomCorner(float inDistance)// spawns a bomb at a random corner 
    {
        List<Vector2> corners = new List<Vector2> 
        { new Vector2(-1f, 1f), new Vector2(1f, 1f), new Vector2(1f, -1f), new Vector2(-1f, -1f) }; // creates a list of the four corners>

        int randomIndex = Random.Range(0, corners.Count); // generates a random index to select a corner
        Vector2 randomCorner = corners[randomIndex] * inDistance; // selects a random corner and scales it by the distance
        Instantiate(bombPrefab, playerPost.position + (Vector3)randomCorner, Quaternion.identity); // spawns the bomb at the random corner 
    }

    public void WarpPlayer(Transform target, float ratio)// warps the player towards a target position based on a ratio
    {
        Vector3 startingPoint = playerPost.position;// stores the starting position of the player
        Vector3 finalPoint = target.position;// stores the enemy position

        playerPost.position = Vector3.Lerp(startingPoint, finalPoint, ratio); // moves the player towards the enemy position based on the ratio
    }

    public void DetectAsteroids(float inMaxRange, List<Transform> inAsteroids)
    {
        foreach (Transform asteroid in inAsteroids)// iterates through the list of asteroids 
        {
            if (Vector3.Distance(playerPost.position, asteroid.position) < inMaxRange)// if the distance between the player and the asteroid is less than the max range
            {
                Vector2 normalizedDirection = Normalizer(asteroid.position - playerPost.position) * 2.5f;// normalizes the vector between the player and the asteroid and multiples it by 2.5 

                Debug.DrawLine(playerPost.position, playerPost.position + (Vector3)normalizedDirection, Color.green);// draws a green line to the asteroid if it is within range
            }
        }
    }
    void PlayerMovement()// controls the player input over the ship

    {
        Vector3 accelerationDirection = Vector3.zero; // = 0 when no player input is detected

        if (Keyboard.current.leftArrowKey.isPressed)
        {
            accelerationDirection += Vector3.left;
        }
        if (Keyboard.current.rightArrowKey.isPressed)
        {
            accelerationDirection += Vector3.right;
        }
        if (Keyboard.current.upArrowKey.isPressed)
        {
            accelerationDirection += Vector3.up;
        }
        if (Keyboard.current.downArrowKey.isPressed)
        {
            accelerationDirection += Vector3.down;
        }

        //ACCELERATION DIRECTION REPRESENTS THE DIRECTION WE ARE ACCELERATING
        //WE NORMALIZE IT 
        //AND THEN SET THE AMOUNT TO ACCELERATE BY:
        currentVelocity += accelerationDirection.normalized * currentAcceleration * Time.deltaTime;

        // if no input is being given
        if (!Keyboard.current.leftArrowKey.isPressed && !Keyboard.current.rightArrowKey.isPressed && !Keyboard.current.upArrowKey.isPressed && !Keyboard.current.downArrowKey.isPressed) 
        {
            currentVelocity -= currentVelocity * currentDecceleration * Time.deltaTime;// velocity reduces over time

            if (currentVelocity.magnitude <= MinSpeed)
            {
                currentVelocity = Vector3.zero;// sets the velocity to 0 so it doesn't go crazy with decimals
            }
        }

        if (currentVelocity.magnitude > MaxSpeed)
        {
            currentVelocity = currentVelocity.normalized * MaxSpeed;// equalizes the velocity to the max velocity
        }

        transform.position += currentVelocity * Time.deltaTime;// changes the position of the ship over time based on the velocity

    }

}
