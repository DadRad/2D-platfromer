using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{
    private IState _currentState;

    private void Start()
    {
        SwitchState(new PatrolState(this));
    }

    private void Update()
    {
        _currentState?.Tick();
    }

    public void SwitchState(IState newState)
    {
        _currentState?.Exit();
        _currentState = newState;
        _currentState?.Enter();
    }
}