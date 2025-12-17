using UnityEngine;

public class Player : MonoBehaviour
{
    private int _maxHealth = 100;
    private int _health;

    public int Health => _health;
    public int MaxHealth => _maxHealth;

    public void RestoreHealth(int restoredHealth)
    {
        _health += restoredHealth;
        Debug.Log(_health);
    }

    public void TakeDamage(int damage)
    {
        _health = Mathf.Max(0, _health - damage);

        if (_health == 0)
        {
            Die();
        }
    }

    private void Start()
    {
        _health = _maxHealth;
        Debug.Log(_health);
    }

    private void Die()
    {
        Debug.Log("Игрок погиб!");
        gameObject.SetActive(false);
    }

}
