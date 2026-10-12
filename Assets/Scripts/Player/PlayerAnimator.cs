using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private float _movementThreshold = 0.1f;
    private Rigidbody2D _rigidbody;
    private int _isRunningHash;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _isRunningHash = Animator.StringToHash("isRunning");
    }

    private void Update()
    {
        UpdateRunningAnimation();
    }

    private void UpdateRunningAnimation()
    {
        bool isMoving = Mathf.Abs(_rigidbody.linearVelocity.x) > _movementThreshold;

        _animator.SetBool(_isRunningHash, isMoving);
    }
}
