using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBelowRequired : MonoBehaviour
{
    [SerializeField] private Player player;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Ball"))
        {
            player.Die();
        }
    }
}
