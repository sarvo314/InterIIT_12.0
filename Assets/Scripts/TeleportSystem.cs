using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TeleportSystem : MonoBehaviour
{
    [SerializeField] public Transform teleportTarget;
    private bool canTeleport;
    [SerializeField] private AudioClip teleportSound;
    private GameObject player;
    [SerializeField] private GameInput gameInput;
    [SerializeField] private bool allowPlayerToInteract = true;
    private void Start()
    {
        gameInput.InteractPerformed += HandleTeleport;
    }

    private void HandleTeleport(object sender, EventArgs e)
    {
        if (canTeleport && player != null && allowPlayerToInteract)
        {
            player.transform.position = teleportTarget.position;
            canTeleport = false;
            AudioManager.Instance.PlayAudio(teleportSound);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player = other.gameObject;
            canTeleport = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canTeleport = false;
        }
    }

    private void OnDisable()
    {
       gameInput.InteractPerformed -= HandleTeleport; 
    }
}