using UnityEngine;

public class PatrolState : IState
{
    private EnemyStateMachine _machine;
    private PatrolBehaviour _patrol;
    private EnemyVision _vision;

    public PatrolState(EnemyStateMachine machine)
    {
        _machine = machine;
        _patrol = _machine.GetComponent<PatrolBehaviour>();
        _vision = _machine.GetComponent<EnemyVision>();
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

        if (_vision.TryDetectTarget())
        {
            _machine.SwitchState(new ChaseState(_machine));
        }
    }
}