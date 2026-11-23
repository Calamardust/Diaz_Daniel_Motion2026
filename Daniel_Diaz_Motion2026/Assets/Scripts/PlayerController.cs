using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D playerRB;

    public float maxSpeed;

    public float accelerationTime;
    private float acceleration;

    public float apexHeight;
    public float apexTime;
    float initialJumpVelocity;
    float gravity;

    Vector3 currentVelocity;

    public enum FacingDirection
    {
        left, right
    }

    // Start is called before the first frame update
    void Start()
    {
        acceleration = maxSpeed / accelerationTime;

        gravity = -2 * apexHeight / Mathf.Pow(apexTime, 2);
        initialJumpVelocity = 2 * apexHeight / apexTime;
    }

    // Update is called once per frame
    void Update()
    {
        
        //The input from the player needs to be determined and then passed in the to the MovementUpdate which should
        //manage the actual movement of the character.
        Vector2 playerInput = new Vector2();

        if (Keyboard.current.dKey.isPressed) // use booleans to be able to keep in updtae
        {
            playerInput.x += 1f;
        }
        if (Keyboard.current.aKey.isPressed)
        {
            playerInput.x -= 1f;
        }

        MovementUpdate(playerInput); //change to fixedUpdate 
    }

    void FixedUpdate()
    {
        //This is where you would want to put any code that needs to be run in the physics update loop.
    }

    private void MovementUpdate(Vector2 playerInput)
    {
        

        Vector2 newVelocity = playerRB.linearVelocity;
        if (playerInput.x != 0)
        {
            //accelerate
            newVelocity += playerInput * acceleration * Time.deltaTime;
        }
        else
        {
            //decelerate
            newVelocity -= newVelocity * acceleration * Time.deltaTime;
        }
        newVelocity.y += gravity * Time.deltaTime;
        playerRB.linearVelocity = newVelocity;


        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            //jump 
            playerRB.linearVelocity = new Vector2(playerRB.linearVelocity.x, initialJumpVelocity);
        }
    }

   

    public bool IsWalking()
    {
        return true;
    }
    public bool IsGrounded()
    {
        return true;
    }

    public FacingDirection GetFacingDirection()
    {
        return FacingDirection.left;
    }
}
