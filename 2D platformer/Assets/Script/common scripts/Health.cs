using UnityEngine;
using System;

public class Health : MonoBehaviour, IDamageable
{
    [SerializeField] private int _maxHealth = 100;
    private int _currentHealth;

    public int MaxHealth => _maxHealth;
    public int CurrentHealth => _currentHealth;
    public bool IsAlive => _currentHealth > 0;

    public event Action Died;
    public event Action<int> Damaged;
    public event Action<int> Healed;

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (damage <= 0 || !IsAlive) return;

        _currentHealth = Mathf.Max(0, _currentHealth - damage);
        Damaged?.Invoke(damage);

        if (_currentHealth == 0)
        {
            Die();
        }
    }

    public void RestoreHealth(int amount)
    {
        if (amount <= 0 || !IsAlive) return;

        int healed = Mathf.Min(amount, _maxHealth - _currentHealth);
        _currentHealth += healed;
        Healed?.Invoke(healed);
    }

    private void Die()
    {
        Died?.Invoke();
        Debug.Log($"{name} погиб!");
        gameObject.SetActive(false);
    }
}
