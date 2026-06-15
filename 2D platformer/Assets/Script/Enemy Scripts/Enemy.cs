using UnityEngine;

[RequireComponent(typeof(Health))]
public class Enemy : MonoBehaviour, IDamageable
{
    private Health _health;

    private void Awake()
    {
        _health = GetComponent<Health>();
    }
    public void TakeDamage(int damage)
    {
            _health.TakeDamage(damage);
    }
}