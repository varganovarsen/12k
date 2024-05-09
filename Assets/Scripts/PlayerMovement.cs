using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using TMPro.EditorUtilities;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public static PlayerMovement Instance;
    [SerializeField]
    Vector3 _velocity;
    Rigidbody2D _rigidbody;
    public Rigidbody2D Rigidbody2D => _rigidbody;
    public float Speed => _velocity.y / 60 * -1;

    private bool _isOnPlatform;
    public bool IsOnPlatform { get => _isOnPlatform; set => _isOnPlatform = value; }


    [SerializeField]
    private float _dragOnBrake = 1f;
    [SerializeField]
    private float _dragOnStop;
    [SerializeField]
    private float _basicDrag = 1f;
    [SerializeField]
    private float _minVelocity;
    private float basicGravityScale;

    private bool _isInputDisabled;


    bool _holdingDrag = false;
    public Vector3 Velocity => _velocity;


    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(Instance);
    }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.drag = _basicDrag;
        basicGravityScale = Rigidbody2D.gravityScale;
    }

    private void Update()
    {
        if (_isInputDisabled)
            return;


        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_isOnPlatform )
            {
                Freeze(false);
            }
            else
            {
                _rigidbody.drag = _dragOnBrake;
                _holdingDrag = true;
            }


            
        }
        if(Input.GetKeyUp(KeyCode.Space))
        {
            _rigidbody.drag = _basicDrag;
            _holdingDrag = false;
        }

        
    }
    private void FixedUpdate()
    {
       
        _velocity =_rigidbody.velocity;
        if (Mathf.Abs(_velocity.y) < _minVelocity && _holdingDrag)
        {
            _rigidbody.drag += _dragOnBrake;

            if(Mathf.Abs(_velocity.y) < 0.1f)
            {
                _velocity.y = 0f;
                _rigidbody.velocity = _velocity;
            }
            
        }
            
        DepthController.Depth += _velocity.y / 60f;
    }

    private void LateUpdate()
    {
        transform.position = Vector3.zero;
    }

    public void DisableInput()
    {
        _isInputDisabled = true;
        _holdingDrag = false;
        _rigidbody.drag = _basicDrag;
    }

    public void Freeze(bool freeze)
    {
        _rigidbody.constraints = freeze ? RigidbodyConstraints2D.FreezeAll : RigidbodyConstraints2D.FreezePositionX;
        _rigidbody.freezeRotation = true;
        _rigidbody.WakeUp();
    }
}
