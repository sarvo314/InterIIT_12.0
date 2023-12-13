using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeDeath : MonoBehaviour
{
    [SerializeField] private Player player;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "SpikeTiles")
        {
            player.Die();
        }
    }

}
