using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Video;

public class GameInput : MonoBehaviour
{
    [SerializeField] private PlayerInputActions playerMovement;
    public static GameInput Instance;
    public event EventHandler JumpPerformed;
    public event EventHandler InteractPerformed;


    // Start is called before the first frame update
    private void Awake()
    {
        playerMovement = new PlayerInputActions();
        playerMovement.Player.Enable();
        playerMovement.Player.Jump.performed += Jump_performed;
        playerMovement.Player.Interact.performed += Interact_performed;
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            // Destroy(this.gameObject);
        }
    }

    private void Interact_performed(InputAction.CallbackContext obj)
    {
        InteractPerformed?.Invoke(this, EventArgs.Empty);
    }

    private void Jump_performed(InputAction.CallbackContext obj)
    {
        JumpPerformed?.Invoke(this, EventArgs.Empty);
    }

    public Vector2 GetMovementVectorNormalized()
    {
        Vector2 inputVector = playerMovement.Player.Move.ReadValue<Vector2>();

        inputVector = inputVector.normalized;
        return inputVector;
    }

    private void OnDisable()
    { 
        Instance = null;
       playerMovement.Player.Jump.performed -= Jump_performed;
       playerMovement.Player.Interact.performed -= Interact_performed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
