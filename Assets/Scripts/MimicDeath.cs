using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MimicDeath : MonoBehaviour
{
    [SerializeField] private Player player;
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "mimicCapsule")
        {
            player.Die();
        }
    }

}
