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
    private const string DEATH = "Death";
    [SerializeField] private GameInput gameInput;
    private void OnEnable()
    {
        gameInput.JumpPerformed += Jumped;
        Player.PlayerDied += DieAnimation;
        animator = GetComponent<Animator>();
    }

    private void Jumped(object sender, EventArgs eventArgs)
    {
        // if()
        if (Player.isGrounded && player.IsDead == false)
        {
            animator.SetTrigger(JUMP);
        }
    }
    private void DieAnimation(object sender, EventArgs eventArgs)
    {
        animator.SetTrigger(DEATH);
    }
    private void Update()
    { 
        if(player.IsDead == false)
            animator.SetBool(IS_WALKING, player.IsWalking());
    }

    private void OnDisable()
    {
       gameInput.JumpPerformed -= Jumped; 
       Player.PlayerDied -= DieAnimation;
    }
}
