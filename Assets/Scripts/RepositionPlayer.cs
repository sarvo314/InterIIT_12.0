using UnityEngine;
using UnityEngine.Serialization;

public class RepositionPlayer : MonoBehaviour
{
    public LayerMask groundLayer; // Set this in the Inspector to the layer where your ground objects reside
    public float repositionOffset = 0.5f; // Offset to lift the player above the ground
    [FormerlySerializedAs("playerCollisionCheckCollider")] [FormerlySerializedAs("playerCollider")] [SerializeField]
    private Collider collisionChest;

    [SerializeField] private Collider collisionHead;
    [SerializeField] private Collider collisionLegs;
        

    private void Start()
    {
        // playerCollisionCheckCollider = GetComponent<Collider>();
    }

    private void Update()
    {
        Collider[] collidersChest = Physics.OverlapBox(collisionChest.transform.position, collisionChest.bounds.extents, transform.rotation, groundLayer);
        Collider[] collidersHead = Physics.OverlapBox(collisionHead.transform.position, collisionHead.bounds.extents, transform.rotation, groundLayer);
        Collider[] collidersLegs = Physics.OverlapBox(collisionLegs.transform.position, collisionLegs.bounds.extents, transform.rotation, groundLayer);

        Vector3 newPosition = transform.position;
        // Check if any colliders overlap with the player's collider
        if (collidersChest.Length > 0 )
        {
            // Reposition the player above the ground
            foreach (Collider col in collidersChest)
            {
                // Debug.Log("Collider is " + col.gameObject.name);
                if (col.CompareTag("Ground")) // Check if the collider is tagged as "Ground"
                {
                    Debug.Log("touches chest");
                    Reposition(col, newPosition);
                    break;
                }
            }
        }

        if (collidersHead.Length > 0)
        {
            foreach (Collider col in collidersChest)
            {
                // Debug.Log("Collider is " + col.gameObject.name);
                if (col.CompareTag("Ground")) // Check if the collider is tagged as "Ground"
                {
                    Debug.Log("touches head");
                    Reposition(col, newPosition);
                    break;
                }
            }
        }

        if (collidersLegs.Length > 0)
        {
            foreach (Collider col in collidersChest)
            {
                // Debug.Log("Collider is " + col.gameObject.name);
                if (col.CompareTag("Ground")) // Check if the collider is tagged as "Ground"
                {
                    Debug.Log("touches legs");
                    Reposition(col, newPosition);
                    break;
                }
            }
        }
        

    }

    private void Reposition(Collider col, Vector3 newPosition)
    {
        Bounds groundBounds = col.bounds;
        float overlapAmount = collisionChest.bounds.Intersects(groundBounds)
            ? Mathf.Abs(collisionChest.bounds.min.y - groundBounds.max.y)
            : 0f;
        Debug.Log("Overlap amount " + overlapAmount);
        newPosition.y += overlapAmount + repositionOffset;
        transform.position = newPosition;
    }
}