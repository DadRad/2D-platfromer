using UnityEngine;

public class Medkit : MonoBehaviour
{
    [SerializeField] private Health _health;
    
    private int _restoringHealth = 25;
    private bool _isCollected = false;

    public bool IsCollected => _isCollected;

    public void RestoreHealth()
    {
        _isCollected = true;

        if (_health != null)
        {
            _health.RestoreHealth(_restoringHealth);
            Debug.Log($"❤️ Аптечка восстановила {_restoringHealth} здоровья");
        }
    }
}
