using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float moveSpeed = 5f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Get input for movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Move the player
        Move(horizontalInput, verticalInput);
    }

    void Move(float horizontal, float vertical)
    {
        // Calculate movement vector
        Vector2 movement = new Vector2(horizontal, vertical) * moveSpeed * Time.deltaTime;

        // Apply movement to the rigidbody
        rb.MovePosition(rb.position + movement);
    }
}
