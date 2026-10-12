using System.Collections;
using UnityEngine;

public abstract class Attacker : MonoBehaviour
{
    [SerializeField] protected float _attackDistance = 1.5f;
    [SerializeField] protected int _damage = 20;
    [SerializeField] protected LayerMask _targetLayer;
    [SerializeField] protected float _attackCooldown = 0.5f;
    [SerializeField] protected Vector2 _originOffset = new Vector2(0f, 0.5f);

    private bool _canAttack = true;

    public bool CanAttack => _canAttack;
    public float AttackDistance => _attackDistance;

    protected Vector2 AttackOrigin => (Vector2)transform.position + _originOffset;

    protected abstract bool TryGetAttackDirection(out Vector2 direction);

    public void PerformAttack()
    {
        if (_canAttack == false)
            return;

        if (TryGetAttackDirection(out Vector2 attackDirection) == false)
            return;

        StartCoroutine(AttackCooldown());

        Vector2 origin = AttackOrigin;

        Debug.DrawRay(origin, attackDirection * _attackDistance, Color.red, 0.2f);

        RaycastHit2D[] hits = Physics2D.RaycastAll(origin, attackDirection, _attackDistance, _targetLayer);

        foreach (RaycastHit2D hit in hits)
        {
            if (hit.collider.transform.IsChildOf(transform))
                continue;

            if (hit.collider.TryGetComponent(out IDamageable damageable) == false)
                continue;

            damageable.TakeDamage(_damage);
            OnAttackHit(hit.collider);
            return;
        }
    }

    protected virtual void OnAttackHit(Collider2D target)
    {
    }

    private IEnumerator AttackCooldown()
    {
        _canAttack = false;
        yield return new WaitForSeconds(_attackCooldown);
        _canAttack = true;
    }
}