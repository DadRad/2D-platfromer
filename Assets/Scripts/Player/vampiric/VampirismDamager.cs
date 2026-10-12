using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class VampirismDamage : MonoBehaviour
{
    [SerializeField] private Vampirism _vampirism;
    [SerializeField] private LayerMask _enemyMask;

    private readonly List<Health> _targetsInRange = new();
    private float _damageAccumulator;
    private float _healAccumulator;

    private void Reset()
    {
        var col = GetComponent<Collider2D>();
        if (col != null) col.isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (((1 << other.gameObject.layer) & _enemyMask) == 0) return;

        if (other.TryGetComponent(out Health health) && !_targetsInRange.Contains(health))
            _targetsInRange.Add(health);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent(out Health health))
            _targetsInRange.Remove(health);
    }

    private void Update()
    {
        if (_vampirism == null || !_vampirism.IsActive) return;

        float damagePerSecond = _vampirism.DamagePerSecond;
        _damageAccumulator += damagePerSecond * Time.deltaTime;

        int damageInt = Mathf.FloorToInt(_damageAccumulator);
        if (damageInt <= 0) return;

        int actualDamageDealt = 0;

        for (int i = _targetsInRange.Count - 1; i >= 0; i--)
        {
            var target = _targetsInRange[i];
            
            if (target == null || !target.IsAlive)
            {
                _targetsInRange.RemoveAt(i);
                continue;
            }

            target.TakeDamage(damageInt);
            actualDamageDealt += damageInt;
        }

        _damageAccumulator -= damageInt;

        if (actualDamageDealt > 0)
        {
            _healAccumulator += actualDamageDealt * _vampirism.HealMultiplier;
            int healInt = Mathf.FloorToInt(_healAccumulator);

            if (healInt > 0)
            {
                HealPlayer(healInt);
                _healAccumulator -= healInt;
            }
        }
    }

    private void HealPlayer(int amount)
    {
        if (_vampirism.TryGetComponent(out Health playerHealth))
            playerHealth.RestoreValue(amount);
    }
}