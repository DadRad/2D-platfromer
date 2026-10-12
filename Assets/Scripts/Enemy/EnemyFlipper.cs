using UnityEngine;

[RequireComponent(typeof(Flipper))]
public class EnemyFlipper : MonoBehaviour
{
    private const float MinMoveThreshold = 0.01f;

    private Flipper _flipper;
    private Rigidbody2D _rigidbody;
    private Vector2 _previousPosition;

    private void Awake()
    {
        _flipper = GetComponent<Flipper>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _previousPosition = transform.position;
    }

    private void Update()
    {
        float moveX = GetMoveX();

        if (Mathf.Abs(moveX) > MinMoveThreshold)
            _flipper.LookAt(moveX);
    }

    private float GetMoveX()
    {
        if (_rigidbody != null)
            return _rigidbody.linearVelocity.x;

        Vector2 currentPosition = transform.position;
        float delta = (currentPosition.x - _previousPosition.x) / Time.deltaTime;
        _previousPosition = currentPosition;

        return delta;
    }
}