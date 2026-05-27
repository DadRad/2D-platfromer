using UnityEngine;

public class ChaseState : IState
{
    private EnemyStateMachine _machine;
    private ChaseBehaviour _chase;

    public ChaseState(EnemyStateMachine machine)
    {
        _machine = machine;
        _chase = _machine.GetComponent<ChaseBehaviour>();
    }

    public void Enter()
    {
        _chase.StartChase(_machine.GetPlayer());
    }

    public void Exit()
    {
        _chase.StopChase();
    }

    public void Tick()
    {
        _chase.Tick();

        if (!_machine.PlayerDetected())
        {
            _machine.SwitchState(new PatrolState(_machine));
        }
    }
}
