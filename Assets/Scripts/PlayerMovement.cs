using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed at which the player moves
    public float acceleration = 10f; // Acceleration when starting or changing movement direction
    public float deceleration = 10f; // Deceleration when releasing movement keys

    private Rigidbody2D rb;
    private Vector2 movementDirection;
    private Vector2 currentVelocity;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Get input for horizontal (left/right) movement
        float horizontalInput = Input.GetAxis("Horizontal");
        // Get input for vertical (up/down) movement
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate movement direction
        movementDirection = new Vector2(horizontalInput, verticalInput).normalized;
    }

    private void FixedUpdate()
    {
        // Calculate the desired velocity based on movement direction and speed
        Vector2 targetVelocity = movementDirection * moveSpeed;

        // Apply acceleration to reach the target velocity
        currentVelocity = Vector2.MoveTowards(currentVelocity, targetVelocity, acceleration * Time.fixedDeltaTime);

        // Move the player using Rigidbody2D
        rb.velocity = currentVelocity;

        // Apply deceleration when no movement keys are pressed
        if (movementDirection == Vector2.zero)
        {
            currentVelocity = Vector2.MoveTowards(currentVelocity, Vector2.zero, deceleration * Time.fixedDeltaTime);
        }
    }
}




//Need to refine player movement without having the Rigidbody2D interfere with the player's orbs. 
//Implementation of the follow camera is next.
//Attempting a walking animation and with a smooth transition before and after the idle animation is after that.
//Lastly, note that the orb remains in the position that it was initially isntantiated and does not travel with the player. 
// ^^ We may want to fix that in later iterations, but test it out for now and see how it plays the way it is. 