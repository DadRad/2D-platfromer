using UnityEngine;

public class GroundCollisionHandler : MonoBehaviour
{
    [SerializeField] private LayerMask _groundLayer;

    private int _groundContactCount;
    
    public event System.Action<bool> OnGroundedChanged;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (IsGround(collision))
        {
            _groundContactCount++;
            if (_groundContactCount == 1)
            {
                OnGroundedChanged?.Invoke(true);
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (IsGround(collision))
        {
            _groundContactCount = Mathf.Max(0, _groundContactCount - 1);
            if (_groundContactCount == 0)
            {
                OnGroundedChanged?.Invoke(false);
            }
        }
    }

    private bool IsGround(Collision2D collision)
    {
        return ((1 << collision.gameObject.layer) & _groundLayer) != 0;
    }
}
