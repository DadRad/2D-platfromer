using UnityEngine;

public class Jumper : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 20f;
    [SerializeField] private GroundCollisionHandler _groundHandler;

    private Rigidbody2D _rigidbody;
    private bool _canJump = true;

    public bool CanJump => _canJump;

    public void Jump()
    {
        if (_canJump)
        {
            _rigidbody.linearVelocity = new Vector2(_rigidbody.linearVelocity.x, _jumpForce);
            _canJump = false;
        }
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _rigidbody.freezeRotation = true;
    }

    private void OnEnable()
    {
        if (_groundHandler != null)
        {
            _groundHandler.OnGroundedChanged += OnGroundedChanged;
        }
        else
        {
            Debug.LogError("GroundCollisionHandler не назначен в Jumper!", this);
        }
    }

    private void OnDisable()
    {
        if (_groundHandler != null)
        {
            _groundHandler.OnGroundedChanged -= OnGroundedChanged;
        }
    }

    private void OnGroundedChanged(bool isGrounded)
    {
        _canJump = isGrounded;
    }
}
