using System;
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
    [SerializeField]
    int fillerSize;
    [SerializeField]
    Transform _ender;
    SpriteRenderer _enderSpr;
    public static Transform Filler;
    public static Transform Ender;

    [SerializeField]
    SpriteMask _tunnelMask;

    public float ChunkSize => startPosition.y - endPosition.y;

    public static event Action OnChunkCompleted;


    

    private void OnValidate()
    {
        _fillerSpr = _filler.GetChild(0).GetComponent<SpriteRenderer>();
        _enderSpr = _ender.GetChild(0).GetComponent<SpriteRenderer>();
        //SetFillerSize(fillerSize);
        Filler = _filler;
        Ender = _ender;
    }


    [SerializeField, Range(0, 1f)]
    float scrollSpeedMultiplier;
    private void Start()
    {
        transform.position = startPosition;
        SetFillerSize(fillerSize);
    }
    private void FixedUpdate()
    {
        transform.position = new Vector3(
            transform.position.x,
            transform.position.y + (-PlayerMovement.Instance.Velocity.y * scrollSpeedMultiplier));

        if (transform.position.y > endPosition.y)
        {
            transform.position = startPosition;
            OnChunkCompleted?.Invoke();
        }
    }

    public void SetFillerSize(int size)
    {
        fillerSize = size;


        _fillerSpr.size = new Vector2(_fillerSpr.size.x, fillerSize * _enderSpr.size.y);
        _ender.position = new Vector3(_ender.position.x, _filler.position.y - _fillerSpr.size.y);
        endPosition = new Vector3(_ender.position.x, Mathf.Abs(_ender.position.y - 20f));
        Transform pivot = _tunnelMask.transform.parent;
        pivot.localScale = new Vector3(pivot.localScale.x, _enderSpr.size.y * 2 + _fillerSpr.size.y);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector3 size = _fillerSpr.size;
        Gizmos.DrawWireCube(new Vector3(_filler.position.x, _filler.position.y - size.y / 2), size);
    }
}
