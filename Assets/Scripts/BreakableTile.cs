using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BreakableTile : MonoBehaviour
{
    public static event EventHandler OnTileBreak;
    [SerializeField]
    private ParticleSystem breakEffect;
    [SerializeField]
    private AudioClip breakSound;
    [SerializeField]
    private float breakDelay = 0.5f;

    private void OnEnable()
    {
        OnTileBreak += PlayBreakSound;
        OnTileBreak += BreakTileEffect;
    }
    private void BreakTileSequence()
    {
        OnTileBreak?.Invoke(this, EventArgs.Empty);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Invoke("BreakTileSequence", breakDelay);
        }
    }

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
