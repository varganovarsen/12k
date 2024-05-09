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
    Transform _filler;
    SpriteRenderer _fillerSpr;
    private void OnValidate()
    {
        _fillerSpr = _filler.GetChild(0).GetComponent<SpriteRenderer>();
    }


    [SerializeField, Range(0,0.1f)]
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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector3 size = new Vector3(_fillerSpr.size.x * 2 + 2, _fillerSpr.size.y);
        Gizmos.DrawWireCube(_filler.position, size);
    }
}
