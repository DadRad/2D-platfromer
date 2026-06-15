using UnityEngine;

public class EnemyVision : MonoBehaviour
{
    [SerializeField] private float _detectionRadius = 5f;

    public Player CurrentTarget { get; private set; }

    public bool TryDetectTarget()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, _detectionRadius);

        foreach (Collider2D hit in hits)
        {
            if (hit.TryGetComponent(out Player player))
            {
                CurrentTarget = player;
                return true;
            }
        }

        CurrentTarget = null;
        return false;
    }

    public bool IsTargetInRange(float range)
    {
        if (CurrentTarget == null) return false;

        return Vector2.Distance(transform.position, CurrentTarget.transform.position) <= range;
    }

    public void ClearTarget()
    {
        CurrentTarget = null;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _detectionRadius);
    }
}