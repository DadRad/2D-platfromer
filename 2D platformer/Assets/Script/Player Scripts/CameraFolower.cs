using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _smoothSpeed = 5f;

    private Vector3 _offset = new Vector3(0f, 0f, -10f);
    private bool _useBounds = false;
    private Vector2 _minBounds = new Vector2(-10f, -5f);
    private Vector2 _maxBounds = new Vector2(10f, 5f);
    private Camera _camera;
    private Vector3 _targetPosition;
    private bool _isInitialized = false;

    private void Awake()
    {
        _camera = GetComponent<Camera>();
    }

    private void Start()
    {
        Initialize();
    }

    private void LateUpdate()
    {
        if (!_isInitialized || _target == null) return;

        UpdateTargetPosition();
        ApplyPosition();
    }

    private void Initialize()
    {
        if (_target != null)
        {
            transform.position = _target.position + _offset;
            _isInitialized = true;
        }
    }

    public void SetTarget(Transform newTarget)
    {
        _target = newTarget;

        if (newTarget != null)
        {
            Initialize();
        }
    }

    public void SetBoundsEnabled(bool enabled)
    {
        _useBounds = enabled;
    }

    private void UpdateTargetPosition()
    {
        _targetPosition = _target.position + _offset;

        if (_useBounds)
        {
            _targetPosition.x = Mathf.Clamp(_targetPosition.x, _minBounds.x, _maxBounds.x);
            _targetPosition.y = Mathf.Clamp(_targetPosition.y, _minBounds.y, _maxBounds.y);
        }
    }

    private void ApplyPosition()
    {
        transform.position = Vector3.Lerp(
            transform.position,
            _targetPosition,
            _smoothSpeed * Time.deltaTime
        );
    }
}
