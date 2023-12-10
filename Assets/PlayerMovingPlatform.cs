using UnityEngine;

public class PlayerMovingPlatform : MonoBehaviour
{
    private Transform player;
    private Transform platform;
    private bool isPlayerOnPlatform = false;

    void Start()
    {
        // Assuming the player is tagged as "Player"
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MovingPlatform"))
        {
            platform = other.transform;
            isPlayerOnPlatform = true;
            player.SetParent(platform); // Make the player a child of the platform
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MovingPlatform"))
        {
            isPlayerOnPlatform = false;
            player.SetParent(null); // Set player's parent to null, so it's not a child of the platform
            platform = null;
        }
    }

    void Update()
    {
        
    }
}
