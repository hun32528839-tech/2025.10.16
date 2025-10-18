using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpPower;
    private Vector3 _moveDirection;
    private bool _isGround = true;
    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _moveDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.D))
        {           
            _moveDirection += Vector3.right;
        }
        if (Input.GetKey(KeyCode.A))
        {            
            _moveDirection += Vector3.left;
        }

        if (Input.GetKey(KeyCode.Space) && _isGround)
        {
            TryJump();
        }
        _moveDirection = _moveDirection.normalized;
    }

    private void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + _moveDirection * _speed * Time.fixedDeltaTime);
    }

    public void TryJump()
    {
        if (_isGround)
        {
            _rb.AddForce(Vector3.up * _jumpPower, ForceMode.Impulse);
            _isGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGround = true;
        }

        else if (collision.gameObject.CompareTag("Schanze"))
        {
            _rb.AddForce(Vector3.up * 15f, ForceMode.Impulse);
        }     
    }


}
