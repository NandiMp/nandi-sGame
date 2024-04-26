using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPuck : MonoBehaviour
{
    public Transform respawnPoint; // Reference to the respawn point

    void Update()
    {
        // Check if the GameObject's position exceeds the bounds
        if (Mathf.Abs(transform.position.x) > 10f || Mathf.Abs(transform.position.y) > 10f)
        {
            // Reset the GameObject's position and momentum
            ResetObject();
        }
    }

    public void ResetObject()
    {
        // Reset the position to the respawn point
        transform.position = respawnPoint.position;

        // Reset the momentum by setting velocity to zero
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;
        }
    }
}
