using UnityEngine;

public class Respawn : MonoBehaviour
{
    public float fallThreshold = -10f; // Y position below which the sprite "dies"
    private Vector3 startingPosition; // The initial position of the sprite

    void Start()
    {
        // Store the sprite's starting position
        startingPosition = transform.position;
    }

    void Update()
    {
        // Check if the sprite's Y position is below the fall threshold
        if (transform.position.y < fallThreshold)
        {
            RespawnAtStart();
        }
    }

    void RespawnAtStart()
    {
        // Reset the sprite's position to its starting position
        transform.position = startingPosition;

        // Optionally, reset velocity (if using Rigidbody2D)
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f; // Stop rotation if applicable
        }

        // You can also add sound effects or animations here, if needed
        Debug.Log("You died bitch!");
    }
}
