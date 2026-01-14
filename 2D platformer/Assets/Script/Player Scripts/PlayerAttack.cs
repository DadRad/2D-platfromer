using UnityEngine;

public class PlayerAttack : Attacker
{
    [SerializeField] private InputReader _inputReader;

    private void Update()
    {
        if (_inputReader.AttackPressed)
        {
            PerformAttack();
        }
    }

    protected override void OnAttackHit(Collider2D target)
    {
        Debug.Log($"Игрок атаковал {target.name}!");
    }
}
