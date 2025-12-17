using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private int _damage = 10;
    [SerializeField] private float _attackCooldown = 1f;
    [SerializeField] private bool _canAttack = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!_canAttack) return;

        if (collision.CompareTag("Player") && _player != null)
        {
            _player.TakeDamage(_damage);
            Debug.Log($"💔 Игрок получил {_damage} урона от врага!");
            StartCoroutine(AttackCooldown());
        }
    }

    private System.Collections.IEnumerator AttackCooldown()
    {
        _canAttack = false;
        yield return new WaitForSeconds(_attackCooldown);
        _canAttack = true;
    }

    private void OnValidate()
    {
        if (_player == null)
            Debug.LogWarning("Player не назначен в EnemyAttack!", this);
    }
}
