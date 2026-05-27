using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    private Health _health;

    private void Awake()
    {
        _health = GetComponent<Health>();
    }
    public void TakeDamage(int damage)
    {
        if (_health != null)
        {
            _health.TakeDamage(damage);
        }
    }
}