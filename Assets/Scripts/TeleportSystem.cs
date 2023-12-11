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

    private void Start()
    {
        GameInput.InteractPerformed += HandleTeleport;
    }

    private void HandleTeleport(object sender, EventArgs e)
    {
        if (canTeleport && player != null)
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
}