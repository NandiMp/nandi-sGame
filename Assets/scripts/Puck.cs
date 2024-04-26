using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puck : MonoBehaviour
{
    public GameObject gameObject1;
    public GameObject gameObject2;

    private ScoringScript sc;
    private Goal1 g1;
    private RespawnPuck rp;

    private void Start()
    {
        sc = GameObject.FindGameObjectWithTag("Player").GetComponent<ScoringScript>();
        g1 = GameObject.FindGameObjectWithTag("AI").GetComponent<Goal1>();
        rp = GetComponent<RespawnPuck>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == gameObject1)
        {
            g1.OnPuckCollision();
            sc.consecutiveCollisions = 0;
        }
        else if (collision.gameObject == gameObject2)
        {
            
            sc.OnPuckCollision();
            g1.consecutiveCollisions = 0;
        }

        if (collision.gameObject == gameObject1 && g1.consecutiveCollisions > 0)
        {
            sc.consecutiveCollisions = 0;
        }

        if (collision.gameObject == gameObject2 && sc.consecutiveCollisions > 0)
        {
            g1.consecutiveCollisions = 0;
        }
    }
}
