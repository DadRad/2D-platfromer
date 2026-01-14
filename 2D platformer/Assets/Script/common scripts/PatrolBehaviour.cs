using UnityEngine;

public class PatrolBehaviour : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private float _speed = 2f;
    [SerializeField] private float _waypointThreshold = 0.1f;

    private int _currentWaypointIndex = 0;
    private Rigidbody2D _rigidbody;
    private bool _isPatrolling = true;
    private float _sqrThreshold;

    public bool IsPatrolling => _isPatrolling && _waypoints.Length > 0;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _sqrThreshold = _waypointThreshold * _waypointThreshold;
    }

    private void Start()
    {
        _rigidbody.freezeRotation = true;
    }

    public void StartPatrol()
    {
        _isPatrolling = true;

        if (_waypoints.Length > 0)
        {
            _currentWaypointIndex = 0;
        }
    }

    public void StopPatrol()
    {
        _isPatrolling = false;
        _rigidbody.linearVelocity = Vector2.zero;
    }

    public void Tick()
    {
        if (!_isPatrolling || _waypoints.Length == 0) return;

        if (HasReachedWaypoint())
        {
            _currentWaypointIndex = (_currentWaypointIndex + 1) % _waypoints.Length;
        }

        MoveTowardsCurrentWaypoint();
    }

    private bool HasReachedWaypoint()
    {
        Vector2 position = transform.position;
        Vector2 target = _waypoints[_currentWaypointIndex].position;
        return (position - target).sqrMagnitude < _sqrThreshold;
    }

    private void MoveTowardsCurrentWaypoint()
    {
        Vector2 target = _waypoints[_currentWaypointIndex].position;
        Vector2 direction = (target - (Vector2)transform.position).normalized;
        _rigidbody.linearVelocity = direction * _speed;
    }
}
