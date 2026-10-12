using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string HorizontalAxis = "Horizontal";
    private const string JumpButton = "Jump";
    private const string AttackButton = "Fire1";
    private const string AbilityButton = "Fire2";

    public float HorizontalInput { get; private set; }
    public bool JumpPressed { get; private set; }
    public bool AttackPressed { get; private set; }
    public bool VampirismAbilityUsed {get; private set;}

    private void Update()
    {
        ReadMovement();
        ReadJump();
        ReadAttack();
        ReadVampirismAbility();
    }

    private void ReadMovement()
    {
        HorizontalInput = Input.GetAxisRaw(HorizontalAxis);
    }

    private void ReadJump()
    {
        JumpPressed = Input.GetButtonDown(JumpButton);
    }

    private void ReadAttack()
    {
        AttackPressed = Input.GetButtonDown(AttackButton);
    }

    private void ReadVampirismAbility()
    {
        VampirismAbilityUsed = Input.GetButtonDown(AbilityButton);
    }
}