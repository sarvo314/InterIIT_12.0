using UnityEngine;
using UnityEngine.Serialization;

public class BombSpawner : MonoBehaviour
{
    [FormerlySerializedAs("ballPrefab")] public GameObject bombPrefab;       // Prefab of the ball to spawn
    [SerializeField]
    private Transform spawnPoint;        // Point where the balls will be spawned
    [SerializeField]
    private float spawnInterval = 1.5f;  // Time interval between ball spawns
    [FormerlySerializedAs("ballSpeed")] [SerializeField]
    private float bombSpeed = 5.0f;      // Speed of the spawned balls
    [SerializeField]
    private Vector3 spawnDirection = Vector3.forward; // Direction of ball spawn

    private float timer = 0.0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnBall();
            timer = 0.0f;
        }
    }

    void SpawnBall()
    {
        GameObject newBall = Instantiate(bombPrefab, spawnPoint.position, Quaternion.identity);
        Rigidbody ballRigidbody = newBall.GetComponent<Rigidbody>();

        if (ballRigidbody != null)
        {
            // Set the velocity of the ball using the customizable spawn direction and speed
            ballRigidbody.velocity = spawnDirection.normalized * bombSpeed;
        }
        else
        {
            Debug.LogWarning("Ball prefab is missing Rigidbody component!");
        }
    }
}