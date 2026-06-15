using UnityEngine;
using System.Collections;

public abstract class Attacker : MonoBehaviour
{
    [SerializeField] protected float _attackDistance = 1.5f;
    [SerializeField] protected int _damage = 20;
    [SerializeField] protected LayerMask _targetLayer;
    [SerializeField] protected float _attackCooldown = 0.5f;

    [SerializeField] protected bool _canAttack = true;
    
    protected abstract bool TryGetAttackDirection(out Vector2 direction);

    public void PerformAttack()
    {
        if (_canAttack == false) return;

        if (TryGetAttackDirection(out Vector2 attackDirection) == false) return;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, attackDirection, _attackDistance, _targetLayer);

        Debug.DrawRay(transform.position, attackDirection * _attackDistance, Color.red, 0.2f);

        if (hit.collider != null)
        {
            IDamageable damageable = hit.collider.GetComponent<IDamageable>();

            if (damageable != null)
            {
                damageable.TakeDamage(_damage);
                OnAttackHit(hit.collider);
                StartCoroutine(AttackCooldown());
            }
        }
    }

    protected virtual void OnAttackHit(Collider2D target)
    {
    }

    protected IEnumerator AttackCooldown()
    {
        _canAttack = false;
        yield return new WaitForSeconds(_attackCooldown);
        _canAttack = true;
    }
}