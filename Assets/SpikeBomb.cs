using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpikeBomb : MonoBehaviour
{
   [SerializeField]
   private GameObject explosionPrefab;

   [SerializeField] private AudioClip explosionSound;
    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Player":
                other.gameObject.GetComponent<Player>().Die();
                Explode();
                break; 
            case "Ball":
                Destroy(other.gameObject);
                
                Explode();
                break;
        }
    }

    private void Explode()
    {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        AudioManager.Instance.PlayAudio(explosionSound);
        Destroy(gameObject);
    }
}
