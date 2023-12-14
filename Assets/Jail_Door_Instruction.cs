using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Jail_Door_Instruction : MonoBehaviour
{
    private bool hasInteracted;
    [SerializeField]
    private GameObject instruction;

    [FormerlySerializedAs("canUnlock")] [SerializeField] private JailDoorNLock jailDoorNLock;

    private bool canUnlock;
    private void OnTriggerEnter(Collider other)
    {
        // Debug.Log("Entered in trigger of jail door");
        // Debug.Log("we can " + jailDoorNLock.CanUnlock() + " the door instrctuion");
        if (other.gameObject.CompareTag("Player") && canUnlock)
        {
            Debug.Log("we unlock");
            instruction.SetActive(true);
        }
    }

    private void Update()
    {
        if (jailDoorNLock.CanUnlock())
            canUnlock = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            instruction.SetActive(false);
        }
    }
}
