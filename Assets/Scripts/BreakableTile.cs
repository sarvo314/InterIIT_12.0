using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BreakableTile : MonoBehaviour
{
    public event EventHandler OnTileBreak;
    [SerializeField] private ParticleSystem breakEffect;
    [SerializeField] private AudioClip breakSound;
    [SerializeField] private float breakDelay = 0.5f;

    private GameManager gameManager;

    private void OnEnable()
    {
        OnTileBreak += PlayBreakSound;
        OnTileBreak += BreakTileEffect;
    }

    private void BreakTileSequence()
    {
        OnTileBreak?.Invoke(this, EventArgs.Empty);
    }

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameManager.isGameStarted && other.gameObject.CompareTag("Player"))
            
        {
            Debug.Log("Player entered we break tile now");
            Invoke("BreakTileSequence", breakDelay);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (gameManager.isGameStarted && gameObject != null && other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player exited we break tile now");
            Invoke("BreakTileSequence", breakDelay);
        }
    }

    // private void OnTriggerStay(Collider other)
    // {
    //     Debug.Log("game is started");
    //     if (gameManager.isGameStarted && other.gameObject.CompareTag("Player"))
    //
    //     {
    //         Debug.Log("Player entered we break tile now");
    //         Invoke("BreakTileSequence", breakDelay);
    //     }
    // }

    private void PlayBreakSound(object sender, EventArgs eventArgs)
    {
        AudioManager.Instance.PlayAudio(breakSound);
    }

    private void BreakTileEffect(object sender, EventArgs eventArgs)
    {
        Destroy(this.gameObject);
        Instantiate(breakEffect, transform.position, Quaternion.identity);
    }

    private void OnDisable()
    {
        OnTileBreak -= PlayBreakSound;
        OnTileBreak -= BreakTileEffect;
    }
}