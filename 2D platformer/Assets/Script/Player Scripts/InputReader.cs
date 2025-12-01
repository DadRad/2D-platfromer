using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string HORIZONTAL_AXIS = "Horizontal";
    private const string JUMP_BUTTON = "Jump";

    public float HorizontalInput { get; private set; }
    public bool JumpPressed { get; private set; }

    private void Update()
    {
        ReadMovement();
        ReadJump();
    }

    private void ReadMovement()
    {
        HorizontalInput = Input.GetAxisRaw(HORIZONTAL_AXIS);
    }

    private void ReadJump()
    {
        JumpPressed = Input.GetButtonDown(JUMP_BUTTON);
    }
}
