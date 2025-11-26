using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private float _speed = 2f;
    [SerializeField] private float _waypointThreshold = 0.1f;

    // Состояние
    private int _currentWaypointIndex = 0;
    private Rigidbody2D _rigidbody;
    private bool _isMoving = true;

    public bool HasReachedWaypoint => _waypoints.Length == 0 ||
        Vector2.Distance(transform.position, _waypoints[_currentWaypointIndex].position) < _waypointThreshold;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _rigidbody.freezeRotation = true;

        if (_waypoints.Length == 0)
        {
            Debug.LogWarning("No waypoints assigned to EnemyMovement!", this);
            _isMoving = false;
        }
    }

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

    private void MoveTowardsCurrentWaypoint()
    {

        if (_currentWaypointIndex >= _waypoints.Length) return;

        Vector2 targetPosition = _waypoints[_currentWaypointIndex].position;
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, _speed * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        if (_waypoints == null || _waypoints.Length == 0) return;

        for (int i = 0; i < _waypoints.Length; i++)
        {
            if (_waypoints[i] == null) continue;

            int next = (i + 1) % _waypoints.Length;
            if (_waypoints[next] == null) continue;

            Gizmos.color = i == _currentWaypointIndex ? Color.red : Color.yellow;
            Gizmos.DrawLine(_waypoints[i].position, _waypoints[next].position);
            Gizmos.DrawWireSphere(_waypoints[i].position, 0.2f);
        }
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
}