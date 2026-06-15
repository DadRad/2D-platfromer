using UnityEngine;

[RequireComponent(typeof(Flipper))]
public class EnemyFlipper : MonoBehaviour
{
    private Flipper _flipper;
    private Vector2 _previousPosition;

    private void Awake()
    {
        _flipper = GetComponent<Flipper>();
        _previousPosition = transform.position;
    }

    private void Update()
    {
        UpdateFlip();
    }

    private void UpdateFlip()
    {
        Vector2 currentPosition = transform.position;
        float moveX = currentPosition.x - _previousPosition.x;

        if (moveX != 0)
        {
            _flipper.LookAt(moveX);
        }

        _previousPosition = currentPosition;
    }
}