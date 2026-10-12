using UnityEngine;

public class Flipper : MonoBehaviour
{
    [SerializeField] private bool _spriteFacesRightByDefault = true;

    private bool _facingRight;
    private Transform _transform;

    public bool FacingRight => _facingRight;

    public Vector2 LookDirection => _facingRight ? Vector2.right : Vector2.left;

    private void Awake()
    {
        _transform = transform;
        _facingRight = _spriteFacesRightByDefault;
        ApplyRotation();
    }

    public void LookAt(float moveX)
    {
        if (Mathf.Approximately(moveX, 0f))
            return;

        SetFacingRight(moveX > 0f);
    }

    public void SetFacingRight(bool right)
    {
        if (_facingRight == right)
            return;

        _facingRight = right;
        ApplyRotation();
    }

    public void Flip()
    {
        SetFacingRight(_facingRight == false);
    }

    private void ApplyRotation()
    {
        bool visuallyRight = _facingRight == _spriteFacesRightByDefault;

        Vector3 eulerAngles = _transform.eulerAngles;
        eulerAngles.y = visuallyRight ? 0f : 180f;
        _transform.eulerAngles = eulerAngles;
    }
}