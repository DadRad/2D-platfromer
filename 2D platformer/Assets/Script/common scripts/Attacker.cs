using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] protected float _attackDistance = 1.5f;
    [SerializeField] protected int _damage = 20;
    [SerializeField] protected LayerMask _targetLayer;
    [SerializeField] protected float _attackCooldown = 0.5f;

    [SerializeField] private bool _canAttack = true;

    private Camera _mainCamera;

    protected virtual void Awake()
    {
        _mainCamera = Camera.main;
    }

    public void PerformAttack()
    {
        if (_canAttack == false) return;

        Vector3 mousePosition = Input.mousePosition;
        Vector3 worldMousePosition = _mainCamera.ScreenToWorldPoint(mousePosition);
        worldMousePosition.z = 0f;

        Vector2 attackDirection = ((Vector2)worldMousePosition - (Vector2)transform.position).normalized;

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

    private System.Collections.IEnumerator AttackCooldown()
    {
        _canAttack = false;
        yield return new WaitForSeconds(_attackCooldown);
        _canAttack = true;
    }
}
