using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    [SerializeField] private float _detectionRadius = 5f;
    [SerializeField] private float _chaseSpeed = 3f;
    [SerializeField] private Transform _player;
    [SerializeField] private EnemyMovement _enemyMovement;
    [SerializeField] private Flipper _flipper;

    private bool _isChasing = false;
    private Vector2 _previousPosition;
    private Rigidbody2D _rigidbody;

    public bool IsChasing => _isChasing;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _previousPosition = transform.position;
    }

    public void Tick()
    {
        if (_player == null || _rigidbody == null) return;

        bool playerDetected = IsPlayerDetected();

        if (playerDetected)
        {
            if (!_isChasing)
            {
                StartChase();
            }

            PursuePlayer();
        }
        else
        {
            if (_isChasing)
            {
                ResumePatrol();
            }
        }
    }

    private bool IsPlayerDetected()
    {
        float distance = Vector2.Distance(transform.position, _player.position);
        return distance <= _detectionRadius;
    }

    private void StartChase()
    {
        _isChasing = true;
        _enemyMovement.StopMovement();
    }

    private void ResumePatrol()
    {
        _isChasing = false;
        _enemyMovement.ResumeMovement();
    }

    private void PursuePlayer()
    {
        Vector2 direction = (_player.position - transform.position).normalized;
        
        _rigidbody.linearVelocity = direction * _chaseSpeed;

        if (direction.x != 0 && _flipper != null)
        {
            _flipper.LookAt(direction.x);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _detectionRadius);
    }
}
