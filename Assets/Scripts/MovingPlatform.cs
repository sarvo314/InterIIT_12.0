using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform startPoint;    // The starting point of the platform
    public Transform endPoint;      // The ending point of the platform
    public float speed = 2.0f;      // The speed at which the platform moves
    public float pauseTime = 2.0f;  // Time to pause at each point (optional)

    private bool movingToEnd = true; // Indicates if the platform is moving towards the end point
    private float timer = 0.0f;      // Timer for pausing at points

    void Update()
    {
        if (movingToEnd)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPoint.position, speed * Time.deltaTime);

            if (transform.position == endPoint.position)
            {
                timer += Time.deltaTime;
                if (timer >= pauseTime)
                {
                    movingToEnd = false;
                    timer = 0.0f;
                }
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, startPoint.position, speed * Time.deltaTime);

            if (transform.position == startPoint.position)
            {
                timer += Time.deltaTime;
                if (timer >= pauseTime)
                {
                    movingToEnd = true;
                    timer = 0.0f;
                }
            }
        }
    }

    // Optionally, you can visualize the platform's movement path in the editor
    private void OnDrawGizmos()
    {
        if (startPoint != null && endPoint != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(startPoint.position, 0.5f);
            Gizmos.DrawSphere(endPoint.position, 0.5f);
            Gizmos.DrawLine(startPoint.position, endPoint.position);
        }
    }
}