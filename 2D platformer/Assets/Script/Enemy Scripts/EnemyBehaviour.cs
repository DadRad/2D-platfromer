using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private EnemyMovement _enemyMovement;
    [SerializeField] private Flipper _flipper;

    private Vector2 _previousPosition;

    private void Awake()
    {
        _previousPosition = transform.position;
    }

    private void Update()
    {
        _enemyMovement?.Tick();
        UpdateFlip();
    }

    private void UpdateFlip()
    {
        if (_flipper == null || _enemyMovement == null) return;

        Vector2 currentPosition = transform.position;
        float moveX = currentPosition.x - _previousPosition.x;

        if (moveX != 0)
        {
            _flipper.LookAt(moveX);
        }

        _previousPosition = currentPosition;
    }
}
