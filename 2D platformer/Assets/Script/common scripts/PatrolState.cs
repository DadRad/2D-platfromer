using UnityEngine;

public class PatrolState : IState
{
    private EnemyStateMachine _machine;
    private PatrolBehaviour _patrol;

    public PatrolState(EnemyStateMachine machine)
    {
        _machine = machine;
        _patrol = _machine.GetComponent<PatrolBehaviour>();
    }

    public void Enter()
    {
        _patrol.StartPatrol();
    }

    public void Exit()
    {
        _patrol.StopPatrol();
    }

    public void Tick()
    {
        _patrol.Tick();

        if (_machine.PlayerDetected())
        {
            _machine.SwitchState(new ChaseState(_machine));
        }
    }
}
