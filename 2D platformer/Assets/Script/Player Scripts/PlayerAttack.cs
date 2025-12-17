using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float _attackDistance = 1.5f;
    [SerializeField] private int _damage = 20;
    [SerializeField] private LayerMask _enemyLayer;
    
    private bool _isAttacking = false;
    private Camera _mainCamera;

    private void Awake()
    {
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }

    private void Attack()
    {
        _isAttacking = true;

        Vector3 mousePosition = Input.mousePosition;
        Vector3 worldMousePosition = _mainCamera.ScreenToWorldPoint(mousePosition);
        worldMousePosition.z = 0f;

        Vector2 attackDirection = ((Vector2)worldMousePosition - (Vector2)transform.position).normalized;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, attackDirection, _attackDistance, _enemyLayer);

        Debug.DrawRay(transform.position, attackDirection * _attackDistance, Color.red, 0.2f);

        if (hit.collider != null)
        {
            EnemyHealth enemyHealth = hit.collider.GetComponent<EnemyHealth>();

            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(_damage);
                Debug.Log($"💥 Нанесено {_damage} урона врагу: {hit.collider.name}");
            }
        }

        _isAttacking = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _attackDistance);
    }
}
