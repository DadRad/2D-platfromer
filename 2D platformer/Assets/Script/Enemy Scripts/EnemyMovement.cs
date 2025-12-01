using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private float _speed;
    [SerializeField] private float _waypointThreshold;
    private int _currentWaypointIndex = 0;
    private Rigidbody2D _rigidbody;
    private bool _isMoving = true;
    private float _sqrWaypointThreshold;
    public bool HasReachedWaypoint => _waypoints.Length == 0 || (transform.position - _waypoints[_currentWaypointIndex].position).sqrMagnitude < _sqrWaypointThreshold;


    public void Tick()
    {
        if (!_isMoving || _waypoints.Length == 0) return;

        if (HasReachedWaypoint)
        {
            _currentWaypointIndex = (_currentWaypointIndex + 1) % _waypoints.Length;

            _rigidbody.linearVelocity = Vector2.zero;
        }

        MoveTowardsCurrentWaypoint();
    }

    public void StopMovement()
    {
        _isMoving = false;
        _rigidbody.linearVelocity = Vector2.zero;
    }

    public void ResumeMovement()
    {
        if (_waypoints.Length > 0)
            _isMoving = true;
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _sqrWaypointThreshold = _waypointThreshold * _waypointThreshold;
    }

    private void Start()
    {
        _rigidbody.freezeRotation = true;

        if (_waypoints.Length == 0)
        {
            _isMoving = false;
        }
    }

    private void MoveTowardsCurrentWaypoint()
    {
        if (_currentWaypointIndex >= _waypoints.Length) return;

        Vector2 targetPosition = _waypoints[_currentWaypointIndex].position;
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, _speed * Time.deltaTime);
    }
}
