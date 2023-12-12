using UnityEngine;

public class MoveForward : MonoBehaviour
{
    [SerializeField]
    private float speed = 2.0f; // Serialized variable for speed

    void Update()
    {
        // Move the object forward based on its local position
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}