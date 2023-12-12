using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Player player;
    private Animator animator;

    private const string IS_WALKING = "isRunning";
    private const string JUMP = "Jump";
    [SerializeField] private GameInput gameInput;
    private void OnEnable()
    {
        gameInput.JumpPerformed += Jumped;
        animator = GetComponent<Animator>();
    }

    private void Jumped(object sender, EventArgs eventArgs)
    {
        // if()
        if (Player.isGrounded)
        {
            animator.SetTrigger(JUMP);
        }
    }

    private void Update()
    { 
        animator.SetBool(IS_WALKING, player.IsWalking());
    }

    private void OnDisable()
    {
       gameInput.JumpPerformed -= Jumped; 
    }
}
