using UnityEngine;

public class Medkit : MonoBehaviour
{
    [SerializeField] private LayerMask _playerLayer;
    [SerializeField] private Health _health;
    
    private int _restoringHealth = 25;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.SetActive(false);

        if (1 << collision.gameObject.layer == _playerLayer)
        {
            RestoreHealth();
        }
    }

    private void RestoreHealth()
    {
        if (_health != null)
        {
            _health.RestoreHealth(_restoringHealth);
            Debug.Log($"❤️ Аптечка восстановила {_restoringHealth} здоровья");
        }
    }
}
