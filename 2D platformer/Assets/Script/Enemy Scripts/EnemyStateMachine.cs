using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{
    [SerializeField] private Transform _player;

    private Flipper _flipper;
    private ChaseBehaviour _chase;
    private PatrolBehaviour _patrol;
    private Vector2 _previousPosition;

    private void Awake()
    {
        _chase = GetComponent<ChaseBehaviour>();
        _patrol = GetComponent<PatrolBehaviour>();
        _flipper = GetComponent<Flipper>();

        _previousPosition = transform.position;
    }

    private void Start()
    {
        _patrol.StartPatrol();
    }

    private void Update()
    {
        if (_player == null) return;

        if (_chase.IsTargetInDetectionRange(_player))
        {
            SwitchToChase();
        }
        else
        {
            SwitchToPatrol();
        }

        _chase.Tick();
        _patrol.Tick();
        UpdateFlip();
    }

    private void SwitchToChase()
    {
        if (_chase.IsChasing == false)
        {
            _patrol.StopPatrol();
            _chase.StartChase(_player);
        }
    }

    private void SwitchToPatrol()
    {
        if (_patrol.IsPatrolling == false)
        {
            _chase.StopChase();
            _patrol.StartPatrol();
        }
    }

    private void UpdateFlip()
    {
        if (_flipper == null) return;

        Vector2 currentPosition = transform.position;
        float moveX = currentPosition.x - _previousPosition.x;

        if (moveX != 0)
        {
            _flipper.LookAt(moveX);
        }

        _previousPosition = currentPosition;
    }
}
