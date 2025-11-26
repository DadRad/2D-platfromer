using UnityEngine;

public class Jumper : MonoBehaviour
{
    [SerializeField] private float jumpForce = 20f;
    
    private Rigidbody2D _rigidbody;
    private bool _canJump = true;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Jump()
    {
        if (_canJump)
        {
            _rigidbody.linearVelocity = new Vector2(_rigidbody.linearVelocity.x, jumpForce);
            _canJump = false;
        }
    }

    public void SetCanJump(bool canJump)
    {
        _canJump = canJump;
    }

    public bool CanJump => _canJump;
}
