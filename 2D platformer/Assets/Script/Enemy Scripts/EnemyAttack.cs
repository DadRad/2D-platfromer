using UnityEngine;

public class EnemyAttack : Attacker
{
    [SerializeField] private float _detectionRadius = 1f;
    [SerializeField] private Transform _player;

    private void Update()
    {
        if (_player == null) return;

        float distance = Vector2.Distance(transform.position, _player.position);
        
        if (distance <= _detectionRadius && _canAttack)
        {
            PerformAttack();
        }
    }

    public override void PerformAttack()
    {
        if (!_canAttack || _player == null) return;

        // Атакуем строго в сторону игрока
        Vector2 attackDirection = ((Vector2)_player.position - (Vector2)transform.position).normalized;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, attackDirection, _attackDistance, _targetLayer);

        Debug.DrawRay(transform.position, attackDirection * _attackDistance, Color.green, 0.2f);

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

    protected override void OnAttackHit(Collider2D target)
    {
        Debug.Log($"👹 Враг атаковал {target.name}!");
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _detectionRadius);
    }
}
