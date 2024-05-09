using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public static PlayerMovement Instance;
    [SerializeField]
    Vector3 _velocity;
    Rigidbody2D _rigidbody;
    public Rigidbody2D Rigidbody2D => _rigidbody;
    [field:SerializeField]
    public float Speed => _velocity.y / 60 * -1;


    [SerializeField]
    private float _dragOnBrake = 1f;
    [SerializeField]
    private float _dragOnStop;
    [SerializeField]
    private float _basicDrag = 1f;
    [SerializeField]
    private float _minVelocity;


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
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody.drag = _dragOnBrake;
            _holdingDrag = true;
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
}
