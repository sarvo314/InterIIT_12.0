using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float playerSpeed = 5f;
    private PlayerInputActions playerMovement;
    private void Awake()
    {
        playerMovement = new PlayerInputActions();
        playerMovement.Player.Enable();
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

    private void Update()
    {
        HandleMovement();
    }
}