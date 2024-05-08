using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public static PlayerMovement Instance;
    [SerializeField]
    Vector3 _velocity;
    Rigidbody2D _rigidbody;
    [field:SerializeField]
    public float Speed => _velocity.y / 60 * -1;


    [SerializeField]
    float dragOnBrake = 1f;
    [SerializeField]
    float basicDrag = 1f;

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
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            _rigidbody.drag = dragOnBrake;
            _holdingDrag = true;
        }
        if(Input.GetKeyUp(KeyCode.Space))
        {
            _rigidbody.drag = basicDrag;
            _holdingDrag = false;
        }
    }
    private void FixedUpdate()
    {
       
        _velocity =_rigidbody.velocity;
        if (Mathf.Abs(_velocity.y) < 1f && _holdingDrag)
        {
            _velocity.y = 0f;
            _rigidbody.velocity = _velocity;
        }
            
        DepthController.Depth += _velocity.y / 60f;
    }

    private void LateUpdate()
    {
        transform.position = Vector3.zero;
    }
}
