using UnityEngine;

public class Flipper : MonoBehaviour
{
    private bool _facingRight = true;
    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }

    public void LookAt(float moveX)
    {
        if (moveX > 0 && !_facingRight)
        {
            Flip();
        }
        else if (moveX < 0 && _facingRight)
        {
            Flip();
        }
    }

    public void Flip()
    {
        _facingRight = !_facingRight;
        Vector3 eulerAngles = _transform.eulerAngles;
        eulerAngles.y = _facingRight ? 0f : 180f;
        _transform.eulerAngles = eulerAngles;
    }

    public void SetFacingRight(bool right)
    {
        if (_facingRight != right)
        {
            Flip();
        }
    }
}
