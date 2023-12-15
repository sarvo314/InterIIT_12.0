using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JailDoorNLock : MonoBehaviour
{
    // [SerializeField] private AudioClip openSound;
    // [SerializeField] private AudioClip interactSound;
    // private GameObject player;
    [SerializeField] private GameInput gameInput;
    [SerializeField] private CubeManager Lock;
    [SerializeField] private GameObject Mimic;
    [SerializeField] private bool canUnlock;
    [SerializeField] private Player player;
    [SerializeField] private GameObject instruction;
    // Start is called before the first frame update
    void Start()
    {
        instruction.SetActive(false);
        gameInput.InteractPerformed += StartMinigame;
    }
    public bool CanUnlock()
    {
        return canUnlock;
    }
    private void StartMinigame(object sender, EventArgs e)
    {
        if (canUnlock)
        {
            if (!Mimic.activeSelf && !Lock.Win())
            {
                Lock.gameObject.SetActive(true);
                player.canMove = false;
                gameInput.InteractPerformed -= StartMinigame;
                instruction.SetActive(false);
            }
            else
            {
                Debug.Log("I have to defeat THAT first!");
            }
        }
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canUnlock = true;
            if(instruction.activeSelf == false)
                instruction.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(instruction.activeSelf) instruction.SetActive(false);
                
            canUnlock = false;
        }
    }
}
