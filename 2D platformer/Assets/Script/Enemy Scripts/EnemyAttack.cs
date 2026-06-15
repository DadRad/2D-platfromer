using UnityEngine;

[RequireComponent(typeof(EnemyVision))]
public class EnemyAttack : Attacker
{
    [SerializeField] private float _attackRange = 1f;

    private EnemyVision _vision;

    private void Awake()
    {
        _vision = GetComponent<EnemyVision>();
    }

    private void Update()
    {
        if (_canAttack && _vision.IsTargetInRange(_attackRange))
        {
            PerformAttack();
        }
    }

    protected override bool TryGetAttackDirection(out Vector2 direction)
    {
        direction = Vector2.zero;

        Player target = _vision.CurrentTarget;
        if (target == null) return false;

        direction = ((Vector2)target.transform.position - (Vector2)transform.position).normalized;
        return true;
    }

    protected override void OnAttackHit(Collider2D target)
    {
        Debug.Log($"Враг атаковал {target.name}!");
    }
}
