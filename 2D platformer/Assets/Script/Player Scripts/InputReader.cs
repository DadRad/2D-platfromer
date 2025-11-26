using UnityEngine;

public class InputReader : MonoBehaviour
{
    public float HorizontalInput { get; private set; }
    public bool JumpPressed { get; private set; }

    private void Update()
    {
        HorizontalInput = Input.GetKey(KeyCode.A) ? -1f : Input.GetKey(KeyCode.D) ? 1f : 0f;
        JumpPressed = Input.GetKeyDown(KeyCode.Space);
    }
}
