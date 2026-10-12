using System;
using UnityEngine;

public class Vampirism : MonoBehaviour
{
    [SerializeField] private float _cooldown = 4f;
    [SerializeField] private float _duration = 6f;
    [SerializeField] private float _damagePerSecond = 10f;
    [SerializeField] private float _healMultiplier = 0.5f;

    private float _cooldownTimer;
    private float _durationTimer;
    private bool _isActive;

    public event Action Activated;
    public event Action Deactivated;

    public bool IsActive => _isActive;
    public bool IsReady => _cooldownTimer <= 0f;
    public float CooldownProgress => _cooldown > 0f ? 1f - Mathf.Clamp01(_cooldownTimer / _cooldown) : 1f;

    public float DamagePerSecond => _damagePerSecond;
    public float HealMultiplier => _healMultiplier;

    private void Update()
    {
        if (_isActive)
        {
            _durationTimer -= Time.deltaTime;

            if (_durationTimer <= 0f)
                Deactivate();
        }
        else if (_cooldownTimer > 0f)
        {
            _cooldownTimer -= Time.deltaTime;
        }
    }

    public bool TryActivate()
    {
        if (_isActive || IsReady == false)
            return false;

        _isActive = true;
        _durationTimer = _duration;
        _cooldownTimer = _cooldown;
        Activated?.Invoke();
        return true;
    }

    public void Deactivate()
    {
        if (_isActive == false)
            return;

        _isActive = false;
        _durationTimer = 0f;
        Deactivated?.Invoke();
    }
}