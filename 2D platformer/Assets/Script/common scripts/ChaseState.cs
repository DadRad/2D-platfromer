using UnityEngine;

public class ChaseState : IState
{
    private EnemyStateMachine _machine;
    private ChaseBehaviour _chase;
    private EnemyVision _vision;

    public ChaseState(EnemyStateMachine machine)
    {
        _machine = machine;
        _chase = _machine.GetComponent<ChaseBehaviour>();
        _vision = _machine.GetComponent<EnemyVision>();
    }

    public void Enter()
    {
        _chase.StartChase(_vision.CurrentTarget.transform);
    }

    public void Exit()
    {
        _chase.StopChase();
    }

    public void Tick()
    {
        _chase.Tick();

        if (_vision.TryDetectTarget() == false)
        {
            _machine.SwitchState(new PatrolState(_machine));
        }
    }
}