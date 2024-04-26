using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    public Transform puck;
    public float moveSpeed = 5f;
    public float maxDistanceToPuck = 1f;
    public GameObject ownGoal;
    public GameObject goal;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 directionToPuck = puck.position - transform.position;

        if (directionToPuck.magnitude <= maxDistanceToPuck)
        {
            rb.velocity = Vector2.zero; 
        }
        else
        {
            rb.velocity = directionToPuck.normalized * moveSpeed;
        }

        Vector2 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, -8.187876f, 0f);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, -4.075f, 4.075f);
        transform.position = clampedPosition;

        if (ownGoal != null && puck.position.x < ownGoal.transform.position.x)
        {
            rb.velocity = Vector2.zero;
        }

        if (puck.position.x < transform.position.x)
        {
            Vector2 moveBackwards = new Vector2(-1f, transform.position.y);
            rb.velocity = moveBackwards * moveSpeed;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Puck"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(rb.velocity * 2f, ForceMode2D.Impulse);
        }
    }
}
