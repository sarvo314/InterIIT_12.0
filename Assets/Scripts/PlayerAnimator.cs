using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Player player;
    private Animator animator;

    private const string IS_WALKING = "isRunning";
    private const string CAN_JUMP = "Jump";
    private PlayerInputActions playerInputActions;
    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
        playerInputActions.Player.Jump.performed += Jumped;
        animator = GetComponent<Animator>();
    }

    private void Jumped(InputAction.CallbackContext obj)
    {
        // if()
        Debug.Log("Jump animation");
        animator.SetTrigger(CAN_JUMP);
    }

    private void Update()
    { 
        animator.SetBool(IS_WALKING, player.IsWalking());
    }
}
