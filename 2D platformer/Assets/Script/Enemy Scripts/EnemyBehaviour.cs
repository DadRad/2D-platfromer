using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private EnemyMovement _enemyMovement;
    [SerializeField] private EnemyChase _enemyChase;
    [SerializeField] private Flipper _flipper;

    private Vector2 _previousPosition;

    private void Awake()
    {
        _previousPosition = transform.position;
    }

    private void Update()
    {
        if (_enemyChase != null)
        {
            _enemyChase.Tick();
        }

        if (_enemyChase == null || !_enemyChase.IsChasing)
        {
            _enemyMovement?.Tick();
        }

        UpdateFlip();
    }

    private void UpdateFlip()
    {
        if (_flipper == null) return;

        Vector2 currentPosition = transform.position;
        float moveX = currentPosition.x - _previousPosition.x;

        if (moveX != 0)
        {
            _flipper.LookAt(moveX);
        }

        _previousPosition = currentPosition;
    }

    private void OnValidate()
    {
        if (_enemyMovement == null) Debug.LogWarning("EnemyMovement не назначен", this);
        if (_flipper == null) Debug.LogWarning("Flipper не назначен", this);
    }
}
