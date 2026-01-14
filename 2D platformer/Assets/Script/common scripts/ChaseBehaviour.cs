using UnityEngine;

public class ChaseBehaviour : MonoBehaviour
{
    [SerializeField] private float _detectionRadius = 5f;
    [SerializeField] private float _chaseSpeed = 3f;

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
        _target = target;
        IsChasing = true;
    }

    public void StopChase()
    {
        _target = null;
        IsChasing = false;
        _rigidbody.linearVelocity = Vector2.zero;
    }

    public void Tick()
    {
        if (!IsChasing || _target == null || _rigidbody == null) return;

        Vector2 direction = (_target.position - transform.position).normalized;
        _rigidbody.linearVelocity = direction * _chaseSpeed;

        if (direction.x != 0 && _flipper != null)
        {
            _flipper.LookAt(direction.x);
        }
    }


    public bool IsTargetInDetectionRange(Transform target)
    {
        return Vector2.Distance(transform.position, target.position) <= _detectionRadius;
    }
}
