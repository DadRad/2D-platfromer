using UnityEngine;

public class PlayerAttack : Attacker
{
    private Camera _mainCamera;

    private void Awake()
    {
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PerformAttack();
        }
    }

    protected override bool TryGetAttackDirection(out Vector2 direction)
    {
        Vector3 mousePosition = Input.mousePosition;
        Vector3 worldMousePosition = _mainCamera.ScreenToWorldPoint(mousePosition);
        worldMousePosition.z = 0f;

        direction = ((Vector2)worldMousePosition - (Vector2)transform.position).normalized;
        return true;
    }
}