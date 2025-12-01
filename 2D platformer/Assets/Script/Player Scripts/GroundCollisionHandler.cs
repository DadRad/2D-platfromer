using UnityEngine;

public class GroundCollisionHandler : MonoBehaviour
{
    [SerializeField] private Jumper _jumper; 

    private int _groundContactCount = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Ground>(out _))
        {
            _groundContactCount++;
            UpdateCanJump();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Ground>(out _))
        {
            _groundContactCount = Mathf.Max(0, _groundContactCount - 1);
            UpdateCanJump();
        }
    }

    private void UpdateCanJump()
    {
        bool isGrounded = _groundContactCount > 0;
        _jumper.SetCanJump(isGrounded);
    }

    private void OnValidate()
    {
        if (_jumper == null)
        {
            Debug.LogWarning("Jumper не назначен в GroundCollisionHandler!", this);
        }
    }
}
