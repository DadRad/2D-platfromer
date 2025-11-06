using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 20f;

    private bool _canJump = true;
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody;
    private bool _facingRight = true;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        _rigidbody.freezeRotation = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _canJump)
        {
            Jump();
            _canJump = false;
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float moveX = 0f;

        if (Input.GetKey(KeyCode.A))
            moveX = -speed;
        else if (Input.GetKey(KeyCode.D))
            moveX = speed;

        _rigidbody.linearVelocity = new Vector2(moveX, _rigidbody.linearVelocity.y);

        if (moveX > 0 && !_facingRight)
        {
            Flip();
        }
        else if (moveX < 0 && _facingRight)
        {
            Flip();
        }
    }

    private void Jump()
    {
        _rigidbody.linearVelocity = new Vector2(_rigidbody.linearVelocity.x, jumpForce);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            _canJump = true;
    }
    
    private void Flip()
    {
        _facingRight = !_facingRight;
        Vector3 scale = _spriteRenderer.transform.localScale;
        scale.x *= -1;
        _spriteRenderer.transform.localScale = scale;
    }
}