using UnityEngine;

public class MoveRandomly : MonoBehaviour
{
    public float moveSpeed = 3.0f; // Speed of the butterfly
    public float changeDirectionTime = 2.0f; // Time interval to change direction
    private float timer = 0.0f;
    private Vector3 randomDirection;

    void Start()
    {
        // Set the initial random direction
        SetRandomDirection();
    }

    void Update()
    {
        // Move the butterfly in the random direction
        transform.Translate(randomDirection * moveSpeed * Time.deltaTime);

        // Timer to change direction
        timer += Time.deltaTime;
        if (timer >= changeDirectionTime)
        {
            SetRandomDirection();
            timer = 0.0f;
        }
    }

    // Method to set a new random direction
    void SetRandomDirection()
    {
        // Generate a new random direction
        randomDirection = new Vector3(Random.Range(-1.0f, 1.0f), 0.0f, Random.Range(-1.0f, 1.0f)).normalized;
    }
}