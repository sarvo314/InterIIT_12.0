using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem;
using UnityEngine.Video;

public class Player : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 5f;
    [SerializeField] private float jumpForce = 20f;
    private Rigidbody playerRb;
    public static bool isGrounded;
    private bool isWalking;
    [SerializeField] private Transform groundCheck;

    [SerializeField] private float groundDistance;

    //ground layer should be marked here
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private bool cheatOff;
    [SerializeField] private bool allowOnly2DMotion;
    [SerializeField] private float sweepDistanceMultiplier;
    [SerializeField] private GameInput gameInput;
    
    private bool onPlatform;
    [SerializeField] private float offsetAboveGround;
    public static event EventHandler PlayerDied;

    private void Awake()
    {
        // allowOnly2DMotion = true;
    }

    private void Start()
    {
        onPlatform = false;
        gameInput.JumpPerformed += HandleJumping;
        playerRb = GetComponent<Rigidbody>();
    }

    public bool CanJump()
    {
        return isGrounded;
    }


    private void HandleMovement()
    {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();
        if (allowOnly2DMotion)
        {
            inputVector.y = 0;
        }

        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);
        // Debug.Log("move dir is " + moveDir);
        // For animation
        isWalking = moveDir != Vector3.zero;
        if (moveDir != Vector3.zero)
        {
            GameManager.isGameStarted = true;
        }

        // For interaction
        float moveDistance = playerSpeed * Time.fixedDeltaTime;
        float playerRadius = 0.9f;
        float playerHeight = 2f;
        // bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDir, moveDistance);
        // if (canMove)
        // {
        // transform.position += moveDir * Time.deltaTime * playerSpeed;
        // playerRb.MovePosition(transform.position + moveDir * Time.deltaTime * playerSpeed);

        // }

        // bool isColliding = playerRb.SweepTest(moveDir, out hit, moveDistance * sweepDistanceMultiplier);
        //
        // if (!isColliding)
        {
            // Perform the movement if no collision is detected
            // playerRb.MovePosition(transform.position + moveDir * moveDistance);
        }
        // else
        {
            // If there's a collision, adjust the movement
            // Vector3 newMoveDir = moveDir - hit.normal * Vector3.Dot(moveDir, hit.normal);
            // playerRb.MovePosition(transform.position + newMoveDir * moveDistance);
        }
        // RaycastHit hit;
        // bool isColliding = Physics.Raycast(groundCheck.transform.position + 0.2f * Vector3.up, moveDir, out hit,
            // moveDistance);

        // if (!isColliding)
        if(!onPlatform)
        {
            playerRb.MovePosition(transform.position + moveDir * moveDistance);
        }
        else
        {
            transform.position += moveDir * Time.deltaTime * playerSpeed;
        }
        // e
        // lse
        {
            // Calculate the slide direction
            // Vector3 normal = hit.normal;
            // Vector3 slideDir = Vector3.ProjectOnPlane(moveDir, normal).normalized;

            // Calculate the slide distance
            // float remainingDistance = moveDistance - hit.distance;
            // Vector3 adjustedMove = slideDir * remainingDistance;

            // playerRb.MovePosition(transform.position + adjustedMove);
        }

        // Smooth rotation
        float rotateSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.fixedDeltaTime * rotateSpeed);
    }

    private void HandleJumping(object sender, EventArgs eventArgs)
    {
        if (isGrounded)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    // public for PlayerAnimator to access
    public bool IsWalking()
    {
        // return playerRb.velocity != Vector3.zero; 
        return isWalking;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("MovingPlatform"))
        {
            onPlatform = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("MovingPlatform"))
        {
            onPlatform = false;
        }
    }

    public void Die()
    {
        if (cheatOff)
        {
            PlayerDied?.Invoke(this, EventArgs.Empty);
            Debug.Log("Player died");
        }
    }
    // private void OnCollisionStay(Collision collision)
    // {
    //     // Check if the collision is with the ground
    //     if (collision.gameObject.tag == "Ground")
    //     {
    //         // Calculate the position where the player should be placed above the ground
    //         Vector3 newPosition = collision.contacts[0].point + (collision.contacts[0].normal * offsetAboveGround);
    //         
    //         // Set the player's position above the ground
    //         transform.position = newPosition;
    //     }
    // }
    private void FixedUpdate()
    {
        isGrounded = Physics.CheckSphere(groundCheck.transform.position, groundDistance, groundMask);
        HandleMovement();
    }
}