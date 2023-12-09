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
    private void Start()
    {
        GameInput.JumpPerformed += Jumped;
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
}
