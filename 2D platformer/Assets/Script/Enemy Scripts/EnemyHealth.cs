using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private int _maxHealth = 50;
    private int _currentHealth;

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (damage <= 0) return;

        _currentHealth = Mathf.Max(0, _currentHealth - damage);
        Debug.Log($"💔 Враг получил {damage} урона. Осталось: {_currentHealth}/{_maxHealth}");

        if (_currentHealth == 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Враг погиб");
        Destroy(gameObject);
    }
}
