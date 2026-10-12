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
        float dx = _waypoints[_currentWaypointIndex].position.x - transform.position.x;
        return Mathf.Abs(dx) < _waypointThreshold;
    }

    private void MoveTowardsCurrentWaypoint()
    {
        float dx = _waypoints[_currentWaypointIndex].position.x - transform.position.x;
        float dir = Mathf.Sign(dx);
        _rigidbody.linearVelocity = new Vector2(dir * _speed, _rigidbody.linearVelocity.y);
    }
}
