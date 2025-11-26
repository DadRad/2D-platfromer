using UnityEngine;

public class GroundCollisionHandler : MonoBehaviour
{
    [SerializeField] private Jumper jumper;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumper.SetCanJump(true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumper.SetCanJump(false);
        }
    }
}