using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float jumpForce = 10.0f;
    public LayerMask groundLayer;

    private Rigidbody rb;
    private bool isGrounded;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Check if the player is grounded using raycasts
        isGrounded = CheckGrounded();

        // Get horizontal input
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        // Calculate movement vector
        Vector3 movement = new Vector3(horizontalInput, 0.0f, 0.0f) * moveSpeed * Time.deltaTime;

        if (!GetComponent<Rotator>().rotating)
            transform.Translate(movement);

        // Jumping
        if (isGrounded && Input.GetButton("Jump"))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private bool CheckGrounded()
    {
        // Cast two rays from the bottom of the character to check for grounding
        Vector3 rayOrigin = transform.position - new Vector3(0, GetComponent<BoxCollider>().bounds.extents.y, 0);
        float rayLength = 0.2f;

        bool groundedLeft = Physics.Raycast(rayOrigin - transform.right * 0.2f, Vector3.down, rayLength, groundLayer);
        bool groundedRight = Physics.Raycast(rayOrigin + transform.right * 0.2f, Vector3.down, rayLength, groundLayer);
        
         // Debug draw rays
        Debug.DrawRay(rayOrigin - transform.right * 0.2f, Vector3.down * rayLength, groundedLeft ? Color.green : Color.red);
        Debug.DrawRay(rayOrigin + transform.right * 0.2f, Vector3.down * rayLength, groundedRight ? Color.green : Color.red);
        
        return groundedLeft || groundedRight;
    }
}