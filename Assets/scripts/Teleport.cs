using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform teleportationPosition;

    public GameObject puck;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Puck"))
        {
            teleport(other.gameObject);
        }
    }

    private void teleport(GameObject obj)
    {
        if (obj != null)
        {
            obj.transform.position = teleportationPosition.position;
        }
    }
}
