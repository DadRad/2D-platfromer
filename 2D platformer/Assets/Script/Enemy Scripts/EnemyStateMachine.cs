using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{
    [SerializeField] private Transform _player;

    private IState _currentState;
    private Flipper _flipper;
    private Vector2 _previousPosition;

    public Transform GetPlayer() => _player;

    private void Awake()
    {
        _flipper = GetComponent<Flipper>();
        _previousPosition = transform.position;
    }

    private void Start()
    {
        SwitchState(new PatrolState(this));
    }

    private void Update()
    {
        _currentState?.Tick();
        UpdateFlip();
    }

    public void SwitchState(IState newState)
    {
        _currentState?.Exit();
        _currentState = newState;
        _currentState?.Enter();
    }

    public bool PlayerDetected()
    {
        ChaseBehaviour chase = GetComponent<ChaseBehaviour>();
        return chase != null && _player != null && chase.IsTargetInDetectionRange(_player);
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
