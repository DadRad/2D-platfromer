using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private Jumper _jumper;
    [SerializeField] private Flipper _flipper;

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

        if (_flipper == null)
        {
            _flipper = GetComponent<Flipper>();
        }
    }

    private void Start()
    {
        _rigidbody.freezeRotation = true;
    }

    private void Update()
    {
        if (_inputReader.JumpPressed && _jumper.CanJump)
        {
            _jumper.Jump();
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float moveX = _inputReader.HorizontalInput * _speed;
        _rigidbody.linearVelocity = new Vector2(moveX, _rigidbody.linearVelocity.y);

        if (_flipper != null && moveX != 0)
        {
            _flipper.LookAt(moveX);
        }
    }
}
