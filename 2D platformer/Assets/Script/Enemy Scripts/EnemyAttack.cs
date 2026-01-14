using UnityEngine;

public class EnemyAttack : Attacker
{
    [SerializeField] private float _detectionRadius = 1f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        float distance = Vector2.Distance(transform.position, collision.transform.position);
        
        if (distance <= _detectionRadius)
        {
            PerformAttack();
        }
    }

    protected override void OnAttackHit(Collider2D target)
    {
        Debug.Log($"Враг атаковал {target.name}!");
    }
}
