using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    Animator animator;
    private bool Drakaris = false;
    private int a = 0;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    [SerializeField] GameObject door;
    [SerializeField] private AudioClip dragon;
    // Start is called before the first frame update
    private void Update()
    {
        if (door == null && a == 0)
        {

            if (Drakaris == false)
            {
                animator.SetBool("Drakaris", true);
                Drakaris = true;
                AudioManager.Instance.PlayAudio(dragon);
            }
            else
            {
                animator.SetBool("Drakaris", false);
            }

        }
    }

}

