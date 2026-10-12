using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ChaseBehaviour : MonoBehaviour
{
    [SerializeField] private float _detectionRadius = 5f;
    [SerializeField] private float _chaseSpeed = 3f;
    [SerializeField] private float _stopDistance = 0.9f;
    [SerializeField] private bool _useGravity = true;

    private Flipper _flipper;
    private Transform _target;
    private Rigidbody2D _rigidbody;

    public bool IsChasing { get; private set; }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _flipper = GetComponent<Flipper>();
    }

    public void StartChase(Transform target)
    {
        if (target == null)
            return;

        _target = target;
        IsChasing = true;
    }

    public void StopChase()
    {
        _target = null;
        IsChasing = false;
        SetVelocity(0f);
    }

    public void Tick()
    {
        if (IsChasing == false || _target == null)
            return;

        float deltaX = _target.position.x - transform.position.x;
        float distance = Mathf.Abs(deltaX);

        if (distance <= _stopDistance)
        {
            SetVelocity(0f);
            _flipper?.LookAt(Mathf.Sign(deltaX));
            return;
        }

        float directionX = Mathf.Sign(deltaX);
        SetVelocity(directionX * _chaseSpeed);
        _flipper?.LookAt(directionX);
    }

    private void SetVelocity(float velocityX)
    {
        Vector2 velocity = _rigidbody.linearVelocity;
        velocity.x = velocityX;

        if (_useGravity == false)
            velocity.y = 0f;

        _rigidbody.linearVelocity = velocity;
    }

    public bool IsTargetInDetectionRange(Transform target)
    {
        if (target == null)
            return false;

        return Vector2.Distance(transform.position, target.position) <= _detectionRadius;
    }
}