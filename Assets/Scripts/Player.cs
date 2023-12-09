using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 5f;
    [SerializeField] private float jumpForce = 20f;
    private Rigidbody playerRb;
    public static bool isGrounded;
    private bool isWalking;
    [SerializeField]
    private Transform groundCheck;
    private PlayerInputActions playerMovement;
    [SerializeField]
    private float groundDistance;
    //ground layer should be marked here
    [SerializeField] private LayerMask groundMask;

    private void Awake()
    {
        playerMovement = new PlayerInputActions();
        playerMovement.Player.Enable();
        playerRb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        playerMovement.Player.Jump.performed += HandleJumping;
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
    

    private Vector2 GetMovementVectorNormalized()
    {
        Vector2 inputVector = playerMovement.Player.Move.ReadValue<Vector2>();

        inputVector = inputVector.normalized;
        return inputVector;
    }

    private void HandleMovement()
    {
        Vector2 inputVector = GetMovementVectorNormalized();
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

    private void HandleJumping(InputAction.CallbackContext callbackContext)
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
    private void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.transform.position, groundDistance, groundMask);
        HandleMovement();
    }
}

