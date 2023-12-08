using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 5f;
    [SerializeField] private float jumpForce = 20f;
    private Rigidbody playerRb;
    private bool canJump = true;

    private EventHandler OnJump;
    private PlayerInputActions playerMovement;
    private void Awake()
    {
        playerMovement = new PlayerInputActions();
        playerMovement.Player.Enable();
        playerRb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        playerMovement.Player.Jump.performed += _ => HandleJumping();
    }
    private void OnCollisionEnter(Collision collision)
    {
        canJump = true;
    }
    public Vector2 GetMovementVectorNormalized()
    {
        Vector2 inputVector = playerMovement.Player.Move.ReadValue<Vector2>();

        inputVector = inputVector.normalized;
        return inputVector;
    }

    private void HandleMovement()
    {
        Vector2 inputVector = GetMovementVectorNormalized();

        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);

        float moveDistance = playerSpeed * Time.deltaTime;
        float playerRadius = 0.9f;
        float playerHeight = 2f;
        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDir, moveDistance);
        if (canMove)
        {
            transform.position += moveDir * Time.deltaTime * playerSpeed;
        }
        // Smooth rotation
        float rotateSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed);
    }

    private void HandleJumping()
    {
        Debug.Log(canJump);
        Debug.Log("Jump called");
        if (canJump)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            canJump = false;
        }
    }
    private void Update()
    {
        HandleMovement();
    }
}

