using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WallParallax : MonoBehaviour
{
    [SerializeField]
    Vector3 startPosition = Vector3.zero;
    [SerializeField]
    Vector3 endPosition;

    [SerializeField]
    float scrollSpeedMultiplier;
    private void Start()
    {
        transform.position = startPosition;
    }
    private void FixedUpdate()
    {
        transform.position = new Vector3(
            transform.position.x,
            transform.position.y + (-PlayerMovement.Instance.Velocity.y * scrollSpeedMultiplier));

        if (transform.position.y > endPosition.y)
        {
            transform.position = startPosition;
        }
    }
}
