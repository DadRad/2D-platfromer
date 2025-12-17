using Unity.VisualScripting;
using UnityEngine;

public class Medkit : MonoBehaviour
{
    [SerializeField] Player _player;
    [SerializeField] Collector _collector;

    private int _restotingHealth = 25;

    private void OnEnable()
    {
        _collector.MedkitCollected += RestoreHealth;
    }

    private void OnDisable()
    {
        _collector.MedkitCollected -= RestoreHealth;
    }

    public void RestoreHealth()
    {
        int newHealth = _player.Health + _restotingHealth;
        int clampedHealth = Mathf.Min(newHealth, _player.MaxHealth);
    
        _player.RestoreHealth(clampedHealth - _player.Health);
    }
}
