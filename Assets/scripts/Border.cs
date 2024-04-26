using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Border : MonoBehaviour
{
    void Update()
    {
        Vector3 currentPosition = transform.position;

        currentPosition.x = Mathf.Max(currentPosition.x, 0f);

        transform.position = currentPosition;
    }
}
