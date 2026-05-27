using UnityEngine;

public class TargetFollower : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector2 _offset = new Vector2(0, 50);

    private Camera _camera;
    private RectTransform _rectTransform;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();

        _camera = Camera.main;
    }

    private void Start()
    {
        if (_target == null)
        {
            Debug.LogError("Цель не назначена в TargetFollower!", this);
        }
    }

    private void Update()
    {
        if (_target == null || _camera == null)
        {
            return;
        }

        Vector2 screenPosition = _camera.WorldToScreenPoint(_target.position);
        screenPosition += _offset;
        _rectTransform.position = screenPosition;
    }
}
