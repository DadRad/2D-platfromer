using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    [SerializeField] private Health _health;

    public Health PlayerHealth => _health;

    private void Start()
    {
        if (_health == null)
        {
            _health = GetComponent<Health>();
        }

        if (_health == null)
        {
            Debug.LogError("Health не найден на игроке!", this);
        }
    }

    public void TakeDamage(int damage)
    {
        if (_health != null)
        {
            _health.TakeDamage(damage);
        }
    }

    public void Heal(int amount)
    {
        if (_health != null)
        {
            _health.RestoreHealth(amount);
        }
    }
}