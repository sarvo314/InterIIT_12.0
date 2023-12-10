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
    [SerializeField]
    private Transform groundCheck;
    [SerializeField]
    private float groundDistance;
    //ground layer should be marked here
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private bool cheatOff;
    public static event EventHandler PlayerDied;

    private void Awake()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        GameInput.JumpPerformed += HandleJumping;
    }

    // To check whether on ground
    // private void OnCollisionEnter(Collision collision)
    // {
    //     if(collision.gameObject.CompareTag("Ground"))
    //         isGrounded = true;
    // }

    public bool CanJump()
    {
        return isGrounded;
    }
    

    

    private void HandleMovement()
    {
        Vector2 inputVector = GameInput.Instance.GetMovementVectorNormalized();
        inputVector.y = 0; 
        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);

        // For animation
        isWalking = moveDir != Vector3.zero;

        // For interaction
        float moveDistance = playerSpeed * Time.deltaTime;
        float playerRadius = 0.9f;
        float playerHeight = 2f;
        // bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDir, moveDistance);
        // if (canMove)
        {
            transform.position += moveDir * Time.deltaTime * playerSpeed;
        }
        // Smooth rotation
        float rotateSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed);
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
        return isWalking;
    }

    public void Die()
    {
        if (cheatOff)
        {
            PlayerDied?.Invoke(this, EventArgs.Empty);
            Debug.Log("Player died");
        }
            
    }
    
    private void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.transform.position, groundDistance, groundMask);
        HandleMovement();
    }
}

