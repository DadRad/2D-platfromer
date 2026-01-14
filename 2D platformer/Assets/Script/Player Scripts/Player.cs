using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Health _health;

    public Health GetHealth() => _health;

    private void Start()
    {
        if (_health == null)
        {
            _health = GetComponent<Health>();
        }

        if (_health == null)
        {
            Debug.LogError("Health не найден на игроке!", this);
        }
    }
}
