using UnityEngine;
public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Get input values for horizontal movement
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        // Calculate movement vector
        Vector2 movement = new Vector2(horizontalInput, 0f);

        // Normalize the movement vector to ensure consistent speed in all directions
        movement.Normalize();

        // Move the rigidbody
        rb.velocity = movement * moveSpeed;
    }
}