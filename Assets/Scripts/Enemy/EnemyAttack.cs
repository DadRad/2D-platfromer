using UnityEngine;

[RequireComponent(typeof(EnemyVision))]
public class EnemyAttack : Attacker
{
    private EnemyVision _vision;

    private void Awake()
    {
        _vision = GetComponent<EnemyVision>();
    }

    private void Update()
    {
        if (CanAttack == false)
            return;

        if (_vision.IsTargetInRange(AttackDistance))
            PerformAttack();
    }

    protected override bool TryGetAttackDirection(out Vector2 direction)
    {
        direction = Vector2.zero;

        Player target = _vision.CurrentTarget;

        if (target == null)
            return false;

        Vector2 toTarget = (Vector2)target.transform.position - AttackOrigin;

        if (toTarget.sqrMagnitude < 0.0001f)
            return false;

        direction = toTarget.normalized;
        return true;
    }

    protected override void OnAttackHit(Collider2D target)
    {
        Debug.Log($"Враг атаковал {target.name}!");
    }
}